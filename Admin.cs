using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class Admin
    {
        public string nom;
        public string prenom;
        public string email;
        public string password;
        public string nom_app;
        public string logo;

        public Admin(string nom, string prenom, string email, string password, string nom_app, string logo)
        {
            //this.AdminsId = AdminsId;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.password = password;
            this.nom_app = nom_app;
            this.logo = logo;

        }

        public static void ModifierAdmin(Admin Admin)
        {
            try
            {

                {
                    Utils.OpenConnection();

                    string query = "UPDATE Admin SET nom = @nom, prenom = @prenom,email = @email, password = @password,nom_app=@nom_app,logo = @logo WHERE id =1";


                    MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                    {
                        command.Parameters.AddWithValue("@nom", Admin.nom);
                        command.Parameters.AddWithValue("@prenom", Admin.prenom);
                        command.Parameters.AddWithValue("@email", Admin.email);
                        command.Parameters.AddWithValue("@password", Admin.password);
                        command.Parameters.AddWithValue("@nom_app", Admin.nom_app);
                        command.Parameters.AddWithValue("@logo", Admin.logo);
                        //command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Modification effectuée avec succès", "2M");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification des données : {ex.Message}", "2M");
            }
        }

    }
}
