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
    public partial class FormPretMateriel : Form
    {
        public FormPretMateriel()
        {
            InitializeComponent();
        }
        void remplir()
        {
            Utils.CloseConnection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT \r\n    m.nom AS NomMembre, \r\n    m.prenom AS PrenomMembre," +
                " \r\n    ma.imo AS IMOMateriel, \r\n    ma.num_serie AS NumSerieMateriel, \r\n  " +
                "ma.designation AS DesignationMateriel, \r\n    ma.status AS EtatMateriel, \r\n  " +
                "pm.nom_emprunteure AS NomEmprunteure, \r\n   " +
                "pm.prenom_emprunteure AS PrenomEmprunteure, \r\n    " +
                "pm.departement_emprunteure AS DepartementEmprunteure, \r\n   " +
                "pm.date_debut AS DateDebut, \r\n    pm.date_fin AS DateFin, \r\n  " +
                "pm.raison AS Raison, \r\n    pm.DateCreation AS DateCreation\r\nFROM \r\n " +
                "pret_materiel pm\r\nJOIN \r\n    membres m ON pm.membre_id = m.id\r\n" +
                "JOIN \r\n    gestion_entrer ma ON pm.materiel_id = ma.id;\r\n");

            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            tableau.Columns["PrenomMembre"].Visible = false;
            tableau.Columns["DesignationMateriel"].Visible = false;
            tableau.Columns["EtatMateriel"].Visible = false;
            tableau.Columns["DateCreation"].Visible = false;
            
            for (int i = 1; i < tableau.Columns.Count; i++)
            {
                tableau.Columns[i].Width = 142; // Définit chaque colonne à une largeur de 200 unités
            }
            nouveau();

        }
        void nouveau()
        {
            txtidp.Text = string.Empty;
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
            
            txtdd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdf.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ajouter.Enabled = true;
            modifier.Enabled = false;
            remplirMateriel();
            remplirPreteur();


        }
        void remplirPreteur()
        {
            // Méthode pour importer un matériel via son IMO

            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Demander à l'utilisateur d'entrer le numéro IMO du matériel
            string Cin = Microsoft.VisualBasic.Interaction.InputBox("Entrer le numéro CIN du matériel que vous recherchez", "Gestion des Matériels");

            // Vérifier si l'IMO est vide
            if (string.IsNullOrWhiteSpace(Cin))
            {
                //MessageBox.Show("Le numéro CIN ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Requête SQL pour obtenir les données du matériel
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM membres WHERE cin = '" + Cin + "'");

            // Si des données sont trouvées
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                // Remplir les TextBox dans le formulaire principal pour permettre la modification
                txtidp.Text = row["id"].ToString();
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
            string imo = Microsoft.VisualBasic.Interaction.InputBox("Entrer le numéro IMO du matériel que vous recherchez", "Gestion des Matériels");

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
    }
}
