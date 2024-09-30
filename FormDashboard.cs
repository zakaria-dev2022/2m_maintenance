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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            Utils.AfficherLogo(logo);
            Utils.statistique(lb_materiel,"gestion_entrer");
            Utils.statistique(lb_pretmateriel,"pret_materiel");
            Utils.statistiqueIntervention(lb_intervention);
        }

        private void btnMembre_Click(object sender, EventArgs e)
        {
            FormMembre formMembres = new FormMembre();
            formMembres.Show();
            this.Hide();
        }

        private void btnMateriel_Click(object sender, EventArgs e)
        {
            if (btnmaterielEntrer.Visible == true)
            {
                btnmaterielEntrer.Visible = false;
                btnmaterielSortie.Visible = false;
                flechTop.Visible = false;
                flechBotom.Visible = true;

            }
            else
            {
                btnmaterielSortie.Visible = true;
                btnmaterielEntrer.Visible = true;
                flechTop.Visible = true;
                flechBotom.Visible = false;

            }
        }

        private void btnmaterielEntrer_Click(object sender, EventArgs e)
        {
            FormGestionEtrer formGestionEtrer = new FormGestionEtrer();
            formGestionEtrer.Show();
            this.Hide();
        }

        private void btnReduire_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Voulez-Vous Déconneceter", "2m", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormConnection formConnection = new FormConnection();
                formConnection.Show();
                this.Hide();
            }
        }

        private void btnmaterielSortie_Click(object sender, EventArgs e)
        {
            FormGestionSortie formGestionSortie = new FormGestionSortie();
            formGestionSortie.Show();
            this.Hide();
        }

        private void btnPretMateriel_Click(object sender, EventArgs e)
        {
            FormPretMateriel formPretMateriel = new FormPretMateriel();
            formPretMateriel.Show();
            this.Hide();
        }

        private void flechBotom_Click(object sender, EventArgs e)
        {
            btnMateriel_Click(sender,e);
        }

        private void flechTop_Click(object sender, EventArgs e)
        {
            btnMateriel_Click(sender, e);
        }

        private void btnIntervention_Click(object sender, EventArgs e)
        {
            FormIntervention formIntervention = new FormIntervention();
            formIntervention.Show();
            this.Hide();
        }

        private void btnParametre_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection(); // Fermer toute connexion ouverte

            // Demander à l'utilisateur d'entrer le numéro IMO du matériel
            string pw = Microsoft.VisualBasic.Interaction.InputBox("Entrer le Mot De Passe du Admin", "2M");

            // Vérifier si l'IMO est vide
            if (string.IsNullOrWhiteSpace(pw))
            {
                //MessageBox.Show("Le numéro CIN ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Requête SQL pour obtenir les données du matériel
            DataTable dataTable = Utils.ObtenirDonnees("SELECT * FROM admin WHERE password = '" + pw + "'");

            // Si des données sont trouvées
            if (dataTable.Rows.Count > 0)
            {
                FormSetting formSetting = new FormSetting();
                formSetting.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Le Mot De Passe Est Incorrecte.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           
        }
    }
}
