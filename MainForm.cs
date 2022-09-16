using FileCopier.Manager;
using FileCopier.Utils;

namespace FileCopier {
    public partial class MainForm : Form {
        private SettingManager settingManager;
        private FileManager fileManager;
        private PathFinder pathFinder;

        public MainForm() {
            InitializeComponent();

            this.settingManager = new SettingManager();
            this.settingManager.loadSettings(this.loadSettingValues);

            this.fileManager = new FileManager();
            this.pathFinder = new PathFinder();

            this.checkDirectories();
        }

        private void sourcePathButton_Click(object sender, EventArgs e) {
            this.pathFinder.openPathDialog(this.sourcePath, this.showMessage);
            this.settingManager.saveConfig(this.getSettings(this.loadCheckedItems()), this.showMessage);
        }

        private void targetPathButton_Click(object sender, EventArgs e) {
            this.pathFinder.openPathDialog(this.targetPath, this.showMessage);
            this.settingManager.saveConfig(this.getSettings(this.loadCheckedItems()), this.showMessage);
        }

        private void additionalSettings_ItemCheck(object sender, ItemCheckEventArgs e) {
            List<string> checkedItems = this.loadCheckedItems();
            string actualItem = additionalSettings.Items[e.Index].ToString()!;
            if (e.NewValue == CheckState.Checked) {
                checkedItems.Add(actualItem);
            } else {
                checkedItems.Remove(actualItem);
            }
            this.settingManager.saveConfig(this.getSettings(checkedItems), this.showMessage);
        }

        private void directoriesCheck_Click(object sender, EventArgs e) {
            this.checkDirectories();
            this.showMessage("Kontrola dokonèena");
        }

        private bool checkDirectories() {
            bool isSourceActive = true;
            bool isTargetActive = true;

            if (this.isPhone.Checked) {
                isSourceActive = FileManager.checkMobileDirectory(
                    this.visualChangeLabelActive,
                    this.sourceStatus,
                    this.sourcePath.Text,
                    this.mobilePath.Text
                );
            } else {
                isSourceActive = FileManager.checkDirectory(
                    this.visualChangeLabelActive, 
                    this.sourceStatus, 
                    this.sourcePath.Text
               );
            }
            isTargetActive = FileManager.checkDirectory(
                this.visualChangeLabelActive,
                this.targetStatus,
                this.targetPath.Text
            );

            return (isSourceActive && isTargetActive);
        }

        private void copyButton_Click(object sender, EventArgs e) {
            if (this.checkDirectories()) {
                this.resultGroup.Visible = true;
                this.resultState.Text = "";

                if (this.isPhone.Checked) {
                    this.fileManager.copyFiles(
                        this.sourcePath.Text,
                        this.mobilePath.Text,
                        this.targetPath.Text,
                        this.progress,
                        this.resultState,
                        this.copiedFilesCount,
                        this.visualChangeLabelActive
                    );
                } else {
                    this.fileManager.copyFiles(
                        this.sourcePath.Text,
                        this.targetPath.Text,
                        true,
                        this.progress,
                        this.resultState,
                        this.copiedFilesCount,
                        this.visualChangeLabelActive
                    );
                }
            } else {
                this.showMessage("Složky nejsou aktivní");
            }
        }

        private void isPhone_CheckedChanged(object sender, EventArgs e) {
            this.visuealSetMobilePath((sender as CheckBox)!.Checked);
            this.settingManager.saveConfig(this.getSettings(this.loadCheckedItems()), this.showMessage);
        }

        private void sourcePath_TextChanged(object sender, EventArgs e) {
            this.settingManager.saveConfig(this.getSettings(this.loadCheckedItems()), this.showMessage);
        }

        private void mobilePath_TextChanged(object sender, EventArgs e) {
            this.settingManager.saveConfig(this.getSettings(this.loadCheckedItems()), this.showMessage);
        }

        public void visuealSetMobilePath(bool isMobile) {
            if (isMobile) {
                this.sourcePath.ReadOnly = false;
                this.mobilePath.Visible = true;
                this.mobilePathLabel.Visible = true;
            } else {
                this.sourcePath.ReadOnly = true;
                this.mobilePath.Visible = false;
                this.mobilePathLabel.Visible = false;
            }
        }

        private void visualChangeLabelActive(TextBox status, bool isActive) {
            this.visualChangeLabelActive(status, isActive, (isActive) ? "Aktivní" : "Neaktivní");
        }

        private void visualChangeLabelActive(TextBox status, bool isActive, string text) {
            if (isActive) {
                status.Text = text;
                status.BackColor = Color.Green;
            } else {
                status.Text = text;
                status.BackColor = Color.Red;
            }
        }

        private List<string> loadCheckedItems() {
            List<string> checkedItems = new List<string>();
            foreach (var item in additionalSettings.CheckedItems) {
                checkedItems.Add(item.ToString()!);
            }

            return checkedItems;
        }

        public List<Settings> getSettings(List<string> checkedItems) => new()
        {
            new("SourcePath",  this.sourcePath.Text),
            new("SourcePathAsPhone", this.isPhone.Checked.ToString()),
            new("MobilePath", this.mobilePath.Text),
            new("TargetPath", this.targetPath.Text),
            new("Additional", string.Join(",", checkedItems))
        };

        private void showMessage(string message) {
            System.Windows.Forms.MessageBox.Show(message);
        }

        private void loadSettingValues(Settings setting) {
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