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
            Utils.statistique(lb_intervention, "intervention");
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
    }
}
