using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        string chemin = "";
        void remplir()
        {

            Utils.OpenConnection();

            string query = "select * from admin where id= 1";
            MySqlCommand command = new MySqlCommand(query, Utils.cnx);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    txtn.Text = reader[1].ToString();
                    txtp.Text = reader[2].ToString();
                    txte.Text = reader[3].ToString();
                    txtmp.Text = reader[4].ToString();
                    txtna.Text = reader[5].ToString();
                    lb_logo.Text = reader[6].ToString();
                }
                Utils.CloseConnection();
                //reader.Close();

                string photoPath = AppDomain.CurrentDomain.BaseDirectory + @"img\" + lb_logo.Text;
                try
                {
                    if (!string.IsNullOrWhiteSpace(lb_logo.Text) && System.IO.File.Exists(photoPath))
                    {
                        logo.Load(photoPath);
                    }
                    else
                    {
                        logo.Image = null; // ou une image par défaut
                        //MessageBox.Show("La photo est introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show($"Erreur lors du chargement de la photo : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logo.Image = null; // ou une image par défaut
                }
            }


            // Console.WriteLine($"Erreur lors de la recuperation de la colonne : {ex.Message}");
            //MessageBox.Show($"Erreur lors de la recuperon de la colonne : {ex.Message}");

        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            Utils.AfficherLogo(logo);
            remplir();
        }

        private void oeil_mp_Click(object sender, EventArgs e)
        {
            if (txtmp.PasswordChar == '*')
            {
                txtmp.PasswordChar = '\0';
            }
            else
            {
                txtmp.PasswordChar = '*';
            }
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png | all files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileinfo = new FileInfo(ofd.FileName);
                Image img = Image.FromFile(ofd.FileName);
                string typeFile = Path.GetExtension(ofd.FileName);
                logo.Image = img;
                chemin = $"{DateTime.Now:yyyy_MM_dd HH-mm-ss} -" + " Logo " + typeFile;
                lb_logo.Text = chemin;
                //chemin =txtmt.Text + " Photo voiture" : typeFile;
                //File.Copy(fileinfo.FullName, Application.StartupPath + "/img_client/" + chemin);
                File.Copy(fileinfo.FullName, AppDomain.CurrentDomain.BaseDirectory + @"img\" + lb_logo.Text);

            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-Vous Sortir??", "2M", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormDashboard dashboard = new FormDashboard();
                dashboard.Show();
                this.Hide();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection();
            Admin admin = new Admin(txtn.Text, txtp.Text, txte.Text, txtmp.Text, txtna.Text, lb_logo.Text);
            Admin.ModifierAdmin(admin);
            remplir();
        }
    }
}
