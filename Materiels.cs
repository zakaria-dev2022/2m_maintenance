using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class Materiels
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

        // Constructeur
        public Materiels(string imo, string numSerie, string designation, string reference, string status, DateTime dateSoumission, string emplacement, string description, string photo)
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
            this.DateCreation = DateTime.Now; // La date de création est définie automatiquement
        }

        // Méthode pour ajouter un matériel
        public static void AjouterMateriel(Materiels materiel)
        {
            try
            {
                Utils.OpenConnection();

                string query = "INSERT INTO materiels (imo, num_serie, designation, reference, status, date_soumission, emplacement, description, photo) " +
                               "VALUES (@Imo, @NumSerie, @Designation, @Reference, @Status, @DateSoumission, @Emplacement, @Description, @Photo)";

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

                command.ExecuteNonQuery();
                MessageBox.Show("Le matériel a été ajouté avec succès", "Gestion des Matériels");
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
        public static void ModifierMateriel(Materiels materiel, int id)
        {
            try
            {
                Utils.OpenConnection();

                string query = "UPDATE materiels SET imo = @Imo, num_serie = @NumSerie, designation = @Designation, reference = @Reference, " +
                               "status = @Status, date_soumission = @DateSoumission, emplacement = @Emplacement, " +
                               "description = @Description, photo = @Photo " +
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
