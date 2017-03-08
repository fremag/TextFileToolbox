using System.ComponentModel;
using TFT.Tail.Core;
using WinFwk.UITools.Configuration;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryFolderConfig : ModuleConfigAdapter, IIdentifiable
    {
        public enum SortFileByCriteria { Name, CreationDate, ModificationDate, Size}
        public enum SortOrder { Asc, Desc}

        [Browsable(false)]
        public int Id { get; set; }

        [Category("0. Info")]
        public string Name { get; set; }

        [Category("1. Path")]
        [EditorAttribute(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Path { get; set; }
        [Category("1. Path")]
        public string Pattern { get; set; } = "*.*";
        [Category("1. Path")]
        public bool ScanSubDirs { get; set; } = true;


        [Category("2. Display")]
        public SortFileByCriteria SortBy { get; set; } = SortFileByCriteria.Name;
        [Category("2. Display")]
        public SortOrder Order { get; set; } = SortOrder.Asc;
        [Category("2. Display")]
        [DefaultValue(0)]
        public int KeepNFirst { get; set; } = 0;
        [Category("2. Display")]
        [DefaultValue(0)]
        public int KeepNLast { get; set; } = 0;
    }
}