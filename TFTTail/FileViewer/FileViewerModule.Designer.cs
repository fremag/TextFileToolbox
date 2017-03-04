namespace TFT.Tail.FileViewer
{
    partial class FileViewerModule
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
            this.dlvFileViewer = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvFileViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvFileViewer
            // 
            this.dlvFileViewer.CellEditUseWholeCell = false;
            this.dlvFileViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvFileViewer.FullRowSelect = true;
            this.dlvFileViewer.HideSelection = false;
            this.dlvFileViewer.Location = new System.Drawing.Point(0, 0);
            this.dlvFileViewer.Name = "dlvFileViewer";
            this.dlvFileViewer.ShowGroups = false;
            this.dlvFileViewer.ShowImagesOnSubItems = true;
            this.dlvFileViewer.Size = new System.Drawing.Size(281, 352);
            this.dlvFileViewer.TabIndex = 0;
            this.dlvFileViewer.UseCompatibleStateImageBehavior = false;
            this.dlvFileViewer.View = System.Windows.Forms.View.Details;
            this.dlvFileViewer.VirtualMode = true;
            // 
            // FileViewerModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvFileViewer);
            this.Name = "FileViewerModule";
            this.Size = new System.Drawing.Size(281, 352);
            ((System.ComponentModel.ISupportInitialize)(this.dlvFileViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvFileViewer;
    }
}
