using System.Windows.Forms;
using BrightIdeasSoftware;
using TFT.Tail.Core;
using WinFwk.UIModules;
using WinFwk.UITools.Configuration;

namespace TFT.Tail.FileViewer
{
    public partial class FileViewerModule : UIModule, IConfigurableModule
    {
        private string FilePath { get; set; }
        private FileIndexer FileIndexer { get; set; }

        public FileViewerModule()
        {
            InitializeComponent();
        }

        public void Setup(string filePath)
        {
            Name = filePath;
            FilePath = filePath;
            Icon = Properties.Resources.table_layout_subtotals_small;
        }

        public override void Init()
        {
            base.Init();
            FileIndexer = new FileIndexer(FilePath);
        }

        public override void PostInit()
        {
            dlvFileViewer.VirtualListDataSource = new FileContentVirtualSource(dlvFileViewer, FileIndexer);
        }
        public IModuleConfig ModuleConfig
        {
            get
            {
                return null;
            }
        }

        public void Apply(IModuleConfig config)
        {
            
        }

        public IModuleConfigEditor CreateEditor()
        {
            return new DefaultModuleConfigEditor();
        }
    }

    public class FileContentVirtualSource : AbstractVirtualListDataSource
    {
        private FileIndexer fileIndexer;

        public FileContentVirtualSource(VirtualObjectListView listView, FileIndexer fileIndexer) : base(listView)
        {
            this.fileIndexer = fileIndexer;

            var colNumLine = new OLVColumn("#", null);
            colNumLine.AspectToStringFormat = "{0:###,###,###,##0}";
            colNumLine.TextAlign = HorizontalAlignment.Right;

            colNumLine.AspectGetter = o => ((object[])o)[0];
            listView.Columns.Add(colNumLine);
            var colText = new OLVColumn("text", null);
            colText.FillsFreeSpace = true;
            colText.AspectGetter = o => ((object[])o)[1];
            listView.Columns.Add(colText);

        }

        public override object GetNthObject(int n)
        {
            var line = fileIndexer.ReadLine(n);
            return new object[] { n, line};
        }

        public override int GetObjectCount()
        {
            return fileIndexer.Count;
        }
    }
}
