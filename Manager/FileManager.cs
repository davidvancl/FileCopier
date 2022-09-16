using MediaDevices;
using System.Collections;

namespace FileCopier.Manager
{
    internal class FileManager
    {
        public static bool IsFileLocked(string filePath) {
            try {
                using (FileStream stream = new FileInfo(filePath).Open(FileMode.Open, FileAccess.Read, FileShare.None)) {
                    stream.Close();
                }
            } catch (IOException) {
                return true;
            }
            return false;
        }

        public static bool checkMobileDirectory(Action<TextBox, bool> statusAction, TextBox box, string mobileName, string mobilePath) {
            try {
                var devices = MediaDevice.GetDevices();
                using (var device = devices.First(directory => directory.FriendlyName == mobileName)) {
                    device.Connect();
                    device.GetDirectoryInfo($@"{mobilePath}");
                    device.Disconnect();
                    statusAction(box, true);
                }
                return true;
            } catch (Exception e) {
                statusAction(box, false);
                return false;
            }
        }

        public static bool checkDirectory(Action<TextBox, bool> statusAction, TextBox box, string directoryPath) {
            if (Directory.Exists(directoryPath)) {
                statusAction(box, true);
                return true;
            } else {
                statusAction(box, false);
                return false;
            }
        }

        public void copyFiles(
            string phoneName,
            string mobilePath,
            string targetPath,
            ProgressBar progressBar,
            TextBox resultState,
            Label copiedFilesCount,
            Action<TextBox, bool, string> statusAction
            ) {
            try {
                var devices = MediaDevice.GetDevices();
                using (var device = devices.First(d => d.FriendlyName == phoneName)) {
                    device.Connect();

                    MediaDirectoryInfo mediaDirectoryInfo = device.GetDirectoryInfo($@"{mobilePath}");
                    IEnumerable<MediaFileInfo> files = mediaDirectoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories);
                    int copiedFiles = 0;

                    progressBar.Minimum = 0;
                    progressBar.Maximum = this.iEnumerableCount(files);
                    progressBar.Value = 0;

                    string dateTime = DateTime.Today.ToString("yyyy-MM-dd");
                    if (!Directory.Exists($@"{targetPath}\{dateTime}")) {
                        Directory.CreateDirectory($@"{targetPath}\{dateTime}");
                    }

                    foreach (var file in files) {
                        MemoryStream memoryStream = new System.IO.MemoryStream();
                        device.DownloadFile(file.FullName, memoryStream);
                        memoryStream.Position = 0;
                        using (FileStream fileStream = new FileStream($@"{targetPath}\{dateTime}\{file.Name}", FileMode.Create, System.IO.FileAccess.Write)) {
                            byte[] bytes = new byte[memoryStream.Length];
                            memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                            fileStream.Write(bytes, 0, bytes.Length);
                            memoryStream.Close();
                        }
                        copiedFiles++;
                        copiedFilesCount.Text = copiedFiles.ToString();
                        progressBar.Value = copiedFiles;
                    }
                    device.Disconnect();
                    
                    copiedFilesCount.Text = copiedFiles.ToString();
                    statusAction(resultState, true, "Dokončeno");
                }
            } catch (Exception e) {
                statusAction(resultState, false, "Nezdařilo se");
            }
        }

        public void copyFiles(
            string fromPath,
            string toPath,
            bool subDirectories,
            ProgressBar progressBar,
            TextBox resultState,
            Label copiedFilesCount,
            Action<TextBox, bool, string> statusAction
            ) {
            try {
                int copiedFiles = 0;
                string[] files = System.IO.Directory.GetFiles(fromPath);

                int maximalProgressValue = files.Length;
                if (subDirectories) {
                    maximalProgressValue += Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories).Length;
                }

                progressBar.Minimum = 0;
                progressBar.Maximum = maximalProgressValue;
                progressBar.Value = 0;

                foreach (string file in files) {
                    string fileName = System.IO.Path.GetFileName(file);
                    System.IO.File.Copy(file, System.IO.Path.Combine(toPath, fileName), true);
                    copiedFiles++;
                    progressBar.Value = copiedFiles;
                }

                if (subDirectories) {
                    foreach (string dirPath in Directory.GetDirectories(fromPath, "*", SearchOption.AllDirectories)) {
                        Directory.CreateDirectory(dirPath.Replace(fromPath, toPath));
                    }
                    foreach (string newPath in Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories)) {
                        File.Copy(newPath, newPath.Replace(fromPath, toPath), true);
                        copiedFiles++;
                        progressBar.Value = copiedFiles;
                    }
                }

                copiedFilesCount.Text = copiedFiles.ToString();
                statusAction(resultState, true, "Dokončeno");
            } catch (Exception e) {
                statusAction(resultState, false, "Nezdařilo se");
            }
        }

        private int iEnumerableCount(IEnumerable source) {
            try {
                if (source.GetType() == typeof(ICollection)) {
                    return (source as ICollection)!.Count;
                } else {
                    int count = 0;
                    IEnumerator enumerator = source.GetEnumerator();
                    try {
                        while (enumerator.MoveNext()) count++;
                    } finally {
                        (enumerator as IDisposable)!.Dispose();
                    }
                    return count;
                }
            } catch (ArgumentNullException e) {
                return 0;
            }
        }
    }
}
