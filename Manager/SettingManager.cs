using FileCopier.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopier.Manager {

    internal class SettingManager {
        private PathFinder pathFinder;

        public SettingManager() {
            this.pathFinder = new PathFinder();
        }

        public void loadSettings(Action<Settings> fillSettingValues) {
            if (File.Exists(this.pathFinder.getSettingsFile())) {
                using (StreamReader streamReader = new StreamReader(this.pathFinder.getSettingsFile())) {
                    foreach (Settings setting in JsonConvert.DeserializeObject<List<Settings>>(streamReader.ReadToEnd())!) {
                        fillSettingValues(setting);
                    }
                }
            }
        }

        public void saveConfig(List<Settings> settings, Action<string> errorMessage) {
            if (!Directory.Exists(this.pathFinder.getLocalLowPath())) {
                return;
            }

            if (!Directory.Exists(this.pathFinder.getSettingsDirectory())) {
                Directory.CreateDirectory(this.pathFinder.getSettingsDirectory());
            }

            if (!FileManager.IsFileLocked(this.pathFinder.getSettingsFile()) || !File.Exists(this.pathFinder.getSettingsFile())) {
                try {
                    File.WriteAllText(this.pathFinder.getSettingsFile(), JsonConvert.SerializeObject(settings, Formatting.Indented));
                } catch (Exception e) {
                    errorMessage("Nepodařilo se uložit nastavení - " + e.Message);
                }
            }
        }
    }
}
