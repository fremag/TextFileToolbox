namespace TFT.Tail.FileViewer.Config
{
    partial class FileViewerConfigEditor
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtlvConfigs = new WinFwk.UITools.DefaultTreeListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvConfigs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtlvConfigs
            // 
            this.dtlvConfigs.CellEditUseWholeCell = false;
            this.dtlvConfigs.CheckBoxes = true;
            this.dtlvConfigs.DataSource = null;
            this.dtlvConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtlvConfigs.FullRowSelect = true;
            this.dtlvConfigs.HideSelection = false;
            this.dtlvConfigs.Location = new System.Drawing.Point(0, 0);
            this.dtlvConfigs.Name = "dtlvConfigs";
            this.dtlvConfigs.RootKeyValueString = "";
            this.dtlvConfigs.ShowGroups = false;
            this.dtlvConfigs.ShowImagesOnSubItems = true;
            this.dtlvConfigs.Size = new System.Drawing.Size(755, 251);
            this.dtlvConfigs.TabIndex = 0;
            this.dtlvConfigs.UseCompatibleStateImageBehavior = false;
            this.dtlvConfigs.View = System.Windows.Forms.View.Details;
            this.dtlvConfigs.VirtualMode = true;
            this.dtlvConfigs.SelectionChanged += new System.EventHandler(this.dtlvConfigs_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtlvConfigs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(755, 673);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 1;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(755, 418);
            this.propertyGrid1.TabIndex = 0;
            // 
            // FileViewerConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FileViewerConfigEditor";
            this.Size = new System.Drawing.Size(755, 673);
            ((System.ComponentModel.ISupportInitialize)(this.dtlvConfigs)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultTreeListView dtlvConfigs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}
