namespace _2M_Maintenace
{
    partial class FormMembre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txts = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtt = new System.Windows.Forms.MaskedTextBox();
            this.chkF = new System.Windows.Forms.CheckBox();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.txtd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.importer = new System.Windows.Forms.Button();
            this.tableau = new System.Windows.Forms.DataGridView();
            this.supprimer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtgm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ajouter = new System.Windows.Forms.Button();
            this.txtp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.precedent = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chercher = new System.Windows.Forms.Button();
            this.modifier = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lb_profil = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precedent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // txts
            // 
            this.txts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txts.FormattingEnabled = true;
            this.txts.Items.AddRange(new object[] {
            "Montage",
            "Réseaux Informatique",
            "Mécanique"});
            this.txts.Location = new System.Drawing.Point(355, 470);
            this.txts.Name = "txts";
            this.txts.Size = new System.Drawing.Size(281, 28);
            this.txts.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(91, 469);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 33);
            this.label9.TabIndex = 101;
            this.label9.Text = "Spécialité";
            // 
            // txtt
            // 
            this.txtt.Location = new System.Drawing.Point(352, 320);
            this.txtt.Mask = "00 00 00 00 00";
            this.txtt.Name = "txtt";
            this.txtt.Size = new System.Drawing.Size(283, 26);
            this.txtt.TabIndex = 79;
            this.txtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkF
            // 
            this.chkF.AutoSize = true;
            this.chkF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkF.Location = new System.Drawing.Point(526, 520);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(110, 28);
            this.chkF.TabIndex = 82;
            this.chkF.Text = "Feminin";
            this.chkF.UseVisualStyleBackColor = true;
            // 
            // chkM
            // 
            this.chkM.AutoSize = true;
            this.chkM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkM.Location = new System.Drawing.Point(369, 520);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(120, 28);
            this.chkM.TabIndex = 81;
            this.chkM.Text = "Masculin";
            this.chkM.UseVisualStyleBackColor = true;
            // 
            // txtd
            // 
            this.txtd.Location = new System.Drawing.Point(355, 570);
            this.txtd.Name = "txtd";
            this.txtd.Size = new System.Drawing.Size(280, 26);
            this.txtd.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(91, 562);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 33);
            this.label6.TabIndex = 98;
            this.label6.Text = "Date Naissance";
            // 
            // txtc
            // 
            this.txtc.Location = new System.Drawing.Point(354, 370);
            this.txtc.Name = "txtc";
            this.txtc.Size = new System.Drawing.Size(281, 26);
            this.txtc.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(91, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 33);
            this.label7.TabIndex = 97;
            this.label7.Text = "Cin";
            // 
            // importer
            // 
            this.importer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(237)))), ((int)(((byte)(251)))));
            this.importer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.importer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.importer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importer.ForeColor = System.Drawing.Color.Black;
            this.importer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importer.Location = new System.Drawing.Point(944, 522);
            this.importer.Name = "importer";
            this.importer.Size = new System.Drawing.Size(300, 70);
            this.importer.TabIndex = 84;
            this.importer.Text = "Profil";
            this.importer.UseVisualStyleBackColor = false;
            this.importer.Click += new System.EventHandler(this.importer_Click);
            // 
            // tableau
            // 
            this.tableau.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.tableau.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableau.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableau.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableau.EnableHeadersVisualStyles = false;
            this.tableau.Location = new System.Drawing.Point(0, 713);
            this.tableau.Name = "tableau";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableau.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableau.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableau.RowTemplate.Height = 28;
            this.tableau.Size = new System.Drawing.Size(1898, 311);
            this.tableau.TabIndex = 95;
            this.tableau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableau_CellClick);
            // 
            // supprimer
            // 
            this.supprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(66)))), ((int)(((byte)(53)))));
            this.supprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.supprimer.Enabled = false;
            this.supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.supprimer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supprimer.ForeColor = System.Drawing.Color.White;
            this.supprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supprimer.Location = new System.Drawing.Point(1315, 344);
            this.supprimer.Name = "supprimer";
            this.supprimer.Size = new System.Drawing.Size(300, 70);
            this.supprimer.TabIndex = 86;
            this.supprimer.Text = "Supprimer";
            this.supprimer.UseVisualStyleBackColor = false;
            this.supprimer.Click += new System.EventHandler(this.supprimer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(92, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 33);
            this.label5.TabIndex = 94;
            this.label5.Text = "Genre";
            // 
            // txtgm
            // 
            this.txtgm.Location = new System.Drawing.Point(355, 420);
            this.txtgm.Name = "txtgm";
            this.txtgm.Size = new System.Drawing.Size(281, 26);
            this.txtgm.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(92, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 33);
            this.label4.TabIndex = 93;
            this.label4.Text = "Gmail";
            // 
            // ajouter
            // 
            this.ajouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(54)))));
            this.ajouter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ajouter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouter.ForeColor = System.Drawing.Color.White;
            this.ajouter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ajouter.Location = new System.Drawing.Point(1315, 251);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(300, 70);
            this.ajouter.TabIndex = 85;
            this.ajouter.Text = "Ajouter";
            this.ajouter.UseVisualStyleBackColor = false;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // txtp
            // 
            this.txtp.Location = new System.Drawing.Point(354, 270);
            this.txtp.Name = "txtp";
            this.txtp.Size = new System.Drawing.Size(281, 26);
            this.txtp.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(91, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 33);
            this.label2.TabIndex = 91;
            this.label2.Text = "Prénom";
            // 
            // txtn
            // 
            this.txtn.Location = new System.Drawing.Point(354, 219);
            this.txtn.Name = "txtn";
            this.txtn.Size = new System.Drawing.Size(281, 26);
            this.txtn.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(91, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 33);
            this.label1.TabIndex = 90;
            this.label1.Text = "Nom";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.panel1.Controls.Add(this.precedent);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1898, 164);
            this.panel1.TabIndex = 89;
            // 
            // precedent
            // 
            this.precedent.Image = global::_2M_Maintenace.Properties.Resources.back_arrow;
            this.precedent.Location = new System.Drawing.Point(1820, 60);
            this.precedent.Name = "precedent";
            this.precedent.Size = new System.Drawing.Size(77, 54);
            this.precedent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.precedent.TabIndex = 50;
            this.precedent.TabStop = false;
            this.precedent.Click += new System.EventHandler(this.precedent_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_2M_Maintenace.Properties.Resources.customer__3_;
            this.pictureBox2.Location = new System.Drawing.Point(30, 40);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 49;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(147)))));
            this.label8.Font = new System.Drawing.Font("Arial Black", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(169, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(628, 70);
            this.label8.TabIndex = 48;
            this.label8.Text = "Gestion Des Membres";
            // 
            // chercher
            // 
            this.chercher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(203)))), ((int)(((byte)(209)))));
            this.chercher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chercher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chercher.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chercher.ForeColor = System.Drawing.Color.White;
            this.chercher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chercher.Location = new System.Drawing.Point(1315, 525);
            this.chercher.Name = "chercher";
            this.chercher.Size = new System.Drawing.Size(300, 70);
            this.chercher.TabIndex = 88;
            this.chercher.Text = "Chercher";
            this.chercher.UseVisualStyleBackColor = false;
            this.chercher.Click += new System.EventHandler(this.chercher_Click);
            // 
            // modifier
            // 
            this.modifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(255)))));
            this.modifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modifier.Enabled = false;
            this.modifier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.modifier.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifier.ForeColor = System.Drawing.Color.White;
            this.modifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modifier.Location = new System.Drawing.Point(1315, 435);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(300, 70);
            this.modifier.TabIndex = 87;
            this.modifier.Text = "Modifier";
            this.modifier.UseVisualStyleBackColor = false;
            this.modifier.Click += new System.EventHandler(this.modifier_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(91, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 33);
            this.label3.TabIndex = 92;
            this.label3.Text = "Tel";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(491, 219);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(136, 26);
            this.txtid.TabIndex = 100;
            this.txtid.Visible = false;
            // 
            // lb_profil
            // 
            this.lb_profil.AutoSize = true;
            this.lb_profil.Location = new System.Drawing.Point(1172, 518);
            this.lb_profil.Name = "lb_profil";
            this.lb_profil.Size = new System.Drawing.Size(64, 20);
            this.lb_profil.TabIndex = 99;
            this.lb_profil.Text = "lb_profil";
            this.lb_profil.Visible = false;
            // 
            // picture
            // 
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Location = new System.Drawing.Point(944, 251);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(300, 243);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 96;
            this.picture.TabStop = false;
            // 
            // FormMembre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.txts);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtt);
            this.Controls.Add(this.chkF);
            this.Controls.Add(this.chkM);
            this.Controls.Add(this.txtd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.importer);
            this.Controls.Add(this.tableau);
            this.Controls.Add(this.supprimer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtgm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.ajouter);
            this.Controls.Add(this.txtp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chercher);
            this.Controls.Add(this.modifier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lb_profil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMembre";
            this.Text = "FormMembre";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMembre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableau)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precedent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox precedent;
        private System.Windows.Forms.ComboBox txts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MaskedTextBox txtt;
        private System.Windows.Forms.CheckBox chkF;
        private System.Windows.Forms.CheckBox chkM;
        private System.Windows.Forms.DateTimePicker txtd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button importer;
        private System.Windows.Forms.DataGridView tableau;
        private System.Windows.Forms.Button supprimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtgm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.TextBox txtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button chercher;
        private System.Windows.Forms.Button modifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lb_profil;
    }
}