using System.Collections.Generic;
using System.Linq;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UITools.Configuration;
using WinFwk.UITools.Log;
using WinFwk.UITools.Settings;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryModule : UIModule
        , IConfigurableModule
        , IMessageListener<UISettingsChangedMessage> 
    {
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFolderAdd;
        private System.Windows.Forms.ToolStripButton tsbFolderEdit;
        private WinFwk.UITools.DefaultTreeListView dtlvFileRepository;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripButton tsbFolderDelete;

        List<FolderRepositoryInformation> nodes = new List<FolderRepositoryInformation>();

        public IModuleConfig ModuleConfig
        {
            get
            {
                var selected = dtlvFileRepository.SelectedObject as FolderRepositoryInformation;

                if(selected == null || ! nodes.Contains(selected))
                {
                    return null;
                }

                return selected.Config;
            }
        }

        public FileRepositoryModule()
        {
            InitializeComponent();
            dtlvFileRepository.InitData<AbstractFileRepositoryInformation>();
            dtlvFileRepository.CheckBoxes = true;
            Name = "File Repository";
            Text = "File Repository";
            Summary = "File Repository";
            Icon = Properties.Resources.file_manager_small;
            tsbFolderEdit.Image = RunConfigEditorCommand.SmallIcon;
        }

        public override void Init()
        {
            nodes.Clear();
            var folderConfigs = TailSettings.Instance.FileRepositoryFolderConfigs;
            if(folderConfigs == null || !folderConfigs.Any())
            {
                return;
            }
            foreach (var folderConfig in folderConfigs)
            {
                folderConfig.OwnerModule = this;
                FolderRepositoryInformation info = new FolderRepositoryInformation(folderConfig);
                nodes.Add(info);
            }
        }

        public override void PostInit()
        {
            base.PostInit();
            dtlvFileRepository.Roots = nodes;
            dtlvFileRepository.RebuildAll(true);
        }
        #region Designer
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dtlvFileRepository = new WinFwk.UITools.DefaultTreeListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFolderAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFileRepository)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dtlvFileRepository);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(290, 610);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(290, 635);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // dtlvFileRepository
            // 
            this.dtlvFileRepository.CellEditUseWholeCell = false;
            this.dtlvFileRepository.DataSource = null;
            this.dtlvFileRepository.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtlvFileRepository.FullRowSelect = true;
            this.dtlvFileRepository.HideSelection = false;
            this.dtlvFileRepository.Location = new System.Drawing.Point(0, 0);
            this.dtlvFileRepository.Name = "dtlvFileRepository";
            this.dtlvFileRepository.RootKeyValueString = "";
            this.dtlvFileRepository.ShowGroups = false;
            this.dtlvFileRepository.ShowImagesOnSubItems = true;
            this.dtlvFileRepository.Size = new System.Drawing.Size(290, 610);
            this.dtlvFileRepository.TabIndex = 0;
            this.dtlvFileRepository.UseCompatibleStateImageBehavior = false;
            this.dtlvFileRepository.View = System.Windows.Forms.View.Details;
            this.dtlvFileRepository.VirtualMode = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFolderAdd,
            this.tsbFolderDelete,
            this.tsbFolderEdit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(112, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbFolderAdd
            // 
            this.tsbFolderAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFolderAdd.Image = global::TFT.Tail.Properties.Resources.folder_add_small;
            this.tsbFolderAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFolderAdd.Name = "tsbFolderAdd";
            this.tsbFolderAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbFolderAdd.Text = "Add Folder";
            this.tsbFolderAdd.Click += new System.EventHandler(this.tsbFolderAdd_Click);
            // 
            // tsbFolderDelete
            // 
            this.tsbFolderDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFolderDelete.Image = global::TFT.Tail.Properties.Resources.folder_delete_small;
            this.tsbFolderDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFolderDelete.Name = "tsbFolderDelete";
            this.tsbFolderDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbFolderDelete.Text = "Delete Checked Folder";
            this.tsbFolderDelete.Click += new System.EventHandler(this.tsbFolderDelete_Click);
            // 
            // tsbFolderEdit
            // 
            this.tsbFolderEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFolderEdit.Image = global::TFT.Tail.Properties.Resources.folder_edit_small;
            this.tsbFolderEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFolderEdit.Name = "tsbFolderEdit";
            this.tsbFolderEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbFolderEdit.Text = "Edit Folder";
            this.tsbFolderEdit.Click += new System.EventHandler(this.tsbFolderEdit_Click);
            // 
            // FileRepositoryModule
            // 
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "FileRepositoryModule";
            this.Size = new System.Drawing.Size(290, 635);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFileRepository)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void tsbFolderAdd_Click(object sender, System.EventArgs e)
        {
            var folderConfigs = TailSettings.Instance.FileRepositoryFolderConfigs;
            FileRepositoryFolderConfig folderConfig = TailSettings.Instance.CreateFileRepositoryFolderConfig();
            folderConfig.OwnerModule = this;
            folderConfigs.Add(folderConfig);
            FolderRepositoryInformation info = new FolderRepositoryInformation(folderConfig);
            UISettingsMgr<TailSettings>.Save(TailSettings.Instance);
            Init();
            PostInit();
            RunConfigEditorCommand.RunConfigEditor(this, MessageBus, folderConfig);
        }

        private void tsbFolderDelete_Click(object sender, System.EventArgs e)
        {
            var folders = dtlvFileRepository.CheckedObjects.OfType<FolderRepositoryInformation>();
            if(folders == null || ! folders.Any())
            {
                Log("Can't remove folders: nothing is checked !", LogLevelType.Error);
            }
            var folderConfigs = TailSettings.Instance.FileRepositoryFolderConfigs;
            foreach (var folder in folders)
            {
                var folderConfig = folder.Config;
                folderConfigs.Remove(folderConfig);
            }
            UISettingsMgr<TailSettings>.Save(TailSettings.Instance);
            Init();
            PostInit();
        }

        private void tsbFolderEdit_Click(object sender, System.EventArgs e)
        {
            RunConfigEditorCommand.RunConfigEditor(this, MessageBus);
        }

        public void HandleMessage(UISettingsChangedMessage message)
        {
            Init();
            PostInit();
        }

        public void Apply(IModuleConfig config)
        {
            FileRepositoryFolderConfig folderConfig = config as FileRepositoryFolderConfig;
            if( folderConfig == null)
            {
                return;
            }
            TailSettings.Instance.UpdateFileRepositoryFolderConfig(folderConfig);
            UISettingsMgr<TailSettings>.Save(TailSettings.Instance);
            Init();
            PostInit();
        }

        public IModuleConfigEditor CreateEditor()
        {
            return new DefaultModuleConfigEditor();
        }

    }
}
