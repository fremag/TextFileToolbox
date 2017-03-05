using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TFT.Tail.Core;
using TFT.Tail.FileRepository;
using TFT.Tail.FileViewer.Config;
using WinFwk.UITools.Settings;

namespace TFT.Tail
{
    public class TailSettings : UISettings
    {
        public new static TailSettings Instance => UISettings.Instance as TailSettings;

        [Browsable(false)]
        public int NumConfig { get; set; }

        public List<FileRepositoryFolderConfig> FileRepositoryFolderConfigs { get; set; } = new List<FileRepositoryFolderConfig>();
        public List<FileViewerConfig> FileViewerConfigs { get; set; } = new List<FileViewerConfig>();

        public T Create<T>() where T : IIdentifiable, new()
        {
            return new T() { Id = NumConfig++ };
        }

        public void UpdateFileRepositoryFolderConfig(FileRepositoryFolderConfig config)
        {
            Update(config, FileRepositoryFolderConfigs);
            Save();
        }

        public void UpdateFileViewerConfig(FileViewerConfig config)
        {
            Update(config, FileViewerConfigs);
            Save();
        }

        public void Update<T>(T config, IList<T> list) where T : IIdentifiable
        {
            var configToUpdate = list.FirstOrDefault(c => c.Id == config.Id);
            if (configToUpdate == null && config != null)
            {
                list.Add(config);
                return;
            }
            int idx = list.IndexOf(configToUpdate);
            list.RemoveAt(idx);
            list.Insert(idx, config);
        }

        public void Save()
        {
            UISettingsMgr<TailSettings>.Save(this);
        }
    }
}
