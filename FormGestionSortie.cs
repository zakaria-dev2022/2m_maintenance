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
    public partial class FormGestionSortie : Form
    {

        OpenFileDialog ofd = new OpenFileDialog();
        string chemin = "";
        public FormGestionSortie()
        {
            InitializeComponent();
        }
        void remplir()
        {
            Utils.CloseConnection();
            //Connection dbOperations = new Connection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT \r\n    id AS 'N°Materiel',\r\n    imo AS 'IMO',\r\n    num_serie AS 'Num_serie',\r\n    designation AS 'Designation',\r\n    reference AS 'Reference',\r\n    status AS 'Status',\r\n    date_soumission AS 'Date_soumission',\r\n    emplacement AS 'Emplacement',\r\n    description AS 'Description',\r\n    photo AS 'Photo',\r\n    date_creation AS 'Date_creation'\r\nFROM gestion_sortie;");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            tableau.Columns["Photo"].Visible = false;
            tableau.Columns["date_creation"].Visible = false;
            for (int i = 1; i < 8; i++)
            {
                tableau.Columns[i].Width = 133; // Définit chaque colonne à une largeur de 200 unités
            }
            tableau.Columns[8].Width = 190;
            nouveau();
        }
        void nouveau()
        {
            txti.Text = string.Empty;
            txtt.Text = string.Empty;
            txts.Text = string.Empty;
            txtds.Text = string.Empty;
            txte.Text = string.Empty;
            txtd.Text = string.Empty;
            txtr.Text = string.Empty;
            txtns.Text = string.Empty;
            txts.Text = string.Empty;
            txtdt.Text = string.Empty;
            txtdst.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtrs.Text = string.Empty;
            lb_photo.Text = string.Empty;
            picture.Image = null;
            txti.Focus();
            txtds.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ajouter.Enabled = true;
            modifier.Enabled = false;
            supprimer.Enabled = false;


        }
        void importerMateriel()
        {
            Utils.CloseConnection();

            // Boucle jusqu'à ce que le matériel soit trouvé ou que l'utilisateur annule
            bool materialFound = false;

            while (!materialFound)
            {
                // Demander à l'utilisateur d'entrer le N° IMO du matériel
                string nimo = Microsoft.VisualBasic.Interaction.InputBox("Entrer N° IMO du Matériel que vous recherchez", "AHF");

                // Vérifier si l'utilisateur a annulé (si nimo est vide, il a appuyé sur Annuler ou n'a rien entré)
                if (string.IsNullOrWhiteSpace(nimo))
                {
                    MessageBox.Show("L'opération a été annulée.", "Recherche Matériel");
                    return; // Sortir de la méthode
                }

                // Obtenir les données du matériel en fonction du N° IMO
                DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM gestion_entrer WHERE imo = '" + nimo + "'");

                // Vérifier si des données ont été trouvées
                if (dataTable.Rows.Count > 0)
                {
                    // Récupérer la première ligne de résultat
                    DataRow row = dataTable.Rows[0];

                    // Afficher les données dans les TextBox correspondants
                    txtid.Text = row["Id"].ToString();
                    txti.Text = row["imo"].ToString();
                    txtns.Text = row["num_serie"].ToString();
                    txtt.Text = row["designation"].ToString();
                    txtr.Text = row["reference"].ToString();
                    txts.Text = row["status"].ToString();
                    txtds.Text = row["date_soumission"].ToString();
                    txte.Text = row["emplacement"].ToString();
                    txtd.Text = row["description"].ToString();
                    lb_photo.Text = row["photo"].ToString();

                    materialFound = true; // Matériel trouvé, sortir de la boucle
                }
                else
                {
                    // Aucune donnée trouvée, afficher un message d'erreur et redemander
                    MessageBox.Show("Le matériel avec le N° IMO " + nimo + " n'a pas été trouvé. Veuillez réessayer.", "Erreur de Recherche", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormGestionSortie_Load(object sender, EventArgs e)
        {
            remplir();
            importerMateriel();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            // Vérifier que tous les champs obligatoires sont remplis
            if (!string.IsNullOrWhiteSpace(txti.Text) && !string.IsNullOrWhiteSpace(txtns.Text) && !string.IsNullOrWhiteSpace(txtt.Text))
            {
                // Récupérer les valeurs des TextBox
                string imo = txti.Text;
                string numSerie = txtns.Text;
                string designation = txtt.Text;
                string reference = txtr.Text; // Peut être null
                string status = txts.Text;
                DateTime dateSoumission = txtds.Value; // Assurez-vous du format
                string emplacement = txte.Text;
                string description = txtd.Text;
                string photo = lb_photo.Text; // Assurez-vous que le chemin de la photo est récupéré si besoin
                DateTime dateSortie = txtdst.Value; // Récupérer la date de sortie
                string destination = txtdt.Text;
                string raison = txtrs.Text;

                // Créer un objet GestionSortie
                GestionSortie materiel = new GestionSortie
                (
                    imo,
                    numSerie,
                    designation,
                    reference,
                    status,
                    dateSoumission,
                    emplacement,
                    description,
                    photo,
                    dateSortie,
                    destination,
                    raison
                );

                // Appeler la méthode AjouterMateriel pour insérer le matériel
                GestionSortie.AjouterMateriel(materiel);

                // Mettre à jour le DataGridView
                remplir();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
