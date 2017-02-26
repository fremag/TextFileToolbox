using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TFT.Tail.FileRepository
{
    public class FolderRepositoryInformation : AbstractFileRepositoryInformation
    {
        public FileRepositoryFolderConfig Config { get; private set; }
        DirectoryInfo dirInfo;
        FileInfo[] fileInfos;
        DirectoryInfo[] subDirInfos;

        public FolderRepositoryInformation(FileRepositoryFolderConfig config)
        {
            Icon = Properties.Resources.folder_small;
            Init(config);
        }

        public override DateTime? ModificationDate => dirInfo == null ? default(DateTime?) : dirInfo.LastWriteTime;
        public override DateTime? CreationDate => dirInfo == null ? default(DateTime?) : dirInfo.CreationTime;
        public override long Size => fileInfos == null ? -1 : fileInfos.Length;
        public override bool CanExpand => (fileInfos != null && fileInfos.Any()) || (subDirInfos != null && subDirInfos.Any());
        public override string Path => dirInfo?.FullName;

        public void Init(FileRepositoryFolderConfig config)
        {
            Config = config;
            Name = config.Name;
            if (!string.IsNullOrEmpty(Config.Path))
            {
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
                    try
                    {
                        fileInfos = dirInfo.GetFiles(Config.Pattern);
                        subDirInfos = dirInfo.GetDirectories();
                    }
                    catch (Exception e)
                    {
                        Icon = Properties.Resources.folder_error;
                        Tooltip = $"Can't find files: {e.Message}";
                        dirInfo = null;
                    }
                }
            }
            else
            {
                Icon = Properties.Resources.folder_error;
                Tooltip = $"Path is empty or null !";
                dirInfo = null;
            }
        }

        public override List<AbstractFileRepositoryInformation> Children
        {
            get
            {
                List<AbstractFileRepositoryInformation> children = new List<AbstractFileRepositoryInformation>();
                if (Config.ScanSubDirs)
                {
                    foreach (var dirInfo in subDirInfos)
                    {
                        FileRepositoryFolderConfig config = new FileRepositoryFolderConfig { Name = dirInfo.Name, Path = dirInfo.FullName, Pattern = Config.Pattern };
                        FolderRepositoryInformation folderRepoInfo = new FolderRepositoryInformation(config);
                        children.Add(folderRepoInfo);
                    }
                }
                var files = fileInfos.Select(fileInfo => new FileRepositoryInformation(fileInfo));
                files = Sort(files);
                if( Config.KeepNFirst != 0)
                {
                    files = files.Take(Config.KeepNFirst);
                }
                if (Config.KeepNLast != 0) {
                    files = files.Skip(fileInfos.Length- Config.KeepNLast);
                }
                children.AddRange(files);
                return children;
            }

            set
            {
                base.Children = value;
            }
        }

        private IEnumerable<FileRepositoryInformation> Sort(IEnumerable<FileRepositoryInformation> files)
        {
            Func<FileRepositoryInformation, object> lambda;
            switch (Config.SortBy)
            {
                case FileRepositoryFolderConfig.SortFileByCriteria.Name:
                    lambda = info => info.Name;
                    break;
                case FileRepositoryFolderConfig.SortFileByCriteria.Size:
                    lambda = info => info.Size;
                    break;
                case FileRepositoryFolderConfig.SortFileByCriteria.CreationDate:
                    lambda = info => info.CreationDate;
                    break;
                case FileRepositoryFolderConfig.SortFileByCriteria.ModificationDate:
                    lambda = info => info.ModificationDate;
                    break;
                default:
                    return files;
            }

            switch(Config.Order)
            {
                case FileRepositoryFolderConfig.SortOrder.Asc:
                    return files.OrderBy(lambda);
                case FileRepositoryFolderConfig.SortOrder.Desc:
                    return files.OrderByDescending(lambda);
            }

            return files;
        }
    }
}
