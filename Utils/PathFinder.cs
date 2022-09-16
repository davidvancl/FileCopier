namespace FileCopier.Utils {
    internal class PathFinder {
        private string localLowPath;
        private string settingsDirectory;
        private string settingsFile;

        public PathFinder() { 
            this.localLowPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            this.settingsDirectory = this.localLowPath + "/FileCopier";
            this.settingsFile = this.settingsDirectory + "/settings.json";
        }

        protected bool loadPathFromFBDialog(TextBox objectType) {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath)) {
                    objectType.Text = folderBrowserDialog.SelectedPath.ToString();
                    return true;
                }
            }
            return false;
        }

        public void openPathDialog(TextBox objectType, Action<string> errorMessage) {
            if (!this.loadPathFromFBDialog(objectType)) {
                errorMessage("Není možné zvolit tuto složku.");
            }
        }

        public string getLocalLowPath() {
            return this.localLowPath;
        }

        public string getSettingsDirectory() {
            return this.settingsDirectory;
        }

        public string getSettingsFile() {
            return this.settingsFile;
        }
    }
}
