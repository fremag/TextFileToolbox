﻿namespace TFT.Tail
{
    partial class TFT_TailForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TFT_TailForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 924);
            this.Name = "TFT_TailForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TFT_TailForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MemoScopeForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MemoScopeForm_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

