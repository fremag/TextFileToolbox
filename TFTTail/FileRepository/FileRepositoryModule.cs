using WinFwk.UIModules;

namespace TFT.Tail.FileRepository
{
    public class FileRepositoryModule : UIModule
    {
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFolderAdd;
        private System.Windows.Forms.ToolStripButton tsbFolderEdit;
        private System.Windows.Forms.ToolStripButton tsbFolderDelete;

        public FileRepositoryModule()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            this.Name = "File Repository";
            this.Text = "File Repository";
            this.Summary = "File Repository";
            this.Icon = Properties.Resources.file_manager_small; 
        }

        private void InitializeComponent()
        {
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFolderAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbFolderEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(809, 610);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(809, 635);
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
            // FileRepositoryModule
            // 
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "FileRepositoryModule";
            this.Size = new System.Drawing.Size(809, 635);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
