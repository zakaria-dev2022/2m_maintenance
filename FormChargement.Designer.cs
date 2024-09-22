namespace _2M_Maintenace
{
    partial class FormChargement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progress = new System.Windows.Forms.ProgressBar();
            this.porssentage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.nom_app = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progress
            // 
            this.progress.BackColor = System.Drawing.Color.Aqua;
            this.progress.ForeColor = System.Drawing.Color.Red;
            this.progress.Location = new System.Drawing.Point(154, 487);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(891, 32);
            this.progress.TabIndex = 20;
            // 
            // porssentage
            // 
            this.porssentage.AutoSize = true;
            this.porssentage.Font = new System.Drawing.Font("Arial Narrow", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.porssentage.ForeColor = System.Drawing.Color.Black;
            this.porssentage.Location = new System.Drawing.Point(347, 420);
            this.porssentage.Name = "porssentage";
            this.porssentage.Size = new System.Drawing.Size(38, 37);
            this.porssentage.TabIndex = 19;
            this.porssentage.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(163, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 37);
            this.label2.TabIndex = 18;
            this.label2.Text = "Chargement ";
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(308, 115);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(597, 274);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 17;
            this.logo.TabStop = false;
            // 
            // nom_app
            // 
            this.nom_app.AutoSize = true;
            this.nom_app.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.nom_app.Location = new System.Drawing.Point(445, 46);
            this.nom_app.Name = "nom_app";
            this.nom_app.Size = new System.Drawing.Size(69, 41);
            this.nom_app.TabIndex = 21;
            this.nom_app.Text = "2M";
            // 
            // FormChargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1123, 565);
            this.Controls.Add(this.nom_app);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.porssentage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChargement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChargement";
            this.Load += new System.EventHandler(this.FormChargement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label porssentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label nom_app;
    }
}