using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TFT.Tail.FileViewer;
using WinFwk.UICommands;
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
        , IMessageListener<CreateRepositoryFolderRequest>
        , UIDataProvider<DisplayFilesRequest>
    {
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFolderAdd;
        private System.Windows.Forms.ToolStripButton tsbFolderEdit;
        private WinFwk.UITools.DefaultTreeListView dtlvFileRepository;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripButton tsbFolderDelete;
        private System.Windows.Forms.ToolStripButton tsbOpenInExplorer;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDisplayFiles;
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFolderAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenInExplorer = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbDisplayFiles = new System.Windows.Forms.ToolStripButton();
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
            this.dtlvFileRepository.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dtlvFileRepository_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFolderAdd,
            this.tsbFolderDelete,
            this.tsbFolderEdit,
            this.toolStripSeparator2,
            this.tsbOpenInExplorer,
            this.tsbRefresh,
            this.toolStripSeparator1,
            this.tsbDisplayFiles});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(162, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // tsbOpenInExplorer
            // 
            this.tsbOpenInExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenInExplorer.Image = global::TFT.Tail.Properties.Resources.folder_explorer;
            this.tsbOpenInExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenInExplorer.Name = "tsbOpenInExplorer";
            this.tsbOpenInExplorer.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenInExplorer.Text = "toolStripButton1";
            this.tsbOpenInExplorer.ToolTipText = "Open Folder in Explorer";
            this.tsbOpenInExplorer.Click += new System.EventHandler(this.tsbOpenInExplorer_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::TFT.Tail.Properties.Resources.arrow_refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "toolStripButton2";
            this.tsbRefresh.ToolTipText = "Refresh Repository";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbDisplayFiles
            // 
            this.tsbDisplayFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisplayFiles.Image = global::TFT.Tail.Properties.Resources.document_inspect_small;
            this.tsbDisplayFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisplayFiles.Name = "tsbDisplayFiles";
            this.tsbDisplayFiles.Size = new System.Drawing.Size(23, 22);
            this.tsbDisplayFiles.Text = "toolStripButton1";
            this.tsbDisplayFiles.ToolTipText = "Display checked files...";
            this.tsbDisplayFiles.Click += new System.EventHandler(this.tsbDisplayFiles_Click);
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
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if( dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FileRepositoryFolderConfig folderConfig = TailSettings.Instance.Create< FileRepositoryFolderConfig>();
            folderConfig.Path = dialog.SelectedPath;
            folderConfig.Name = folderConfig.Path;
            AddFolder(folderConfig);
        }

        private void AddFolder(FileRepositoryFolderConfig folderConfig)
        {
            var folderConfigs = TailSettings.Instance.FileRepositoryFolderConfigs;
            folderConfigs.Add(folderConfig);
            FolderRepositoryInformation info = new FolderRepositoryInformation(folderConfig);
            TailSettings.Instance.Save();
            Init();
            PostInit();
            MessageBus.SendMessage(new OpenModuleConfigurationEditorRequest(this, folderConfig));
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
            TailSettings.Instance.Save();
            Init();
            PostInit();
        }

        private void tsbFolderEdit_Click(object sender, System.EventArgs e)
        {
            if (ModuleConfig != null)
            {
                MessageBus.SendMessage(new OpenModuleConfigurationEditorRequest(this, ModuleConfig));
            }
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
            TailSettings.Instance.Save();
            Init();
            PostInit();
        }

        public IModuleConfigEditor CreateEditor()
        {
            return new DefaultModuleConfigEditor();
        }

        private void tsbOpenInExplorer_Click(object sender, System.EventArgs e)
        {
            var selected = dtlvFileRepository.SelectedObject as FolderRepositoryInformation;
            if(selected == null)
            {
                Log("No folder is selected !", LogLevelType.Error);
                return;
            }

            if (string.IsNullOrEmpty(selected.Path))
            {
                Log("No folder is selected !", LogLevelType.Error);
                return;
            }

            if ( ! Directory.Exists(selected.Path))
            {
                Log($"Folder '{0:selected.Path}' doesn't exists !", LogLevelType.Error);
                return;
            }
            try
            {
                Process.Start(selected.Path);
            }
            catch (Exception ex)
            {
                Log($"Can't open selected path: {0:selected.Path}", ex);
            }
        }

        private void tsbRefresh_Click(object sender, System.EventArgs e)
        {
            Init();
            PostInit();
        }

        public void HandleMessage(CreateRepositoryFolderRequest message)
        {
            FileRepositoryFolderConfig folderConfig = TailSettings.Instance.Create<FileRepositoryFolderConfig>();
            folderConfig.Name = message.Path;
            folderConfig.Path = message.Path;
            folderConfig.Pattern= message.Pattern;

            AddFolder(folderConfig);
        }


        public DisplayFilesRequest Data
        {
            get
            {
                var paths = dtlvFileRepository.CheckedObjects.OfType<FileRepositoryInformation>().Select(info => info.Path);
                DisplayFilesRequest displayFilesRequest = new DisplayFilesRequest(paths);
                return displayFilesRequest;
            }
        }

        private void tsbDisplayFiles_Click(object sender, EventArgs e)
        {
            DisplayFilesRequest displayFilesRequest = Data;
            MessageBus.SendMessage(displayFilesRequest);
        }

        private void dtlvFileRepository_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if( e.ClickCount != 2)
            {
                return;
            }

            var lineItem = dtlvFileRepository.SelectedItem?.RowObject;
            FileRepositoryInformation info = lineItem as FileRepositoryInformation;
            if( info == null)
            {
                return;
            }

            DisplayFilesRequest displayFilesRequest = new DisplayFilesRequest(new[] { info.Path });
            MessageBus.SendMessage(displayFilesRequest);
        }
    }
}
