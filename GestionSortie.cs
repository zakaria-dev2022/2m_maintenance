using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class GestionSortie
    {
            public int Id { get; set; }
            public string Imo { get; set; }
            public string NumSerie { get; set; }
            public string Designation { get; set; }
            public string Reference { get; set; }
            public string Status { get; set; }
            public DateTime DateSoumission { get; set; }
            public string Emplacement { get; set; }
            public string Description { get; set; }
            public string Photo { get; set; }
            public DateTime DateCreation { get; set; }
            public DateTime DateSortie { get; set; } // Peut être null si pas encore sorti
            public string Destination { get; set; }
            public string Raison { get; set; }

            // Constructeur
            public GestionSortie(string imo, string numSerie, string designation, string reference, string status, DateTime dateSoumission, string emplacement, string description, string photo, DateTime dateSortie, string destination, string raison)
            {
                this.Imo = imo;
                this.NumSerie = numSerie;
                this.Designation = designation;
                this.Reference = reference;
                this.Status = status;
                this.DateSoumission = dateSoumission;
                this.Emplacement = emplacement;
                this.Description = description;
                this.Photo = photo;
                this.DateCreation = DateTime.Now; // Date de création automatique
                this.DateSortie = dateSortie;
                this.Destination = destination;
                this.Raison = raison;
            }

        // Méthode pour ajouter un matériel
        public static void AjouterMateriel(GestionSortie materiel)
        {
            try
            {
                Utils.OpenConnection();

                // Insérer dans la table materiels
                string query = "INSERT INTO materiels (imo, num_serie, designation, reference, status, date_soumission, emplacement, description, photo, date_sortie, destination, raison) " +
                               "VALUES (@Imo, @NumSerie, @Designation, @Reference, @Status, @DateSoumission, @Emplacement, @Description, @Photo, @DateSortie, @Destination, @Raison)";

                MySqlCommand command = new MySqlCommand(query, Utils.cnx);

                command.Parameters.AddWithValue("@Imo", materiel.Imo);
                command.Parameters.AddWithValue("@NumSerie", materiel.NumSerie);
                command.Parameters.AddWithValue("@Designation", materiel.Designation);
                command.Parameters.AddWithValue("@Reference", materiel.Reference ?? (object)DBNull.Value); // Permet NULL
                command.Parameters.AddWithValue("@Status", materiel.Status);
                command.Parameters.AddWithValue("@DateSoumission", materiel.DateSoumission);
                command.Parameters.AddWithValue("@Emplacement", materiel.Emplacement);
                command.Parameters.AddWithValue("@Description", materiel.Description);
                command.Parameters.AddWithValue("@Photo", materiel.Photo);
                command.Parameters.AddWithValue("@DateSortie", materiel.DateSortie);
                command.Parameters.AddWithValue("@Destination", materiel.Destination);
                command.Parameters.AddWithValue("@Raison", materiel.Raison);

                command.ExecuteNonQuery();
                MessageBox.Show("Le matériel a été ajouté avec succès", "Gestion des Matériels");

                // Vérifier si le matériel existe déjà dans gestion_sortie
                string selectQuery = "SELECT COUNT(*) FROM gestion_sortie WHERE imo = @Imo AND num_serie = @NumSerie";
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, Utils.cnx);
                selectCommand.Parameters.AddWithValue("@Imo", materiel.Imo);
                selectCommand.Parameters.AddWithValue("@NumSerie", materiel.NumSerie);

                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                if (count > 0) // Si le matériel existe dans gestion_sortie
                {
                    // Supprimer le matériel de la table gestion_entrer
                    string deleteQuery = "DELETE FROM gestion_entrer WHERE imo = @Imo AND num_serie = @NumSerie";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, Utils.cnx);
                    deleteCommand.Parameters.AddWithValue("@Imo", materiel.Imo);
                    deleteCommand.Parameters.AddWithValue("@NumSerie", materiel.NumSerie);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Le matériel a été supprimé de la table gestion_entrer.", "Gestion des Matériels");
                    }
                    else
                    {
                        MessageBox.Show("Le matériel n'a pas été trouvé dans la table gestion_entrer.", "Gestion des Matériels");
                    }
                }
                else
                {
                    MessageBox.Show("Le matériel n'est pas encore marqué comme sorti dans gestion_sortie.", "Gestion des Matériels");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du matériel : {ex.Message}");
            }
            finally
            {
                Utils.CloseConnection();
            }
        }


        // Méthode pour modifier un matériel
        public static void ModifierMateriel(GestionSortie materiel, int id)
            {
                try
                {
                    Utils.OpenConnection();

                    string query = "UPDATE materiels SET imo = @Imo, num_serie = @NumSerie, designation = @Designation, reference = @Reference, " +
                                   "status = @Status, date_soumission = @DateSoumission, emplacement = @Emplacement, " +
                                   "description = @Description, photo = @Photo, date_sortie = @DateSortie, destination = @Destination, raison = @Raison " +
                                   "WHERE id = @Id";

                    MySqlCommand command = new MySqlCommand(query, Utils.cnx);

                    command.Parameters.AddWithValue("@Imo", materiel.Imo);
                    command.Parameters.AddWithValue("@NumSerie", materiel.NumSerie);
                    command.Parameters.AddWithValue("@Designation", materiel.Designation);
                    command.Parameters.AddWithValue("@Reference", materiel.Reference);
                    command.Parameters.AddWithValue("@Status", materiel.Status);
                    command.Parameters.AddWithValue("@DateSoumission", materiel.DateSoumission);
                    command.Parameters.AddWithValue("@Emplacement", materiel.Emplacement);
                    command.Parameters.AddWithValue("@Description", materiel.Description);
                    command.Parameters.AddWithValue("@Photo", materiel.Photo);
                    command.Parameters.AddWithValue("@DateSortie", materiel.DateSortie);
                    command.Parameters.AddWithValue("@Destination", materiel.Destination);
                    command.Parameters.AddWithValue("@Raison", materiel.Raison);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Le matériel a été modifié avec succès", "Gestion des Matériels");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la modification du matériel : {ex.Message}");
                }
                finally
                {
                    Utils.CloseConnection();
                }
            }
        
    }
}
