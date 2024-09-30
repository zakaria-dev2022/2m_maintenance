using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    public partial class FormPretMateriel : Form
    {
        public FormPretMateriel()
        {
            InitializeComponent();
        }
        void remplir()
        {
            Utils.CloseConnection();
            DataTable dataTable = Utils.ObtenirDonnees(
                "SELECT \r\n pm.id AS pretmaterielId, m.id AS membreId," +

                "m.code AS CodeMember,\r\n " +
                "m.nom AS NomMembre,\r\n " +
                "m.prenom AS PrenomMembre," +
                "\r\n ma.id AS MaterielId," +
                "ma.imo AS IMOMateriel,\r\n" +
                "ma.num_serie AS NumSerieMateriel,\r\n" +
                "ma.designation AS DesignationMateriel, \r\n" +
                "ma.status AS EtatMateriel, \r\n  " +
                "pm.nom_emprunteure AS NomEmprunteure, \r\n" +
                "pm.prenom_emprunteure AS PrenomEmprunteure, \r\n " +
                "pm.departement_emprunteure AS DepartementEmprunteure, \r\n" +
                "pm.date_debut AS DateDebut, \r\n" +
                "pm.date_fin AS DateFin, \r\n" +
                "pm.raison AS Raison, \r\n" +
                "pm.DateCreation AS DateCreation\r\n" +
                "FROM \r\n " +
                "pret_materiel pm\r\nJOIN \r\n    membres m ON pm.membre_id = m.id\r\n" +
                "JOIN \r\n    gestion_entrer ma ON pm.materiel_id = ma.id;\r\n");

            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            tableau.Columns["membreId"].Visible = false;
            tableau.Columns["MaterielId"].Visible = false;
            tableau.Columns["CodeMember"].Visible = false;
            tableau.Columns["PrenomMembre"].Visible = false;
            tableau.Columns["PrenomEmprunteure"].Visible = false;
            tableau.Columns["DesignationMateriel"].Visible = false;
            tableau.Columns["EtatMateriel"].Visible = false;
            tableau.Columns["DateCreation"].Visible = false;
            
            for (int i = 1; i < tableau.Columns.Count; i++)
            {
                tableau.Columns[i].Width = 140; // Définit chaque colonne à une largeur de 200 unités
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
            txtidm.Text = string.Empty;
            txtne.Text = string.Empty;
            txtpe.Text = string.Empty;
            txtde.Text = string.Empty;

            txtidm.Text = string.Empty;
            txti.Text = string.Empty;
            txtns.Text = string.Empty;
            txte.Text = string.Empty;
            txtds.Text = string.Empty;
            
            txtdd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdf.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtr.Text = string.Empty;
            ajouter.Enabled = true;
            modifier.Enabled = false;
           // remplirMateriel();
            //remplirPreteur();


        }
        void nouveauPreteur()
        {
            txtidp.Text = string.Empty;
            txtcp.Text = string.Empty;
            txtnp.Text = string.Empty;
            txtpp.Text = string.Empty;
            txtdp.Text = string.Empty;
        }
        void nouveauMateriel()
        {
            txtidm.Text = string.Empty;
            txti.Text = string.Empty;
            txtns.Text = string.Empty;
            txte.Text = string.Empty;
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

        void remplirMateriel()
        {
            // Méthode pour importer un matériel via son IMO

            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Demander à l'utilisateur d'entrer le numéro IMO du matériel
            string imo = Microsoft.VisualBasic.Interaction.InputBox("Entrer le numéro IMO du matériel que vous recherchez", "2M");

            // Vérifier si l'IMO est vide
            if (string.IsNullOrWhiteSpace(imo))
            {
                MessageBox.Show("Le numéro IMO ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Requête SQL pour obtenir les données du matériel
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM gestion_entrer WHERE IMO = '" + imo + "'");

            // Si des données sont trouvées
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];


                // Remplir les TextBox dans le formulaire principal pour permettre la modification
                txtidm.Text = row["id"].ToString();
                txti.Text = row["IMO"].ToString();
                txtns.Text = row["Num_serie"].ToString();
                txtds.Text = row["Designation"].ToString();
                txte.Text = row["status"].ToString();
            }


            else
            {
                MessageBox.Show("Le matériel avec le numéro IMO entré n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        

        private void FormPretMateriel_Load(object sender, EventArgs e)
        {
            remplir();
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

        private void ajouter_Click(object sender, EventArgs e)
        {
                if (txtne.Text != "" && txtpe.Text != "" && txtde.Text != "" && txtidp.Text != "" && txtidm.Text != "" && txtdd.Value != null)
                {
                    // Récupérer les valeurs saisies
                    int membreId = Convert.ToInt32(txtidp.Text);
                    int materielId = Convert.ToInt32(txtidm.Text);
                    string nomEmprunteure = txtne.Text.ToString();
                    string prenomEmprunteure = txtpe.Text.ToString();
                    string departementEmprunteure = txtde.Text.ToString();
                    DateTime dateDebut = txtdd.Value;
                    DateTime dateFin = txtdf.Value; // Gérer le champ nullable
                    string raison = txtr.Text.ToString();

                    // Créer une instance de PretMateriel
                    PretMateriel pret = new PretMateriel(membreId, materielId, nomEmprunteure, prenomEmprunteure, departementEmprunteure, dateDebut, dateFin, raison);

                    // Appeler la méthode pour ajouter le prêt
                    PretMateriel.AjouterPretMateriel(pret);

                    // Rafraîchir les données (si une méthode existe pour cela)
                    remplir();
                }
                else
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void chercherPreteur_Click(object sender, EventArgs e)
        {
            remplirPreteur();
        }

        private void btnnouveauPreteur_Click(object sender, EventArgs e)
        {
            nouveau();
        }

        

        private void btnNouveauMateriel_Click(object sender, EventArgs e)
        {
            nouveauMateriel();
        }
        void importeMateriel(string id)
        {
            // Méthode pour importer un matériel via son IMO

            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Requête SQL pour obtenir les données du matériel
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM gestion_entrer WHERE id = '" + id + "'");

            DataRow row = dataTable.Rows[0];

            // Remplir les TextBox dans le formulaire principal pour permettre la modification
            txtidm.Text = row["id"].ToString();
            txti.Text = row["IMO"].ToString();
            txtns.Text = row["Num_serie"].ToString();
            txtds.Text = row["Designation"].ToString();
            txte.Text = row["status"].ToString();
        }
        void importePreteur(string id)
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
        private void tableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // Vérifie si l'index de la ligne sélectionnée est valide
            if (e.RowIndex >= 0)
            {
                // Récupère la ligne sélectionnée
                DataGridViewRow row = tableau.Rows[e.RowIndex];

                // Remplit les champs de texte avec les données de la ligne sélectionnée
                txtid.Text = row.Cells["pretmaterielId"].Value.ToString();                        // Identifiant du prêt
                importePreteur( row.Cells["MembreId"].Value.ToString());            // Identifiant du membre
                importeMateriel( row.Cells["MaterielId"].Value.ToString());        // Identifiant du matériel
                txtne.Text = row.Cells["NomEmprunteure"].Value.ToString();  // Nom de l'emprunteur
                txtpe.Text = row.Cells["PrenomEmprunteure"].Value.ToString(); // Prénom de l'emprunteur
                txtde.Text = row.Cells["DepartementEmprunteure"].Value.ToString(); // Département de l'emprunteur
                txtdd.Value = Convert.ToDateTime(row.Cells["DateDebut"].Value); // Date de début du prêt

                // Vérifie si la date de fin n'est pas nulle avant d'essayer de la convertir
                if (row.Cells["DateFin"].Value != DBNull.Value)
                {
                    txtdf.Value = Convert.ToDateTime(row.Cells["DateFin"].Value); // Date de fin du prêt (facultative)
                }
                else
                {
                    txtdf.Value = DateTime.Now; // Si la date est vide, mettre une valeur par défaut
                }

                txtr.Text = row.Cells["Raison"].Value.ToString();               // Raison du prêt
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

        private void modifier_Click(object sender, EventArgs e)
        {
            // Vérifier que tous les champs obligatoires sont remplis
            if (!string.IsNullOrWhiteSpace(txtid.Text) && !string.IsNullOrWhiteSpace(txtidp.Text) && !string.IsNullOrWhiteSpace(txtidm.Text) && !string.IsNullOrWhiteSpace(txtds.Text) && !string.IsNullOrWhiteSpace(txtdd.Text))
            {

                // Récupérer les valeurs saisies
                int id = Convert.ToInt32(txtid.Text);
                int membreId = Convert.ToInt32(txtidp.Text);
                int materielId = Convert.ToInt32(txtidm.Text);
                string nomEmprunteure = txtne.Text.ToString();
                string prenomEmprunteure = txtpe.Text.ToString();
                string departementEmprunteure = txtde.Text.ToString();
                DateTime dateDebut = txtdd.Value;
                DateTime dateFin = txtdf.Value; // Gérer le champ nullable
                string raison = txtr.Text.ToString();
                // Créer une instance de PretMateriel
                PretMateriel pret = new PretMateriel(membreId, materielId, nomEmprunteure, prenomEmprunteure, departementEmprunteure, dateDebut, dateFin, raison);

                // Appeler la méthode pour ajouter le prêt
                PretMateriel.ModifierPretMateriel(pret,id);

                // Rafraîchir les données (si une méthode existe pour cela)
                remplir();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chercherMateriel_Click_1(object sender, EventArgs e)
        {
            remplirMateriel();
        }

        private void chercherPretmateriel_Click(object sender, EventArgs e)
        {

        }

        private void txtdd_ValueChanged(object sender, EventArgs e)
        {
            txtdf.MinDate = txtdd.Value;
        }

        private void filter_Click(object sender, EventArgs e)
        {
            
        }

        private void tableau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
