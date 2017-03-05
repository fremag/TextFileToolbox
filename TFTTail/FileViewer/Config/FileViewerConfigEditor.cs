using WinFwk.UITools.Configuration;
using System.Windows.Forms;
using System.Linq;
using WinFwk.UITools;
using System.Drawing;
using BrightIdeasSoftware;
using System.Collections.Generic;
using System;

namespace TFT.Tail.FileViewer.Config
{
    public partial class FileViewerConfigEditor : UserControl, IModuleConfigEditor
    {
        public IEnumerable<IEditorAction> EditorActions { get; }
        public IConfigurableModule OwnerModule {get; set; }

        public FileViewerConfigEditor()
        {
            InitializeComponent();
            dtlvConfigs.InitData<AbstractFileViewerConfigInformation>();

            EditorActions = new[]
            {
                new DefaultEditorAction("New", Properties.Resources.plus_button_small, CreateNewConfiguration),
                new DefaultEditorAction("Save", Properties.Resources.diskette_small, TailSettings.Instance.Save)
            };
        }

        public IModuleConfig ModuleConfig
        {
            get
            {
                return null;
            }
        }

        private void CreateNewConfiguration()
        {
            var config = TailSettings.Instance.Create<FileViewerConfig>();
            config.Name = "New Configuration";
            TailSettings.Instance.FileViewerConfigs.Add(config);
            Init(config);
        }

        public void Init(IModuleConfig moduleConfig)
        {
            var configs = TailSettings.Instance.FileViewerConfigs;
            dtlvConfigs.Roots = configs.Select(config => new FileViewerConfigInformation(config));
        }
        

        private void dtlvConfigs_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {

        }

        private void dtlvConfigs_SelectionChanged(object sender, EventArgs e)
        {
            var selected = dtlvConfigs.SelectedObject as AbstractFileViewerConfigInformation;
            if(selected == null)
            {
                return;
            }
            propertyGrid1.SelectedObject = selected.Data;
        }
    }

    public abstract class AbstractFileViewerConfigInformation : TreeNodeInformationAdapter<AbstractFileViewerConfigInformation>
    {
        [OLVColumn(Width = 250, ImageAspectName = nameof(Icon))]
        public virtual string Name { get; }
        [OLVColumn(Width = 500)]
        public virtual string Description{ get; }

        public Image Icon { get; protected set; }

        public object Data { get; }

        public AbstractFileViewerConfigInformation(object data)
        {
            Data = data;
        }
    }

    public class FileViewerConfigInformation : AbstractFileViewerConfigInformation
    {
        FileViewerConfig FileViewerConfig;
        public FileViewerConfigInformation(FileViewerConfig config) : base(config)
        {
            FileViewerConfig = config;
        }

        public override string Name => FileViewerConfig.Name;
        public override string Description => $"Filters: {FileViewerConfig.Filters.Count}";
    }
}
