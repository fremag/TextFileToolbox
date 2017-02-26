using System;
using System.IO;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryInformation : AbstractFileRepositoryInformation
    {
        FileInfo FileInfo { get; }
        public FileRepositoryInformation(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            Name = fileInfo.Name;
            Icon = Properties.Resources.text_document;
        }

        public override DateTime? CreationDate => FileInfo.CreationTime;
        public override DateTime? ModificationDate => FileInfo.LastWriteTime;
        public override long Size => FileInfo.Length / 1000000;

        public override string Path => FileInfo.FullName;
    }
}
