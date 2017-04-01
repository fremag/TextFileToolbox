namespace LogGenerator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.nudPeriod = new System.Windows.Forms.NumericUpDown();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timerInfo = new System.Windows.Forms.Timer(this.components);
            this.lblErrorPeriod = new System.Windows.Forms.Label();
            this.nudErrorPeriod = new System.Windows.Forms.NumericUpDown();
            this.btnError = new System.Windows.Forms.Button();
            this.timerError = new System.Windows.Forms.Timer(this.components);
            this.btnDebug = new System.Windows.Forms.Button();
            this.lblDebug = new System.Windows.Forms.Label();
            this.nudDebugPeriod = new System.Windows.Forms.NumericUpDown();
            this.timerDebug = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrorPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDebugPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(110, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(279, 20);
            this.tbPath.TabIndex = 0;
            this.tbPath.Text = "E:\\tmp\\logs\\process_{0:yyyyMMdd_HHmmss}.log";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Path:";
            // 
            // nudPeriod
            // 
            this.nudPeriod.Location = new System.Drawing.Point(110, 38);
            this.nudPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPeriod.Name = "nudPeriod";
            this.nudPeriod.Size = new System.Drawing.Size(120, 20);
            this.nudPeriod.TabIndex = 2;
            this.nudPeriod.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(12, 40);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(83, 13);
            this.lblPeriod.TabIndex = 3;
            this.lblPeriod.Text = "Info Period (ms):";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(256, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblErrorPeriod
            // 
            this.lblErrorPeriod.AutoSize = true;
            this.lblErrorPeriod.Location = new System.Drawing.Point(12, 66);
            this.lblErrorPeriod.Name = "lblErrorPeriod";
            this.lblErrorPeriod.Size = new System.Drawing.Size(87, 13);
            this.lblErrorPeriod.TabIndex = 6;
            this.lblErrorPeriod.Text = "Error Period (ms):";
            // 
            // nudErrorPeriod
            // 
            this.nudErrorPeriod.Location = new System.Drawing.Point(110, 64);
            this.nudErrorPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudErrorPeriod.Name = "nudErrorPeriod";
            this.nudErrorPeriod.Size = new System.Drawing.Size(120, 20);
            this.nudErrorPeriod.TabIndex = 5;
            this.nudErrorPeriod.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(256, 61);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(75, 23);
            this.btnError.TabIndex = 7;
            this.btnError.Text = "Error";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(256, 87);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 10;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(12, 92);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(97, 13);
            this.lblDebug.TabIndex = 9;
            this.lblDebug.Text = "Debug Period (ms):";
            // 
            // nudDebugPeriod
            // 
            this.nudDebugPeriod.Location = new System.Drawing.Point(110, 90);
            this.nudDebugPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDebugPeriod.Name = "nudDebugPeriod";
            this.nudDebugPeriod.Size = new System.Drawing.Size(120, 20);
            this.nudDebugPeriod.TabIndex = 8;
            this.nudDebugPeriod.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(337, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(329, 129);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 298);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.nudDebugPeriod);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.lblErrorPeriod);
            this.Controls.Add(this.nudErrorPeriod);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.nudPeriod);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.tbPath);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrorPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDebugPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.NumericUpDown nudPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timerInfo;
        private System.Windows.Forms.Label lblErrorPeriod;
        private System.Windows.Forms.NumericUpDown nudErrorPeriod;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Timer timerError;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.NumericUpDown nudDebugPeriod;
        private System.Windows.Forms.Timer timerDebug;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnDelete;
    }
}

