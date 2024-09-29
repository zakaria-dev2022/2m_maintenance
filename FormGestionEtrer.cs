using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    public partial class FormGestionEtrer : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        string chemin = "";
        public FormGestionEtrer()
        {
            InitializeComponent();
        }

        void remplir()
        {
            Utils.CloseConnection();
            //Connection dbOperations = new Connection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT \r\n    id AS 'N°Materiel',\r\n    imo AS 'IMO',\r\n    num_serie AS 'Num_serie',\r\n    designation AS 'Designation',\r\n    reference AS 'Reference',\r\n    status AS 'Status',\r\n    date_soumission AS 'Date_soumission',\r\n    emplacement AS 'Emplacement',\r\n    description AS 'Description',\r\n    photo AS 'Photo',\r\n    date_creation AS 'Date_creation'\r\nFROM gestion_entrer;");
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
            lb_photo.Text = string.Empty;
            picture.Image = null;
            txti.Focus();
            txtds.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ajouter.Enabled = true;
            modifier.Enabled = false;
            supprimer.Enabled = false;


        }
        private void importer_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png | all files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileinfo = new FileInfo(ofd.FileName);
                Image img = Image.FromFile(ofd.FileName);
                string typeFile = Path.GetExtension(ofd.FileName);
                picture.Image = img;
                lb_photo.Text = $"{DateTime.Now:yyyy_MM_dd HH-mm-ss} -" + txti.Text + typeFile;
                chemin = lb_photo.Text;
                //chemin =txtmt.Text + " Photo voiture" : typeFile;
                //File.Copy(fileinfo.FullName, Application.StartupPath + "/img_client/" + chemin);
                File.Copy(fileinfo.FullName, AppDomain.CurrentDomain.BaseDirectory + @"img\Materiels\" + chemin);

            }
        }

        private void ajouter_Click(object sender, EventArgs e)
        {

            // Vérifier que tous les champs obligatoires sont remplis
            if (!string.IsNullOrWhiteSpace(txti.Text) && !string.IsNullOrWhiteSpace(txtt.Text) && !string.IsNullOrWhiteSpace(txtns.Text))
            {
                // Récupérer les valeurs des TextBox
                string imo = txti.Text;
                string numSerie = txtns.Text;
                string designation = txtt.Text;
                string reference = txtr.Text; // Peut être null
                string status = txts.Text;
                DateTime dateSoumission = txtds.Value;// Assurez-vous du format
                string emplacement = txte.Text;
                string description = txtd.Text;
                string photo = lb_photo.Text; // Assurez-vous que le chemin de la photo est récupéré si besoin

                // Créer un objet Materiel
                Materiels materiel = new Materiels
                (
                    imo,
                    numSerie,
                    designation,
                    reference,
                    status,
                    dateSoumission,
                    emplacement,
                    description,
                    photo
                );

                // Appeler la méthode AjouterMateriel pour insérer le matériel
                Materiels.AjouterMateriel(materiel);

                // Remplir à nouveau le DataGridView avec les nouveaux données
                remplir();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection();
            if (MessageBox.Show("Voulez-vous supprimer Ce Materiel?", "2M", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Utils.SuprimerDonner("Materiels", txtid.Text);
                MessageBox.Show("Supression Avec Success", "2M");
                remplir();
            }
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            // Vérifier que tous les champs obligatoires sont remplis
            if (!string.IsNullOrWhiteSpace(txti.Text) && !string.IsNullOrWhiteSpace(txtt.Text) && !string.IsNullOrWhiteSpace(txts.Text))
            {
                // Récupérer les valeurs des TextBox
                int id = int.Parse(txtid.Text);
                string imo = txti.Text;
                string numSerie = txtns.Text;
                string designation = txtt.Text;
                string reference = txtr.Text; // Peut être null
                string status = txts.Text;
                DateTime dateSoumission = txtds.Value;// Assurez-vous du format
                string emplacement = txte.Text;
                string description = txtd.Text;
                string photo = lb_photo.Text; // Assurez-vous que le chemin de la photo est récupéré si besoin

                // Créer un objet Materiel
                Materiels materiel = new Materiels(imo, numSerie, designation, reference, status, dateSoumission, emplacement, description, photo);

                // Appeler la méthode AjouterMateriel pour insérer le matériel
                Materiels.ModifierMateriel(materiel, id);

                // Remplir à nouveau le DataGridView avec les nouveaux données
                remplir();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chercher_Click(object sender, EventArgs e)
        {
                Utils.CloseConnection();

                // Demander à l'utilisateur d'entrer le numéro IMO du matériel
                string imo = Microsoft.VisualBasic.Interaction.InputBox("Entrer le numéro IMO du matériel que vous recherchez", "Gestion des Matériels");

                // Obtenir les données du matériel en fonction du numéro IMO
                DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM gestion_entrer WHERE IMO = '" + imo + "'");

                // Vérifier si des données ont été trouvées
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    // Création d'un nouveau formulaire personnalisé pour afficher les résultats
                    Form form = new Form();
                    form.Text = $"Information du matériel {row["Designation"]}"; // Titre avec la désignation du matériel
                    form.FormBorderStyle = FormBorderStyle.None; // Supprimer la bordure du formulaire
                    form.StartPosition = FormStartPosition.CenterScreen; // Centrer le formulaire à l'écran
                    form.BackColor = Color.White;
                    form.Size = new Size(714, 599); // Définir la taille du formulaire

                    int marginTop = 60; // Espace en haut du formulaire (pour inclure le titre)
                    int marginBottomTitle = 15; // Espace en bas du titre
                    int marginLeftLabels = 20; // Espace pour les labels
                    int marginLeftValues = 180; // Espace pour les valeurs

                    // Créer un titre en haut du formulaire
                    Label lblTitle = new Label();
                    lblTitle.Text = $"Information du matériel {row["Designation"]}";
                    lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
                    lblTitle.ForeColor = Color.Black;
                    lblTitle.AutoSize = true;
                    lblTitle.Location = new Point((form.Width - lblTitle.Width) / 4, 20); // Centrer le titre en haut
                    form.Controls.Add(lblTitle);
                    marginTop = lblTitle.Location.Y + lblTitle.Height + marginBottomTitle;

                    // Créer des étiquettes pour chaque détail
                    Label[] labels = new Label[]
                    {
            new Label { Text = "N°materiel:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "IMO:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Numéro de série:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Désignation:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Référence:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Statut:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Date de soumission:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Emplacement:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Description:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
                    };

                    // Créer des labels pour afficher les valeurs
                    Label[] values = new Label[]
                    {
            new Label { Text = row["ID"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["IMO"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Num_serie"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Designation"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Reference"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Status"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = Convert.ToDateTime(row["Date_soumission"]).ToString("dd/MM/yyyy"), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Emplacement"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Description"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
                    };

                    // Ajouter les labels et valeurs au formulaire
                    for (int i = 0; i < labels.Length; i++)
                    {
                        labels[i].Location = new Point(marginLeftLabels, marginTop + (i * 40)); // Position des labels
                        values[i].Location = new Point(marginLeftValues, marginTop + (i * 40)); // Position des valeurs

                        form.Controls.Add(labels[i]);
                        form.Controls.Add(values[i]);
                    }

                    // Bouton Modifier
                    Button btnModifier = new Button();
                    btnModifier.Text = "Modifier";
                    btnModifier.Font = new Font("Arial", 10, FontStyle.Bold);
                    btnModifier.Size = new Size(100, 40);
                    btnModifier.BackColor = ColorTranslator.FromHtml("#577B93");
                    btnModifier.ForeColor = Color.White;
                    btnModifier.FlatStyle = FlatStyle.Flat;
                    btnModifier.Location = new Point(form.Width - 220, form.Height - 80); // Position en bas à droite
                    btnModifier.Click += (s, ev) =>
                    {
                        form.Close();
                        // Remplir les TextBox dans le formulaire principal pour permettre la modification
                        txtid.Text = row["ID"].ToString();
                        txti.Text = row["IMO"].ToString();
                        txtns.Text = row["Num_serie"].ToString();
                        txtt.Text = row["Designation"].ToString();
                        txtr.Text = row["Reference"].ToString();
                        txts.Text = row["Status"].ToString();
                        txtds.Value = Convert.ToDateTime(row["Date_soumission"]);
                        txte.Text = row["Emplacement"].ToString();
                        txtd.Text = row["Description"].ToString();
                        lb_photo.Text = row["Photo"].ToString();

                        // Charger l'image de photo
                        string photoPath = AppDomain.CurrentDomain.BaseDirectory + @"img\Materiels\" + lb_photo.Text;
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(lb_photo.Text) && System.IO.File.Exists(photoPath))
                            {
                                picture.Image = Image.FromFile(photoPath);
                            }
                            else
                            {
                                picture.Image = null; // ou une image par défaut
                                MessageBox.Show("La photo est introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erreur lors du chargement de la photo : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            picture.Image = null; // ou une image par défaut
                        }

                        ajouter.Enabled = false;
                        modifier.Enabled = true;
                        supprimer.Enabled = true;
                    };
                    form.Controls.Add(btnModifier);

                    // Bouton Annuler
                    Button btnAnnuler = new Button();
                    btnAnnuler.Text = "Annuler";
                    btnAnnuler.Font = new Font("Arial", 10, FontStyle.Bold);
                    btnAnnuler.Size = new Size(100, 40);
                    btnAnnuler.BackColor = Color.Gray;
                    btnAnnuler.ForeColor = Color.White;
                    btnAnnuler.FlatStyle = FlatStyle.Flat;
                    btnAnnuler.Location = new Point(form.Width - 110, form.Height - 80); // Position en bas à droite à côté de Modifier
                    btnAnnuler.Click += (s, ev) =>
                    {
                        form.Close();
                        // Optionnel : réinitialiser les champs si nécessaire
                    };
                    form.Controls.Add(btnAnnuler);

                    // Afficher le formulaire
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Aucun matériel trouvé avec le numéro IMO donné.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Utils.CloseConnection();
            

        }

        private void FormGestionEtrer_Load(object sender, EventArgs e)
        {
            remplir();
        }

        private void tableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int n = tableau.Rows.Count - 1;
            if (e.RowIndex >= 0 && e.RowIndex < n)
            {
                DataGridViewRow row = tableau.Rows[e.RowIndex];

                // Récupération des valeurs dans les TextBox
                txtid.Text = row.Cells["N°Materiel"].Value.ToString();
                txti.Text = row.Cells["Imo"].Value.ToString();
                txtns.Text = row.Cells["Num_serie"].Value.ToString();
                txtt.Text = row.Cells["Designation"].Value.ToString();
                txtr.Text = row.Cells["Reference"].Value.ToString();
                txts.Text = row.Cells["Status"].Value.ToString();
                txtds.Value = Convert.ToDateTime(row.Cells["Date_soumission"].Value);
                txte.Text = row.Cells["Emplacement"].Value.ToString();
                txtd.Text = row.Cells["Description"].Value.ToString();
                lb_photo.Text = row.Cells["Photo"].Value.ToString();

                // Chargement de l'image de photo
                string photoPath = AppDomain.CurrentDomain.BaseDirectory + @"img\Materiels\" + lb_photo.Text;
                try
                {
                    if (!string.IsNullOrWhiteSpace(lb_photo.Text) && System.IO.File.Exists(photoPath))
                    {
                        picture.Image = Image.FromFile(photoPath);
                    }
                    else
                    {
                        picture.Image = null; // ou une image par défaut
                        //MessageBox.Show("La photo est introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du chargement de la photo : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picture.Image = null; // ou une image par défaut
                }

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

       

        private void btnnouveau_Click_1(object sender, EventArgs e)
        {
            nouveau();
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

        private void btnnouveau_Click(object sender, EventArgs e)
        {
            nouveau();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Utils.CloseConnection();

            // Demander à l'utilisateur d'entrer le numéro IMO du matériel
            string imo = Microsoft.VisualBasic.Interaction.InputBox("Entrer le numéro IMO du matériel que vous recherchez", "Gestion des Matériels");

            // Obtenir les données du matériel en fonction du numéro IMO
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM gestion_entrer WHERE IMO = '" + imo + "'");

            // Vérifier si des données ont été trouvées
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                // Création d'un nouveau formulaire personnalisé pour afficher les résultats
                Form form = new Form();
                form.Text = $"Information du matériel {row["Designation"]}"; // Titre avec la désignation du matériel
                form.FormBorderStyle = FormBorderStyle.None; // Supprimer la bordure du formulaire
                form.StartPosition = FormStartPosition.CenterScreen; // Centrer le formulaire à l'écran
                form.BackColor = Color.White;
                form.Size = new Size(714, 599); // Définir la taille du formulaire

                int marginTop = 60; // Espace en haut du formulaire (pour inclure le titre)
                int marginBottomTitle = 15; // Espace en bas du titre
                int marginLeftLabels = 20; // Espace pour les labels
                int marginLeftValues = 180; // Espace pour les valeurs

                // Créer un titre en haut du formulaire
                Label lblTitle = new Label();
                lblTitle.Text = $"Information du matériel {row["Designation"]}";
                lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
                lblTitle.ForeColor = Color.Black;
                lblTitle.AutoSize = true;
                lblTitle.Location = new Point((form.Width - lblTitle.Width) / 4, 20); // Centrer le titre en haut
                form.Controls.Add(lblTitle);
                marginTop = lblTitle.Location.Y + lblTitle.Height + marginBottomTitle;

                // Créer des étiquettes pour chaque détail
                Label[] labels = new Label[]
                {
            new Label { Text = "N°materiel:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "IMO:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Numéro de série:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Désignation:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Référence:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Statut:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Date de soumission:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Emplacement:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Description:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
                };

                // Créer des labels pour afficher les valeurs
                Label[] values = new Label[]
                {
            new Label { Text = row["ID"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["IMO"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Num_serie"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Designation"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Reference"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Status"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = Convert.ToDateTime(row["Date_soumission"]).ToString("dd/MM/yyyy"), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Emplacement"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
            new Label { Text = row["Description"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
                };

                // Ajouter les labels et valeurs au formulaire
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Location = new Point(marginLeftLabels, marginTop + (i * 40)); // Position des labels
                    values[i].Location = new Point(marginLeftValues, marginTop + (i * 40)); // Position des valeurs

                    form.Controls.Add(labels[i]);
                    form.Controls.Add(values[i]);
                }

                // Bouton Modifier
                Button btnModifier = new Button();
                btnModifier.Text = "Modifier";
                btnModifier.Font = new Font("Arial", 10, FontStyle.Bold);
                btnModifier.Size = new Size(100, 40);
                btnModifier.BackColor = ColorTranslator.FromHtml("#577B93");
                btnModifier.ForeColor = Color.White;
                btnModifier.FlatStyle = FlatStyle.Flat;
                btnModifier.Location = new Point(form.Width - 220, form.Height - 80); // Position en bas à droite
                btnModifier.Click += (s, ev) =>
                {
                    form.Close();
                    // Remplir les TextBox dans le formulaire principal pour permettre la modification
                    txtid.Text = row["ID"].ToString();
                    txti.Text = row["IMO"].ToString();
                    txtns.Text = row["Num_serie"].ToString();
                    txtt.Text = row["Designation"].ToString();
                    txtr.Text = row["Reference"].ToString();
                    txts.Text = row["Status"].ToString();
                    txtds.Value = Convert.ToDateTime(row["Date_soumission"]);
                    txte.Text = row["Emplacement"].ToString();
                    txtd.Text = row["Description"].ToString();
                    lb_photo.Text = row["Photo"].ToString();

                    // Charger l'image de photo
                    string photoPath = AppDomain.CurrentDomain.BaseDirectory + @"img\Materiels\" + lb_photo.Text;
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(lb_photo.Text) && System.IO.File.Exists(photoPath))
                        {
                            picture.Image = Image.FromFile(photoPath);
                        }
                        else
                        {
                            picture.Image = null; // ou une image par défaut
                            MessageBox.Show("La photo est introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors du chargement de la photo : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picture.Image = null; // ou une image par défaut
                    }

                    ajouter.Enabled = false;
                    modifier.Enabled = true;
                    supprimer.Enabled = true;
                };
                form.Controls.Add(btnModifier);

                // Bouton Annuler
                Button btnAnnuler = new Button();
                btnAnnuler.Text = "Annuler";
                btnAnnuler.Font = new Font("Arial", 10, FontStyle.Bold);
                btnAnnuler.Size = new Size(100, 40);
                btnAnnuler.BackColor = Color.Gray;
                btnAnnuler.ForeColor = Color.White;
                btnAnnuler.FlatStyle = FlatStyle.Flat;
                btnAnnuler.Location = new Point(form.Width - 110, form.Height - 80); // Position en bas à droite à côté de Modifier
                btnAnnuler.Click += (s, ev) =>
                {
                    form.Close();
                    // Optionnel : réinitialiser les champs si nécessaire
                };
                form.Controls.Add(btnAnnuler);

                // Afficher le formulaire
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucun matériel trouvé avec le numéro IMO donné.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Utils.CloseConnection();


        }
    }
}
