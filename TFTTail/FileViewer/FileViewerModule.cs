using System;
using TFT.Tail.Core;
using TFT.Tail.FileViewer.Config;
using WinFwk.UIModules;
using WinFwk.UITools.Configuration;

namespace TFT.Tail.FileViewer
{
    public partial class FileViewerModule : UIModule, IConfigurableModule
    {
        private string FilePath { get; set; }
        private FileIndexer FileIndexer { get; set; }
        DefaultFileViewerModel defaultFileViewerModel;

        public FileViewerConfig FileViewerConfig { get; private set; }
        public IModuleConfig ModuleConfig {
            get
            {
                if (FileViewerConfig == null)
                {
                    FileViewerConfig = TailSettings.Instance.Create<FileViewerConfig>();
                }
                return FileViewerConfig;
            }
        }

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
            var filters = FileViewerConfig?.Filters;
            var filterMode = FileViewerConfig?.FilterMode ?? FilterMode.KeepIfMatch;
            FileIndexer = new FileIndexer(FilePath, filters, filterMode);
        }

        public override void PostInit()
        {
            ResetTable();
            StartTimer();
        }

        private void StartTimer()
        {
            timer1.Start();
        }

        private void ResetTable()
        {
            dlvFileViewer.Columns.Clear();
            defaultFileViewerModel = new DefaultFileViewerModel(dlvFileViewer, FileIndexer);
            dlvFileViewer.VirtualListDataSource = defaultFileViewerModel;
        }

        public void Apply(IModuleConfig config)
        {
            FileViewerConfig = config as FileViewerConfig;
            if (config != null)
            {
                TailSettings.Instance.UpdateFileViewerConfig(FileViewerConfig);
            }
            Init();
            ResetTable();
        }

        public IModuleConfigEditor CreateEditor()
        {
            var editor = new FileViewerConfigEditor();
            return editor;
        }

        public void RefreshFileViewer()
        {
            FileIndexer.Refresh();
            dlvFileViewer.UpdateVirtualListSize();
            ScrollToBottom();
        }

        public void ScrollToBottom()
        {
            dlvFileViewer.EnsureVisible(dlvFileViewer.GetItemCount()-1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshFileViewer();
        }

        public void Start()
        {
            timer1.Enabled = true;
        }

        public void Stop()
        {
            timer1.Enabled = false;
        }
    }
}
