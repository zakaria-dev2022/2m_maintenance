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
           DataTable dataTable = Utils.ObtenirDonnees("SELECT  \r\n    p.Code AS MembreCode,\r\n    p.Nom AS MembreNom,\r\n    p.Prenom AS MembrePrenom,\r\n    p.Gmail AS Email,\r\n    a.id \r\n,a.password AS Password\r\nFROM \r\n    profils a\r\nINNER JOIN \r\n    membres p ON a.membre_id = p.Id");
            //DataTable dataTable = Utils.ObtenirDonnees("select * from produit");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
             tableau.Columns["id"].Visible = false;
            nouveau();
            ajouter.Enabled = true;
            modifier.Enabled = false;
            supprimer.Enabled = false;
        }

    

        void nouveau()
        {
            txtid.Text = string.Empty; txtidp.Text = string.Empty;
            txtep.Text = string.Empty;
            txtcmp.Text = string.Empty;
            txtmp.Text = string.Empty;
            txtep.Focus();
            ajouter.Enabled = true;
            modifier.Enabled = false;
            supprimer.Enabled = false;
            lb_msg.Visible = false;
        }
    

        private void FormProfil_Load(object sender, EventArgs e)
        {
            remplir();
            remplirPreteur();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if (txtmp.Text == txtcmp.Text)
            {
                int membre_id = Convert.ToInt32(txtidp.Text);
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
                //MessageBox.Show("Mot De Passe Incorect", "Zakaria Location");
                lb_msg.Visible = true;
                lb_msg.Text = "Mot De Passe Incorect";
                txtcmp.Text = "";
                txtcmp.Focus();
            }
        }

        private void chercherPreteur_Click(object sender, EventArgs e)
        {
            remplirPreteur();
        }
        void importePreteur(string code)
        {
            try
            {
                Utils.OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour obtenir les données du membre avec un paramètre pour éviter les injections SQL
                string query = "SELECT * FROM membres WHERE code = @Code";
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                command.Parameters.AddWithValue("@Code", code);

                // Exécuter la commande et récupérer les données dans un DataTable
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0) // Vérifier si un membre est trouvé
                {
                    DataRow row = dataTable.Rows[0];
                    // Remplir les TextBox dans le formulaire principal pour permettre la modification
                    txtidp.Text = row["id"].ToString();
                    txtep.Text = row["Gmail"].ToString();
                }
                else
                {
                    MessageBox.Show("Aucun membre trouvé avec ce code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nouveau();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'importation des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Utils.cnx.State == ConnectionState.Open)
                    Utils.cnx.Close(); // Fermer la connexion après l'exécution
            }
        }


        private void tableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifie si l'index de la ligne sélectionnée est valide
            if (e.RowIndex >= 0)
            {
                // Récupère la ligne sélectionnée
                DataGridViewRow row = tableau.Rows[e.RowIndex];

                // Remplit les champs de texte avec les données de la ligne sélectionnée
                txtid.Text = row.Cells["id"].Value.ToString();                        // Identifiant du prêt
                importePreteur(row.Cells["MembreCode"].Value.ToString());
                txtmp.Text = row.Cells["Password"].Value.ToString();  
                txtcmp.Text = row.Cells["Password"].Value.ToString();  
                
                ajouter.Enabled = false;
                modifier.Enabled = true;
                supprimer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aucun élément sélectionné", "Information");
                // Remplir à nouveau les données si nécessaire
                remplir();
            }
        }

        private void chercherProfil_Click(object sender, EventArgs e)
        {
            
        }

        private void btnnouveauPretMateriel_Click(object sender, EventArgs e)
        {
            nouveau();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection();
            if (MessageBox.Show("Voulez-vous supprimer Ce Profil?", "2M", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Utils.SuprimerDonner("profils", txtid.Text);
                MessageBox.Show("Supression Avec Success", "2M");
                remplir();
            }
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            // Vérifier que tous les champs obligatoires sont remplis
            if (!string.IsNullOrWhiteSpace(txtid.Text) && !string.IsNullOrWhiteSpace(txtidp.Text) && !string.IsNullOrWhiteSpace(txtmp.Text)&& !string.IsNullOrWhiteSpace(txtcmp.Text) )
            {
                try
                {
                    // Récupérer les valeurs saisies
                    int id = Convert.ToInt32(txtid.Text);
                    int membreId = Convert.ToInt32(txtidp.Text);
                    string mp=txtmp.Text;
                    string cmp=txtcmp.Text;

                    if (mp == cmp)
                    {
                        Assistant assistant = new Assistant(membreId, mp);
                        Assistant.ModifierAssistant(assistant,id);
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrect", "2M");
                        return;
                    }


                    // Rafraîchir les données (si une méthode existe pour cela)
                    remplir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de la modification du prêt : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous retourn au page précedent", "2M", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormSetting dash = new FormSetting();
                dash.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
