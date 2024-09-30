using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class Assistant
    {

        public int membre_id;
        public string password;

        public Assistant(int membre_id, string password)
        {
            this.membre_id = membre_id;
            this.password = password;
        }

        // Méthode pour ajouter un Assistant
        public static void AjouterAssistant(Assistant assistant)
        {
            try
            {
                Utils.OpenConnection();

                // Vérifier si membre_id existe dans la table profil
                string checkQuery = "SELECT COUNT(*) FROM profils WHERE membre_id = @MembreId";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, Utils.cnx);
                checkCommand.Parameters.AddWithValue("@MembreId", assistant.membre_id);

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count == 0)
                {
                    // Si le membre_id existe, procéder à l'ajout de l'assistant
                    string query = "INSERT INTO profils (membre_id, password) VALUES (@MembreId, @Password)";
                    MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                    command.Parameters.AddWithValue("@MembreId", assistant.membre_id);
                    command.Parameters.AddWithValue("@Password", assistant.password);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Profil ajouté avec succès", "2M");
                }
                else
                {
                    
                MessageBox.Show("Le membre avec cet Code existe déja dans la table profil.", "Erreur");
                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de profil : {ex.Message}");
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close();
            }
        }

        // Méthode pour modifier un Assistant
        public static void ModifierAssistant(Assistant assistant, int id)
        {
            try
            {
                Utils.OpenConnection();

               
                    // Si le membre_id existe, procéder à la modification de l'assistant
                    string query = "UPDATE profils SET membre_id = @MembreId, password = @Password WHERE id = @Id";
                    MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                    command.Parameters.AddWithValue("@MembreId", assistant.membre_id);
                    command.Parameters.AddWithValue("@Password", assistant.password);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Modification effectuée avec succès", "2M");
                   

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de l'assistant : {ex.Message}");
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close();
            }
        }
    }
}
