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
    public partial class FormChargement : Form
    {
        public FormChargement()
        {
            InitializeComponent();
        }

        private void FormChargement_Load(object sender, EventArgs e)
        {
            Utils.obtenirNomApp(nom_app);
            Utils.AfficherLogo(logo);
            timer1.Start();

        }
        int p = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            p++;
            progress.Value = p;
            porssentage.Text = p.ToString() + " %";
            if (progress.Value == 100)
            {
                progress.Value = 0;
                timer1.Stop();
                FormConnection cnx = new FormConnection();
                this.Hide();
                cnx.Show();
            }
        }
    }
}
