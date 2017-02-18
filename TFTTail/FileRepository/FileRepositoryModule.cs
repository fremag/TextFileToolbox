using System.Collections.Generic;
using System.Linq;
using WinFwk.UIModules;
using WinFwk.UITools.Settings;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryModule : UIModule
    {
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFolderAdd;
        private System.Windows.Forms.ToolStripButton tsbFolderEdit;
        private WinFwk.UITools.DefaultTreeListView dtlvFileRepository;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripButton tsbFolderDelete;

        List<FolderRepositoryInformation> nodes = new List<FolderRepositoryInformation>();

        public FileRepositoryModule()
        {
            InitializeComponent();
            dtlvFileRepository.InitData<AbstractFileRepositoryInformation>();
            dtlvFileRepository.CheckBoxes = true;
            this.Name = "File Repository";
            this.Text = "File Repository";
            this.Summary = "File Repository";
            this.Icon = Properties.Resources.file_manager_small;
        }
        public override void Init()
        {
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
        }
        #region Designer
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFolderAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderEdit = new System.Windows.Forms.ToolStripButton();
            this.dtlvFileRepository = new WinFwk.UITools.DefaultTreeListView();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFileRepository)).BeginInit();
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
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFolderAdd,
            this.tsbFolderDelete,
            this.tsbFolderEdit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
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
            // 
            // tsbFolderDelete
            // 
            this.tsbFolderDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFolderDelete.Image = global::TFT.Tail.Properties.Resources.folder_delete_small;
            this.tsbFolderDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFolderDelete.Name = "tsbFolderDelete";
            this.tsbFolderDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbFolderDelete.Text = "Delete Folder";
            // 
            // tsbFolderEdit
            // 
            this.tsbFolderEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFolderEdit.Image = global::TFT.Tail.Properties.Resources.folder_edit_small;
            this.tsbFolderEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFolderEdit.Name = "tsbFolderEdit";
            this.tsbFolderEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbFolderEdit.Text = "Edit Folder";
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFileRepository)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
