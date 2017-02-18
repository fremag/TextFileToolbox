using System.Collections.Generic;
using WinFwk.UITools.Settings;

namespace TFT.Tail
{
    public class TailSettings : UISettings
    {
        public new static TailSettings Instance => UISettings.Instance as TailSettings;

        public List<FileRepositoryFolderConfig> FileRepositoryFolderConfigs { get; set; } = new List<FileRepositoryFolderConfig>();
    }
}
