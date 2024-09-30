namespace _2M_Maintenace
{
    partial class FormProfil
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.supprimer = new System.Windows.Forms.Button();
            this.tableau = new System.Windows.Forms.DataGridView();
            this.modifier = new System.Windows.Forms.Button();
            this.ajouter = new System.Windows.Forms.Button();
            this.lb_msg = new System.Windows.Forms.Label();
            this.lb_cmp = new System.Windows.Forms.Label();
            this.txtmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtep = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtcmp = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtidp = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtidp);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.supprimer);
            this.panel1.Controls.Add(this.tableau);
            this.panel1.Controls.Add(this.modifier);
            this.panel1.Controls.Add(this.ajouter);
            this.panel1.Controls.Add(this.lb_msg);
            this.panel1.Controls.Add(this.lb_cmp);
            this.panel1.Controls.Add(this.txtmp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtep);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.txtcmp);
            this.panel1.Location = new System.Drawing.Point(214, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 715);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 667);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 48);
            this.panel2.TabIndex = 136;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(41, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 33);
            this.label5.TabIndex = 135;
            this.label5.Text = "Email";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.panel3.Controls.Add(this.exit);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 100);
            this.panel3.TabIndex = 124;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 26F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(149, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 62);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gestion Des Profils";
            // 
            // supprimer
            // 
            this.supprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.supprimer.Enabled = false;
            this.supprimer.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supprimer.ForeColor = System.Drawing.Color.White;
            this.supprimer.Location = new System.Drawing.Point(738, 271);
            this.supprimer.Margin = new System.Windows.Forms.Padding(4);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(194, 44);
            this.supprimer.TabIndex = 133;
            this.supprimer.Text = "Supprimer";
            this.supprimer.UseVisualStyleBackColor = false;
            // 
            // tableau
            // 
            this.tableau.BackgroundColor = System.Drawing.Color.White;
            this.tableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableau.Location = new System.Drawing.Point(78, 445);
            this.tableau.Name = "tableau";
            this.tableau.RowHeadersWidth = 62;
            this.tableau.RowTemplate.Height = 28;
            this.tableau.Size = new System.Drawing.Size(854, 247);
            this.tableau.TabIndex = 131;
            // 
            // modifier
            // 
            this.modifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.modifier.Enabled = false;
            this.modifier.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifier.ForeColor = System.Drawing.Color.White;
            this.modifier.Location = new System.Drawing.Point(738, 140);
            this.modifier.Margin = new System.Windows.Forms.Padding(4);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(194, 44);
            this.modifier.TabIndex = 130;
            this.modifier.Text = "Modifier";
            this.modifier.UseVisualStyleBackColor = false;
            // 
            // ajouter
            // 
            this.ajouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.ajouter.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouter.ForeColor = System.Drawing.Color.White;
            this.ajouter.Location = new System.Drawing.Point(738, 207);
            this.ajouter.Margin = new System.Windows.Forms.Padding(4);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(194, 44);
            this.ajouter.TabIndex = 129;
            this.ajouter.Text = "ajouter";
            this.ajouter.UseVisualStyleBackColor = false;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Font = new System.Drawing.Font("Arial Narrow", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_msg.ForeColor = System.Drawing.Color.Red;
            this.lb_msg.Location = new System.Drawing.Point(363, 215);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(46, 20);
            this.lb_msg.TabIndex = 128;
            this.lb_msg.Text = "label2";
            this.lb_msg.Visible = false;
            // 
            // lb_cmp
            // 
            this.lb_cmp.AutoSize = true;
            this.lb_cmp.BackColor = System.Drawing.Color.White;
            this.lb_cmp.Font = new System.Drawing.Font("Arial Narrow", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lb_cmp.ForeColor = System.Drawing.Color.Black;
            this.lb_cmp.Location = new System.Drawing.Point(41, 233);
            this.lb_cmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_cmp.Name = "lb_cmp";
            this.lb_cmp.Size = new System.Drawing.Size(287, 33);
            this.lb_cmp.TabIndex = 127;
            this.lb_cmp.Text = "Confirmer Mot De Passe ";
            // 
            // txtmp
            // 
            this.txtmp.BackColor = System.Drawing.Color.White;
            this.txtmp.Location = new System.Drawing.Point(344, 187);
            this.txtmp.Multiline = true;
            this.txtmp.Name = "txtmp";
            this.txtmp.Size = new System.Drawing.Size(253, 26);
            this.txtmp.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 33);
            this.label3.TabIndex = 126;
            this.label3.Text = "Mot De Passe";
            // 
            // txtep
            // 
            this.txtep.BackColor = System.Drawing.Color.White;
            this.txtep.Enabled = false;
            this.txtep.Location = new System.Drawing.Point(344, 140);
            this.txtep.Multiline = true;
            this.txtep.Name = "txtep";
            this.txtep.Size = new System.Drawing.Size(253, 26);
            this.txtep.TabIndex = 121;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(383, 139);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(112, 26);
            this.txtid.TabIndex = 132;
            this.txtid.Visible = false;
            // 
            // txtcmp
            // 
            this.txtcmp.BackColor = System.Drawing.Color.White;
            this.txtcmp.Location = new System.Drawing.Point(344, 240);
            this.txtcmp.Multiline = true;
            this.txtcmp.Name = "txtcmp";
            this.txtcmp.Size = new System.Drawing.Size(253, 26);
            this.txtcmp.TabIndex = 123;
            // 
            // exit
            // 
            this.exit.Image = global::_2M_Maintenace.Properties.Resources.back_arrow;
            this.exit.Location = new System.Drawing.Point(906, 28);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(61, 52);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit.TabIndex = 49;
            this.exit.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_2M_Maintenace.Properties.Resources.add_user__1_;
            this.pictureBox2.Location = new System.Drawing.Point(55, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // txtidp
            // 
            this.txtidp.BackColor = System.Drawing.Color.White;
            this.txtidp.Enabled = false;
            this.txtidp.Location = new System.Drawing.Point(430, 140);
            this.txtidp.Multiline = true;
            this.txtidp.Name = "txtidp";
            this.txtidp.Size = new System.Drawing.Size(135, 26);
            this.txtidp.TabIndex = 137;
            this.txtidp.Visible = false;
            // 
            // FormProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1868, 968);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProfil";
            this.Text = "FormProfil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormProfil_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button supprimer;
        private System.Windows.Forms.DataGridView tableau;
        private System.Windows.Forms.Button modifier;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.Label lb_msg;
        private System.Windows.Forms.Label lb_cmp;
        private System.Windows.Forms.TextBox txtmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtep;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtcmp;
        private System.Windows.Forms.TextBox txtidp;
    }
}