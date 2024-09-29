using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    public partial class FormConnection : Form
    {
        public FormConnection()
        {
            InitializeComponent();
        }

        private void FormConnection_Load(object sender, EventArgs e)
        {
            Utils.AfficherLogo(logo);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connecter_Click_1(object sender, EventArgs e)
        {
            // Récupérer l'email et le mot de passe saisis par l'utilisateur
            string email = txte.Text.Trim(); // Assurez-vous d'avoir un TextBox nommé txtEmail
            string password = txtps.Text.Trim(); // Assurez-vous d'avoir un TextBox nommé txtPassword

            // Vérifier si les champs ne sont pas vides
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez entrer votre email et mot de passe.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifier les identifiants de l'utilisateur
            try
            {
                // Appel de la méthode VerifierLogin pour vérifier l'authentification
                Utils.VerifierLogin(email, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la tentative de connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
