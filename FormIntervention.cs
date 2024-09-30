using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    public partial class FormIntervention : Form
    {
        void remplir()
        {
            Utils.CloseConnection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT \r\n    i.id AS InterventionId,\r\n    m.Id AS MembreId,\r\n    m.Code AS MembreCode,\r\n    m.Nom AS MembreNom,\r\n    m.Prenom AS MembrePrenom,\r\n    i.type AS Type,\r\n    i.status AS Status,\r\n    i.date AS DateIntervention,\r\n    i.emplacement AS Emplacement,\r\n    i.description AS Description\r\nFROM \r\n    intervention i\r\nINNER JOIN \r\n    membres m ON i.membre_id = m.Id;");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            tableau.Columns["MembreId"].Visible = false;

            for (int i = 1; i < tableau.Columns.Count; i++)
            {
                tableau.Columns[i].Width = 141; // Définit chaque colonne à une largeur de 200 unités
            }
            nouveau();

        }
        void nouveau()
        {
            txtidp.Text = string.Empty;
            txtcp.Text = string.Empty;
            txtnp.Text = string.Empty;
            txtpp.Text = string.Empty;
            txtdp.Text = string.Empty;

            txtt.Text = string.Empty;
            txts.Text = string.Empty;
            txtdi.Text= DateTime.Now.ToString("dd/MM/yyyy");
            txte.Text = string.Empty;
            txtd.Text = string.Empty;
            // Gestion des boutons
            ajouter.Enabled = true;
            modifier.Enabled = false;
        }
        void remplirResponsable()
        {
            // Méthode pour importer un matériel via son IMO

            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Demander à l'utilisateur d'entrer le numéro IMO du matériel
            string Cin = Microsoft.VisualBasic.Interaction.InputBox("Entrer le code du membre que vous recherchez", "Gestion des Matériels");

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
                txtidp.Text = row["id"].ToString();
                txtcp.Text = row["code"].ToString();
                txtnp.Text = row["nom"].ToString();
                txtpp.Text = row["prenom"].ToString();
                txtdp.Text = "Maintenance";
            }
            else
            {
                MessageBox.Show("Le Membre avec le numéro CIN entré n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public FormIntervention()
        {
            InitializeComponent();
        }

        private void FormIntervention_Load(object sender, EventArgs e)
        {
            remplir();

        }

        private void chercherResponsable_Click(object sender, EventArgs e)
        {
            remplirResponsable();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {

            // Vérifier si tous les champs obligatoires sont remplis
            if (txtidp.Text != "" && txtt.Text != "" && txts.Text != "" && txte.Text != "" && txtd.Text != "" )
            {
                // Récupérer les valeurs saisies
                int membreId = Convert.ToInt32(txtidp.Text);
                string type = txtt.Text.ToString();
                string status = txts.Text.ToString();
                string emplacement = txte.Text.ToString();
                string description = txtd.Text.ToString();
                DateTime date = txtdi.Value;

                // Créer une instance de Intervention
                Intervention intervention = new Intervention(membreId, type, status, date, emplacement, description);

                // Appeler la méthode pour ajouter l'intervention
                Intervention.AjouterIntervention(intervention);

                // Rafraîchir les données (si une méthode existe pour cela)
                remplir();
                // Gestion des boutons
                ajouter.Enabled = true;
                modifier.Enabled = false;
            }
            else
            {
                // Afficher un message d'erreur si des champs obligatoires ne sont pas remplis
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void importeResponsable(string id)
        {// Méthode pour importer un matériel via son IMO

            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Requête SQL pour obtenir les données du matériel
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM membres WHERE id = '" + id + "'");
            DataRow row = dataTable.Rows[0];

            // Remplir les TextBox dans le formulaire principal pour permettre la modification
            txtidp.Text = row["id"].ToString();
            txtcp.Text = row["code"].ToString();
            txtnp.Text = row["nom"].ToString();
            txtpp.Text = row["prenom"].ToString();
            txtdp.Text = "Maintenance";
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            // Vérifier si tous les champs obligatoires sont remplis
            if (txtidp.Text != "" && txtt.Text != "" && txts.Text != "" && txte.Text != "" && txtd.Text != "")
            {
                // Récupérer les valeurs saisies
                int id = Convert.ToInt32(txtid.Text);
                int membreId = Convert.ToInt32(txtidp.Text);
                string type = txtt.Text.ToString();
                string status = txts.Text.ToString();
                string emplacement = txte.Text.ToString();
                string description = txtd.Text.ToString();
                DateTime date = txtdi.Value;
                // Créer une instance de Intervention
                Intervention intervention = new Intervention(membreId, type, status, date, emplacement, description);

                // Appeler la méthode pour ajouter l'intervention
                Intervention.ModifierIntervention(intervention,id);

                // Rafraîchir les données (si une méthode existe pour cela)
                remplir();
                // Gestion des boutons
                ajouter.Enabled = true;
                modifier.Enabled = false;
            }
            else
            {
                // Afficher un message d'erreur si des champs obligatoires ne sont pas remplis
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtid.Text = row.Cells["InterventionId"].Value.ToString();                        
                importeResponsable( row.Cells["MembreId"].Value.ToString());
                txtt.Text = row.Cells["Type"].Value.ToString();
                txts.Text = row.Cells["Status"].Value.ToString();  
                txte.Text = row.Cells["Emplacement"].Value.ToString(); 
                txtd.Text = row.Cells["Description"].Value.ToString();
                txtdi.Value = Convert.ToDateTime(row.Cells["DateIntervention"].Value); 

                // Gestion des boutons
                ajouter.Enabled = false;
                modifier.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aucun élément sélectionné", "Information");
                // Remplir à nouveau les données si nécessaire
                remplir();
            }
        }

        private void btnnouveau_Click(object sender, EventArgs e)
        {
            nouveau();
        }

        private void chercherIntervention_Click(object sender, EventArgs e)
        {
            
        }

        private void precedent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous retourn au page précedent", "2M", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormDashboard dash = new FormDashboard();
                dash.Show();
                this.Hide();
            }
        }
    }
}
