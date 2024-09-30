using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class Intervention
    {
            // Propriétés
            public int Id { get; set; }                        // Identifiant unique auto-incrémenté
            public int MembreId { get; set; }                  // Référence à l'ID du membre (clé étrangère)
            public string Type { get; set; }                   // Type d'intervention (ex: Maintenance, Réparation)
            public string Status { get; set; }                 // Statut de l'intervention (ex: En cours, Terminé)
            public DateTime Date { get; set; }                 // Date de l'intervention
            public string Emplacement { get; set; }            // Emplacement de l'intervention
            public string Description { get; set; }            // Description de l'intervention
            public DateTime DateCreation { get; set; }

        // Constructeur avec paramètres
        public Intervention(int membreId, string type, string status, DateTime date, string emplacement, string description)
            {
                MembreId = membreId;
                Type = type;
                Status = status;
                Date = date;
                Emplacement = emplacement;
                Description = description;
            this.DateCreation = DateTime.Now; // La date de création est définie automatiquement
        }

        // Méthode pour ajouter une intervention dans la base de données
        public static void AjouterIntervention(Intervention intervention)
        {
            try
            {
                Utils.OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour insérer une nouvelle intervention
                string query = "INSERT INTO intervention (membre_id, type, status, date, emplacement, description) " +
                               "VALUES (@MembreId, @Type, @Status, @Date, @Emplacement, @Description)";
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                command.Parameters.AddWithValue("@MembreId", intervention.MembreId);
                command.Parameters.AddWithValue("@Type", intervention.Type);
                command.Parameters.AddWithValue("@Status", intervention.Status);
                command.Parameters.AddWithValue("@Date", intervention.Date);
                command.Parameters.AddWithValue("@Emplacement", intervention.Emplacement);
                command.Parameters.AddWithValue("@Description", intervention.Description);

                command.ExecuteNonQuery(); // Exécuter la requête d'insertion
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'insertion de l'intervention : " + ex.Message);
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close(); // Fermer la connexion
            }
        }

        // Méthode pour modifier une intervention dans la base de données
        public static void ModifierIntervention(Intervention intervention,int id)
        {
            try
            {
                Utils.OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour mettre à jour une intervention
                string query = "UPDATE intervention SET membre_id = @MembreId,type = @Type, status = @Status, date = @Date, emplacement = @Emplacement, description = @Description " +
                               "WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@MembreId", intervention.MembreId);
                command.Parameters.AddWithValue("@Type", intervention.Type);
                command.Parameters.AddWithValue("@Status", intervention.Status);
                command.Parameters.AddWithValue("@Date", intervention.Date);
                command.Parameters.AddWithValue("@Emplacement", intervention.Emplacement);
                command.Parameters.AddWithValue("@Description", intervention.Description);

                command.ExecuteNonQuery(); // Exécuter la requête de mise à jour
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la mise à jour de l'intervention : " + ex.Message);
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close(); // Fermer la connexion
            }
        }














    }
}
