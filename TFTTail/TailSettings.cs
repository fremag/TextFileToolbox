using System.Collections.Generic;
using System.Linq;
using TFT.Tail.FileRepository;
using WinFwk.UITools.Settings;

namespace TFT.Tail
{
    public class TailSettings : UISettings
    {
        public new static TailSettings Instance => UISettings.Instance as TailSettings;
        public int NumConfig { get; set; }
        public List<FileRepositoryFolderConfig> FileRepositoryFolderConfigs { get; set; } = new List<FileRepositoryFolderConfig>();
        public FileRepositoryFolderConfig CreateFileRepositoryFolderConfig()
        {
            return new FileRepositoryFolderConfig() { Id = NumConfig++ };
        }

        public void UpdateFileRepositoryFolderConfig(FileRepositoryFolderConfig config)
        {
            var configToUpdate = FileRepositoryFolderConfigs.FirstOrDefault(c => c.Id == config.Id);
            if (configToUpdate == null)
            {
                return;
            }
            int idx = FileRepositoryFolderConfigs.IndexOf(configToUpdate);
            FileRepositoryFolderConfigs.RemoveAt(idx);
            FileRepositoryFolderConfigs.Insert(idx, config);
        }
    }
}
