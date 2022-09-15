using MediaDevices;
using Newtonsoft.Json;
using System;
using System.Collections;


namespace FileCopier {
    public partial class MainForm : Form {
        private string localLowPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
        private string settingsDirectory = "";
        private string settingsFile = "";


        public MainForm() {
            InitializeComponent();

            this.settingsDirectory = this.localLowPath + "/FileCopier";
            this.settingsFile = this.settingsDirectory + "/settings.json";

            this.loadSettings();
            this.directoryCheck();
        }

        private void loadSettings() {
            if (File.Exists(this.settingsFile)) {
                using (StreamReader r = new StreamReader(this.settingsFile)) {
                    foreach (Settings setting in JsonConvert.DeserializeObject<List<Settings>>(r.ReadToEnd())) {
                        switch (setting.Name) {
                            case "SourcePath":
                                this.sourcePath.Text = setting.Value;
                                break;
                            case "TargetPath":
                                this.targetPath.Text = setting.Value;
                                break;
                            case "SourcePathAsPhone":
                                this.isPhone.Checked = bool.Parse(setting.Value);
                                this.sourcePath.ReadOnly = !bool.Parse(setting.Value);

                                this.mobilePath.Visible = bool.Parse(setting.Value);
                                this.mobilePathLabel.Visible = bool.Parse(setting.Value);
                                break;
                            case "MobilePath":
                                this.mobilePath.Text = setting.Value;
                                break;
                            case "Additional":
                                List<string> additional = new List<string>(setting.Value.Split(',', StringSplitOptions.None));
                                for (int count = 0; count < additionalSettings.Items.Count; count++) {
                                    if (additional.Contains(additionalSettings.Items[count].ToString())) {
                                        additionalSettings.SetItemChecked(count, true);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        protected virtual bool IsFileLocked(FileInfo file) {
            try {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) {
                    stream.Close();
                }
            } catch (IOException) {
                return true;
            }
            return false;
        }

        private void changeStatusUniversal(TextBox status, string directoryPath) {
            if (this.isDirectoryActive(directoryPath)) {
                status.Text = "Aktivní";
                status.BackColor = Color.Green;
            } else {
                status.Text = "Neaktivní";
                status.BackColor = Color.Red;
            }
        }

        private bool isDirectoryActive(string directoryPath) {
            return Directory.Exists(directoryPath);
        }

        private void showMessage(string message) {
            System.Windows.Forms.MessageBox.Show(message);
        }

        private void openPathSelector(TextBox objectType) {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath)) {
                    objectType.Text = folderBrowserDialog.SelectedPath.ToString();
                    return;
                }
            }
            this.showMessage("Není možné zvolit tuto složku.");
        }

        private List<string> loadCheckedItems() {
            List<string> checkedItems = new List<string>();
            foreach (var item in additionalSettings.CheckedItems) {
                checkedItems.Add(item.ToString());
            }

            return checkedItems;
        }

        public static List<Settings> getSettings(string sourcePath, string sourcePathAsPhone, string targetPath, string mobilePath, List<string> checkedItems) => new()
        {
            new("SourcePath", sourcePath),
            new("SourcePathAsPhone", sourcePathAsPhone),
            new("MobilePath", mobilePath),
            new("TargetPath", targetPath),
            new("Additional", string.Join(",", checkedItems))
        };

        private void saveConfig(List<string> checkedItems) {
            try {
                if (Directory.Exists(this.localLowPath)) {
                    if (!Directory.Exists(this.settingsDirectory)) {
                        Directory.CreateDirectory(this.settingsDirectory);
                    }
                    List<Settings> settings = MainForm.getSettings(
                        this.sourcePath.Text,
                        this.isPhone.Checked.ToString(),
                        this.targetPath.Text,
                        this.mobilePath.Text,
                        checkedItems);
                    File.WriteAllText(this.settingsFile, JsonConvert.SerializeObject(settings, Formatting.Indented));
                }
            } catch (Exception e) {
                this.showMessage("Nepodaøilo se uložit nastavení - " + e.Message);
            }
        }

        private void sourcePathButton_Click(object sender, EventArgs e) {
            this.openPathSelector(this.sourcePath);
            this.saveConfig(this.loadCheckedItems());
        }

        private void targetPathButton_Click(object sender, EventArgs e) {
            this.openPathSelector(this.targetPath);
            this.saveConfig(this.loadCheckedItems());
        }

        private void additionalSettings_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (!this.IsFileLocked(new FileInfo(this.settingsFile))) {
                List<string> checkedItems = this.loadCheckedItems();
                if (e.NewValue == CheckState.Checked) {
                    checkedItems.Add(additionalSettings.Items[e.Index].ToString());
                } else {
                    checkedItems.Remove(additionalSettings.Items[e.Index].ToString());
                }
                this.saveConfig(checkedItems);
            }
        }

        private bool checkMobileDirectory(TextBox status, string directoryPath) {
            try {
                var devices = MediaDevice.GetDevices();
                using (var device = devices.First(d => d.FriendlyName == directoryPath)) {
                    device.Connect();
                    var photoDir = device.GetDirectoryInfo($@"{this.mobilePath.Text}");
                    device.Disconnect();

                    status.Text = "Aktivní";
                    status.BackColor = Color.Green;
                }
                return true;
            } catch (Exception e) {
                status.Text = "Neaktivní";
                status.BackColor = Color.Red;
                return false;
            }
        }

        private void directoriesCheck_Click(object sender, EventArgs e) {
            this.directoryCheck();

            this.showMessage("Kontrola dokonèena");
        }

        private void directoryCheck() {
            if (this.isPhone.Checked) {
                this.checkMobileDirectory(this.sourceStatus, this.sourcePath.Text);
                this.changeStatusUniversal(this.targetStatus, this.targetPath.Text);
            } else {
                this.changeStatusUniversal(this.sourceStatus, this.sourcePath.Text);
                this.changeStatusUniversal(this.targetStatus, this.targetPath.Text);
            }
        }

        private void copyButton_Click(object sender, EventArgs e) {
            if ((this.isDirectoryActive(this.sourcePath.Text) || this.checkMobileDirectory(this.sourceStatus, this.sourcePath.Text)) && this.isDirectoryActive(this.targetPath.Text)) {
                this.resultGroup.Visible = true;
                this.resultState.Text = "";

                if (this.isPhone.Checked) {
                    this.copyFilesFromPhone(this.sourcePath.Text, this.mobilePath.Text);
                } else {
                    this.copyFiles(this.sourcePath.Text, this.targetPath.Text, true);
                }
            } else {
                this.showMessage("Složky nejsou aktivní");
            }
        }

        private int iEnumerableCount(IEnumerable source) {
            if (source == null) {
                throw new ArgumentNullException("source");
            }

            ICollection collectionSource = source as ICollection;
            if (collectionSource != null) {
                return collectionSource.Count;
            }

            int num = 0;
            IEnumerator enumerator = source.GetEnumerator();
            try {
                while (enumerator.MoveNext()) {
                    num++;
                }
            } finally {
                IDisposable disposableEnumerator = enumerator as IDisposable;
                if (disposableEnumerator != null) {
                    disposableEnumerator.Dispose();
                }
            }
            return num;
        }

        private void copyFilesFromPhone(string phoneName, string mobilePath) {
            try {
                var devices = MediaDevice.GetDevices();
                using (var device = devices.First(d => d.FriendlyName == phoneName)) {
                    device.Connect();
                    var photoDir = device.GetDirectoryInfo($@"{mobilePath}");
                    var files = photoDir.EnumerateFiles("*.*", SearchOption.AllDirectories);
                    int copiedFiles = 0;

                    progress.Minimum = 0;
                    progress.Maximum = this.iEnumerableCount(files);
                    progress.Value = 0;

                    string dateTime = DateTime.Today.ToString("yyyy-MM-dd");
                    if (!Directory.Exists($@"{this.targetPath.Text}\{dateTime}")) {
                        Directory.CreateDirectory($@"{this.targetPath.Text}\{dateTime}");
                    }

                    foreach (var file in files) {
                        MemoryStream memoryStream = new System.IO.MemoryStream();
                        device.DownloadFile(file.FullName, memoryStream);
                        memoryStream.Position = 0;
                        using (FileStream fileStream = new FileStream($@"{this.targetPath.Text}\{dateTime}\{file.Name}", FileMode.Create, System.IO.FileAccess.Write)) {
                            byte[] bytes = new byte[memoryStream.Length];
                            memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                            fileStream.Write(bytes, 0, bytes.Length);
                            memoryStream.Close();
                        }
                        copiedFiles++;
                        this.copiedFilesCount.Text = copiedFiles.ToString();
                        progress.Value = copiedFiles;
                    }
                    device.Disconnect();

                    this.copiedFilesCount.Text = copiedFiles.ToString();
                    this.resultState.Text = "Dokonèeno";
                    this.resultState.ForeColor = Color.Green;
                }
            } catch (Exception e) {
                this.showMessage(e.Message);
                this.resultState.Text = "Nezdaøilo se";
                this.resultState.ForeColor = Color.Red;
            }
        }

        private void copyFiles(string fromPath, string toPath, bool subDirectories) {
            try {
                int copiedFiles = 0;
                string[] files = System.IO.Directory.GetFiles(fromPath);

                int maximalProgressValue = files.Length;
                if (subDirectories) {
                    maximalProgressValue += Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories).Length;
                }

                progress.Minimum = 0;
                progress.Maximum = maximalProgressValue;
                progress.Value = 0;

                foreach (string file in files) {
                    string fileName = System.IO.Path.GetFileName(file);
                    System.IO.File.Copy(file, System.IO.Path.Combine(toPath, fileName), true);
                    copiedFiles++;
                    progress.Value = copiedFiles;
                }

                if (subDirectories) {
                    foreach (string dirPath in Directory.GetDirectories(fromPath, "*", SearchOption.AllDirectories)) {
                        Directory.CreateDirectory(dirPath.Replace(fromPath, toPath));
                    }
                    foreach (string newPath in Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories)) {
                        File.Copy(newPath, newPath.Replace(fromPath, toPath), true);
                        copiedFiles++;
                        progress.Value = copiedFiles;
                    }
                }

                this.copiedFilesCount.Text = copiedFiles.ToString();
                this.resultState.Text = "Dokonèeno";
                this.resultState.ForeColor = Color.Green;
            } catch (Exception e) {
                this.resultState.Text = "Nezdaøilo se";
                this.resultState.ForeColor = Color.Red;
            }
        }

        private void isPhone_CheckedChanged(object sender, EventArgs e) {
            if ((sender as CheckBox).Checked) {
                this.sourcePath.ReadOnly = false;

                this.mobilePath.Visible = true;
                this.mobilePathLabel.Visible = true;
            } else {
                this.sourcePath.ReadOnly = true;

                this.mobilePath.Visible = false;
                this.mobilePathLabel.Visible = false;
            }

            if (!this.IsFileLocked(new FileInfo(this.settingsFile))) {
                this.saveConfig(this.loadCheckedItems());
            }
        }

        private void sourcePath_TextChanged(object sender, EventArgs e) {
            if (!this.IsFileLocked(new FileInfo(this.settingsFile))) {
                this.saveConfig(this.loadCheckedItems());
            }
        }

        private void mobilePath_TextChanged(object sender, EventArgs e) {
            if (!this.IsFileLocked(new FileInfo(this.settingsFile))) {
                this.saveConfig(this.loadCheckedItems());
            }
        }
    }
}