using WinFwk.UIModules;
using WinFwk.UITools.Configuration;

namespace TFT.Tail.FileViewer
{
    public partial class FileViewerModule : UIModule, IConfigurableModule
    {
        public FileViewerModule()
        {
            InitializeComponent();
        }

        public void Setup(string filePath)
        {
            Name = filePath;
            Icon = Properties.Resources.table_layout_subtotals_small;
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
}
