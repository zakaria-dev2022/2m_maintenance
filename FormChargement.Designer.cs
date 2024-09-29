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
            this.panel1 = new System.Windows.Forms.Panel();
            this.nom_app = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.porssentage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.nom_app);
            this.panel1.Controls.Add(this.progress);
            this.panel1.Controls.Add(this.porssentage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.logo);
            this.panel1.Location = new System.Drawing.Point(400, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 565);
            this.panel1.TabIndex = 22;
            // 
            // nom_app
            // 
            this.nom_app.AutoSize = true;
            this.nom_app.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.nom_app.Location = new System.Drawing.Point(254, 88);
            this.nom_app.Name = "nom_app";
            this.nom_app.Size = new System.Drawing.Size(69, 41);
            this.nom_app.TabIndex = 26;
            this.nom_app.Text = "2M";
            // 
            // progress
            // 
            this.progress.BackColor = System.Drawing.Color.Aqua;
            this.progress.ForeColor = System.Drawing.Color.Red;
            this.progress.Location = new System.Drawing.Point(92, 504);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(891, 32);
            this.progress.TabIndex = 25;
            // 
            // porssentage
            // 
            this.porssentage.AutoSize = true;
            this.porssentage.Font = new System.Drawing.Font("Arial Narrow", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.porssentage.ForeColor = System.Drawing.Color.Black;
            this.porssentage.Location = new System.Drawing.Point(285, 437);
            this.porssentage.Name = "porssentage";
            this.porssentage.Size = new System.Drawing.Size(38, 37);
            this.porssentage.TabIndex = 24;
            this.porssentage.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(101, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 37);
            this.label2.TabIndex = 23;
            this.label2.Text = "Chargement ";
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(246, 132);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(597, 274);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 22;
            this.logo.TabStop = false;
            // 
            // FormChargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1946, 1080);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChargement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChargement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormChargement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label nom_app;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label porssentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logo;
    }
}