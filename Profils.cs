using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2M_Maintenace
{
    internal class Profils
    {
        public int MembreId { get; set; }
        public string Password { get; set; }

        // Constructeur pour la classe Profils
        public Profils(int membreId, string password)
        {
            this.MembreId = membreId;
            this.Password = password;
        }

        // Méthode pour ajouter un profil dans la base de données
        public static void AjouterProfil(int membreId, string password)
        {
            try
            {
                Utils.OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour insérer un nouveau profil
                string query = "INSERT INTO profils (membre_id, password) VALUES (@MembreId, @Password)";
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                command.Parameters.AddWithValue("@MembreId", membreId);
                command.Parameters.AddWithValue("@Password", password); // Assurez-vous de stocker le mot de passe hashé

                command.ExecuteNonQuery(); // Exécuter la requête d'insertion
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'insertion du profil : " + ex.Message);
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close(); // Fermer la connexion
            }
        }

        // Méthode pour mettre à jour le mot de passe d'un profil
        public static void ModifierPassword(int membreId, string newPassword)
        {
            try
            {
                Utils.OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour mettre à jour le mot de passe
                string query = "UPDATE profil SET password = @NewPassword WHERE membre_id = @MembreId";
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                command.Parameters.AddWithValue("@MembreId", membreId);
                command.Parameters.AddWithValue("@NewPassword", newPassword);

                command.ExecuteNonQuery(); // Exécuter la requête de mise à jour
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la mise à jour du mot de passe : " + ex.Message);
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close(); // Fermer la connexion
            }
        }
    }
}
