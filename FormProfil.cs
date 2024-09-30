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
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }

        void remplirPreteur()
        {
            // Méthode pour importer un matériel via son IMO

            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Demander à l'utilisateur d'entrer le numéro IMO du matériel
            string Cin = Microsoft.VisualBasic.Interaction.InputBox("Entrer le code du membre que vous recherchez", "2M");

            // Vérifier si l'IMO est vide
            if (string.IsNullOrWhiteSpace(Cin))
            {
                //MessageBox.Show("Le numéro CIN ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Requête SQL pour obtenir les données du matériel
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM membres WHERE code = '" + Cin + "'");

            // Si des données sont trouvées
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                // Remplir les TextBox dans le formulaire principal pour permettre la modification
                txtidp.Text = row["Id"].ToString();
                txtep.Text = row["Gmail"].ToString();
            }
            else
            {
                MessageBox.Show("Le Membre avec le Code entré n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void remplir()
        {
            Utils.CloseConnection();
            //Connection dbOperations = new Connection();
           DataTable dataTable = Utils.ObtenirDonnees("SELECT  \r\n    p.Code AS MembreCode,\r\n    p.Nom AS MembreNom,\r\n    p.Prenom AS MembrePrenom,\r\n    p.CIN AS MembreCIN,\r\n    a.password AS AssistantPassword\r\nFROM \r\n    profils a\r\nINNER JOIN \r\n    membres p ON a.membre_id = p.Id");
            //DataTable dataTable = Utils.ObtenirDonnees("select * from produit");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            // tableau.Columns["ph_cin"].Visible = false;

        }

        void nouveau()
        {
            txtid.Text = string.Empty; txtidp.Text = string.Empty;
            txtep.Text = string.Empty;
            txtcmp.Text = string.Empty;
            txtmp.Text = string.Empty;
            txtep.Focus();
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {
            remplirPreteur();
            remplir();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if (txtmp.Text == txtcmp.Text)
            {
                int membre_id = Convert.ToInt32(txtidp.Text);
                MessageBox.Show(membre_id.ToString());

                Assistant assistant = new Assistant(membre_id, txtmp.Text);
                Assistant.AjouterAssistant(assistant);
                nouveau();
                remplir();
                ajouter.Enabled = true;
                modifier.Enabled = false;
                supprimer.Enabled = false;
            }
            else
            {
                MessageBox.Show("Mot De Passe Incorect", "Zakaria Location");
                lb_msg.Visible = true;
                lb_msg.Text = "Mot De Passe Incorect";
                txtcmp.Text = "";
                txtcmp.Focus();
            }
        }
    }
}
