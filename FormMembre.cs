using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    public partial class FormMembre : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        string chemin = "";
        public FormMembre()
        {
            InitializeComponent();
        }
        void remplir()
        {
            Utils.CloseConnection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * from membres");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            tableau.Columns["Profil"].Visible = false;
            tableau.Columns["DateCreation"].Visible = false;
            for (int i = 1; i < tableau.Columns.Count; i++)
            {
                tableau.Columns[i].Width = 124; // Définit chaque colonne à une largeur de 200 unités
            }
            nouveau();

        }
        void nouveau()
        {
            txtcode.Text = string.Empty;
            txtn.Text = string.Empty;
            txtp.Text = string.Empty;
            txtc.Text = string.Empty;
            txtt.Text = string.Empty;
            txtgm.Text = string.Empty;
            lb_profil.Text = string.Empty;
            picture.Image = null;
            chkM.Checked = false;
            chkF.Checked = false;
            txtcode.Focus();
            txtd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ajouter.Enabled = true;
            modifier.Enabled = false;
            supprimer.Enabled = false;

        }

        private void FormMembre_Load(object sender, EventArgs e)
        {
            remplir();
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
                lb_profil.Text = $"{DateTime.Now:yyyy_MM_dd HH-mm-ss} -" + txtcode.Text + typeFile;
                chemin = lb_profil.Text;
                //chemin =txtmt.Text + " Photo voiture" : typeFile;
                //File.Copy(fileinfo.FullName, Application.StartupPath + "/img_client/" + chemin);
                File.Copy(fileinfo.FullName, AppDomain.CurrentDomain.BaseDirectory + @"img\Membres\" + chemin);

            }
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if (txtcode.Text != "" &&txtn.Text != "" && txtp.Text != "" && txtc.Text != "" && txtt.Text != "" && txtgm.Text != "" && txtd.Text != "")
            {
                // Vérifier le genre sélectionné
                string genre = "";
                if (chkM.Checked)
                {
                    genre = "M";
                }
                else if (chkF.Checked)
                {
                    genre = "F";
                }

                // Assurez-vous qu'un genre est sélectionné
                if (string.IsNullOrEmpty(genre))
                {
                    MessageBox.Show("Veuillez sélectionner un genre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Récupérer les autres valeurs
                string code = txtcode.Text.ToString();
                string nom = txtn.Text.ToString();
                string prenom = txtp.Text.ToString();
                string tel = txtt.Text.ToString();
                string gmail = txtgm.Text.ToString();
                string cin = txtc.Text.ToString();
                string specialite = txts.Text.ToString();
                DateTime dateNaissance = txtd.Value;
                string profil = lb_profil.Text.ToString(); // Peut-être ajouté plus tard si nécessaire

                // Créer une instance de Client
                Membres membre = new Membres(code.ToUpper(), nom, prenom, tel, cin.ToUpper(), gmail, specialite, genre, dateNaissance, profil);

                // Appeler la méthode pour ajouter le client
                Membres.AjouterMembre(membre);
                remplir();

            }
            else
            {
                MessageBox.Show("Veuillez remplir toute les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection();
            if (MessageBox.Show("Voulez-vous supprimer Ce Membre?", "2M", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Utils.SuprimerDonner("Membres", txtid.Text);
                MessageBox.Show("Supression Avec Success", "2M");
                remplir();
            }
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            // Vérification que tous les champs sont remplis
            if (txtcode.Text != "" && txtn.Text != "" && txtp.Text != "" && txtc.Text.ToUpper() != "" && txtgm.Text != "" && txtt.Text != "")
            {
                // Gestion du genre via les CheckBox (si applicable)
                string genre = chkM.Checked ? "M" : "F";

                // Création de l'objet Client avec les valeurs des TextBox
                Membres membre = new Membres(txtcode.Text.ToUpper(), txtn.Text, txtp.Text, txtt.Text, txtc.Text.ToUpper(), txtgm.Text, txts.Text, genre, txtd.Value, lb_profil.Text);

                // Obtenir l'ID du client à modifier
                int id = int.Parse(txtid.Text);

                // Appel de la méthode ModifierClient pour effectuer la mise à jour
                Membres.ModifierMembre(membre, id);

                // Réinitialisation des champs du formulaire et mise à jour de l'affichage
                remplir();

                // Afficher un message de confirmation
                MessageBox.Show("Les informations du client ont été modifiées avec succès.", "Modification Client");
            }
            else
            {
                // Afficher un message d'erreur si tous les champs ne sont pas remplis
                MessageBox.Show("Veuillez remplir tous les champs avant de modifier.", "Erreur de Modification");
            }
        }



        private void tableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = tableau.Rows.Count - 1;
            if (e.RowIndex >= 0 && e.RowIndex < n)
            {
                DataGridViewRow row = tableau.Rows[e.RowIndex];

                // Récupération des valeurs dans les TextBox
                txtid.Text = row.Cells["Id"].Value.ToString();
                txtcode.Text = row.Cells["Code"].Value.ToString();
                txtn.Text = row.Cells["Nom"].Value.ToString();
                txtp.Text = row.Cells["Prenom"].Value.ToString();
                txtt.Text = row.Cells["Tel"].Value.ToString();
                txtc.Text = row.Cells["CIN"].Value.ToString();
                txtgm.Text = row.Cells["Gmail"].Value.ToString();
                txtd.Text = row.Cells["DateNaissance"].Value.ToString();
                txts.Text = row.Cells["Specialite"].Value.ToString();
                lb_profil.Text = row.Cells["Profil"].Value.ToString();

                // Chargement de l'image de photo
                string photoPath = AppDomain.CurrentDomain.BaseDirectory + @"img\Membres\" + lb_profil.Text;
                try
                {
                    if (!string.IsNullOrWhiteSpace(lb_profil.Text) && System.IO.File.Exists(photoPath))
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
                supprimer.Enabled = true;

                // Gestion de la sélection du genre
                string genre = row.Cells["Genre"].Value.ToString();
                if (genre == "M")
                {
                    chkM.Checked = true;
                    chkF.Checked = false;
                }
                else if (genre == "F")
                {
                    chkM.Checked = false;
                    chkF.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Aucun élément sélectionné", "2M");

                // Réinitialiser les contrôles et remplir à nouveau les données
                remplir();
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Utils.CloseConnection();

            // Demander à l'utilisateur d'entrer le CIN du membre
            string ncin = Microsoft.VisualBasic.Interaction.InputBox("Entrer Code du Membre que vous recherchez", "Recherche Membre");

            // Obtenir les données du membre en fonction du CIN
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM membres WHERE code = '" + ncin + "'");

            // Vérifier si des données ont été trouvées
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                // Création d'un nouveau formulaire personnalisé pour afficher les résultats
                Form form = new Form();
                form.Text = $"Information du {row["Nom"]}"; // Titre avec le nom du membre recherché
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
                lblTitle.Text = $"Information du {row["Nom"]} {row["Prenom"]}";
                lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
                lblTitle.ForeColor = Color.Black;
                lblTitle.AutoSize = true;
                lblTitle.Location = new Point((form.Width - lblTitle.Width) / 4, 20); // Centrer le titre en haut
                form.Controls.Add(lblTitle);
                marginTop = lblTitle.Location.Y + lblTitle.Height + marginBottomTitle;

                // Créer des étiquettes pour chaque détail
                Label[] labels = new Label[]
                {
            new Label { Text = "ID:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Code:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Nom:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Prénom:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Téléphone:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "CIN:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Gmail:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Date de Naissance:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            new Label { Text = "Spécialité:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black },
            //new Label { Text = "Profil:", Font = new Font("Arial", 14, FontStyle.Bold), ForeColor = Color.Black }
                };

                // Assurer que la date s'affiche au bon format (sans l'heure)
                string dateNaissance = Convert.ToDateTime(row["DateNaissance"]).ToString("dd/MM/yyyy"); // Formater la date en jour/mois/année
                // Créer des labels pour afficher les valeurs avec AutoSize activé et largeur ajustée
                Label[] values = new Label[]
                {
             new Label { Text = row["Id"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = row["Code"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = row["Nom"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = row["Prenom"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = row["Tel"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = row["CIN"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = row["Gmail"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
             new Label { Text = dateNaissance, Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) }, // Afficher la date formatée
             new Label { Text = row["Specialite"].ToString(), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = ColorTranslator.FromHtml("#577B93"), AutoSize = true, MaximumSize = new Size(400, 0) },
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
                    txtid.Text = row["Id"].ToString();
                    txtcode.Text = row["Code"].ToString();
                    txtn.Text = row["Nom"].ToString();
                    txtp.Text = row["Prenom"].ToString();
                    txtt.Text = row["Tel"].ToString();
                    txtc.Text = row["CIN"].ToString();
                    txtgm.Text = row["Gmail"].ToString();
                    txtd.Text = row["DateNaissance"].ToString();
                    txts.Text = row["Specialite"].ToString();
                    lb_profil.Text = row["Profil"].ToString();
                    // Chargement de l'image de photo
                    string photoPath = AppDomain.CurrentDomain.BaseDirectory + @"img\Membres\" + lb_profil.Text;
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(lb_profil.Text) && System.IO.File.Exists(photoPath))
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

                    string genre = row["Genre"].ToString();
                    if (genre == "M")
                    {
                        chkM.Checked = true;
                        chkF.Checked = false;
                    }
                    else if (genre == "F")
                    {
                        chkM.Checked = false;
                        chkF.Checked = true;
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
                    nouveau();
                };
                form.Controls.Add(btnAnnuler);

                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aucun membre trouvé avec le CIN fourni.", "Erreur de recherche", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
