using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UITools;

namespace TFT.Tail.FileRepository
{
    public abstract class AbstractFileRepositoryInformation : TreeNodeInformationAdapter<AbstractFileRepositoryInformation>
    {
        [OLVColumn(Width = 150, ImageAspectName = nameof(Icon))]
        public string Name { get; protected set; }
        [IntColumn(Title = "Size (Mo)", Width = 50)]
        public abstract long Size { get; }
        public Image Icon { get; protected set; }

        [OLVColumn(Title = "Date", Width = 150, TextAlign = HorizontalAlignment.Center, AspectToStringFormat = "{0:yyyy/MM/dd HH:mm:ss}")]
        public abstract DateTime? Date { get; }
    }

    public class FileRepositoryInformation : AbstractFileRepositoryInformation
    {
        FileInfo FileInfo { get; }
        public FileRepositoryInformation(FileInfo fileInfo) {
            FileInfo = fileInfo;
            Name = fileInfo.Name;
            Icon = Properties.Resources.text_document;
        }

        public override DateTime? Date => FileInfo.LastWriteTime;
        public override long Size => FileInfo.Length / 1000000;
    }

    public class FolderRepositoryInformation : AbstractFileRepositoryInformation
    {
        FileRepositoryFolderConfig Config { get; }
        DirectoryInfo dirInfo;
        FileInfo[] fileInfos;
        DirectoryInfo[] subDirInfos;

        public FolderRepositoryInformation(FileRepositoryFolderConfig config)
        {
            Config = config;
            Name = Config.Name;
            Icon = Properties.Resources.folder_small;
            dirInfo = new DirectoryInfo(Config.Path);
            if (!dirInfo.Exists)
            {
                Icon = Properties.Resources.folder_error;
                Tooltip = $"Can't find path: {dirInfo.Exists}";
                dirInfo = null;
            }
            else if (string.IsNullOrEmpty(Config.Pattern))
            {
                Icon = Properties.Resources.folder_error;
                Tooltip = "Pattern is null or empty !";
                dirInfo = null;
            }
            else
            {
                fileInfos = dirInfo.GetFiles(Config.Pattern);
                subDirInfos = dirInfo.GetDirectories();
            }
        }

        public override DateTime? Date
        {
            get
            {
                return dirInfo == null ? default (DateTime?) : dirInfo.LastWriteTime;
            }
        }

        public override long Size
        {
            get
            {
                return fileInfos ==  null ? -1 : fileInfos.Length;
            }
        }

        public override bool CanExpand => (fileInfos != null && fileInfos.Any()) || (subDirInfos != null  && subDirInfos.Any());
        public override List<AbstractFileRepositoryInformation> Children
        {
            get
            {
                List<AbstractFileRepositoryInformation> children = new List<AbstractFileRepositoryInformation>();
                foreach (var dirInfo in subDirInfos)
                {
                    FileRepositoryFolderConfig config = new FileRepositoryFolderConfig { Name = dirInfo.Name, Path = dirInfo.FullName, Pattern = Config.Pattern };
                    FolderRepositoryInformation folderRepoInfo = new FolderRepositoryInformation(config);
                    children.Add(folderRepoInfo);
                }
                foreach (var fileInfo in fileInfos )
                {
                    FileRepositoryInformation fileRepoInfo = new FileRepositoryInformation(fileInfo);
                    children.Add(fileRepoInfo);
                }
                return children;
            }

            set
            {
                base.Children = value;
            }
        }
    }
}