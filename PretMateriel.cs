using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class PretMateriel
    {
        public int Id { get; set; }                        // Identifiant unique auto-incrémenté
        public int MembreId { get; set; }                  // Référence à l'ID du membre
        public int MaterielId { get; set; }                // Référence à l'ID du matériel
        public string NomEmprunteur { get; set; }          // Nom de l'emprunteur
        public string PrenomEmprunteur { get; set; }       // Prénom de l'emprunteur
        public string DepartementEmprunteur { get; set; }  // Département de l'emprunteur
        public DateTime DateDebut { get; set; }            // Date de début du prêt
        public DateTime? DateFin { get; set; }             // Date de fin du prêt (facultative)
        public string Raison { get; set; }                 // Raison du prêt

        // Constructeur par défaut
        public PretMateriel() { }

        // Constructeur avec paramètres pour initialiser la classe
        public PretMateriel(int membreId, int materielId, string nomEmprunteur, string prenomEmprunteur, string departementEmprunteur, DateTime dateDebut, DateTime? dateFin, string raison)
        {
            MembreId = membreId;
            MaterielId = materielId;
            NomEmprunteur = nomEmprunteur;
            PrenomEmprunteur = prenomEmprunteur;
            DepartementEmprunteur = departementEmprunteur;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Raison = raison;
        }

        // Méthode pour ajouter un prêt de matériel
        public static void AjouterPretMateriel(PretMateriel pretMateriel)
        {
            try
            {
                Utils.OpenConnection();

                string query = "INSERT INTO pret_materiel (membre_id, materiel_id, nom_emprunteure, prenom_emprunteure, departement_emprunteure, date_debut, date_fin, raison) " +
                               "VALUES (@MembreId, @MaterielId, @NomEmprunteure, @PrenomEmprunteure, @DepartementEmprunteure, @DateDebut, @DateFin, @Raison)";

                MySqlCommand command = new MySqlCommand(query, Utils.cnx);

                command.Parameters.AddWithValue("@MembreId", pretMateriel.MembreId);
                command.Parameters.AddWithValue("@MaterielId", pretMateriel.MaterielId);
                command.Parameters.AddWithValue("@NomEmprunteure", pretMateriel.NomEmprunteur);
                command.Parameters.AddWithValue("@PrenomEmprunteure", pretMateriel.PrenomEmprunteur);
                command.Parameters.AddWithValue("@DepartementEmprunteure", pretMateriel.DepartementEmprunteur);
                command.Parameters.AddWithValue("@DateDebut", pretMateriel.DateDebut);
                command.Parameters.AddWithValue("@DateFin", pretMateriel.DateFin ?? (object)DBNull.Value); // Permet NULL
                command.Parameters.AddWithValue("@Raison", pretMateriel.Raison ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
                MessageBox.Show("Le prêt de matériel a été ajouté avec succès", "Gestion des Prêts de Matériel");
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erreur lors de l'ajout du prêt de matériel : {ex.Message}");
            }
            finally
            {
                Utils.CloseConnection();
            }
        }

        // Méthode pour modifier un prêt de matériel
        public static void ModifierPretMateriel(PretMateriel pretMateriel, int id)
        {
            try
            {
                Utils.OpenConnection();

                string query = "UPDATE pret_materiel SET membre_id = @MembreId, materiel_id = @MaterielId, nom_emprunteure = @NomEmprunteure, " +
                               "prenom_emprunteure = @PrenomEmprunteure, departement_emprunteure = @DepartementEmprunteure, date_debut = @DateDebut, " +
                               "date_fin = @DateFin, raison = @Raison " +
                               "WHERE id = @Id";

                MySqlCommand command = new MySqlCommand(query, Utils.cnx);

                command.Parameters.AddWithValue("@MembreId", pretMateriel.MembreId);
                command.Parameters.AddWithValue("@MaterielId", pretMateriel.MaterielId);
                command.Parameters.AddWithValue("@NomEmprunteure", pretMateriel.NomEmprunteur);
                command.Parameters.AddWithValue("@PrenomEmprunteure", pretMateriel.PrenomEmprunteur);
                command.Parameters.AddWithValue("@DepartementEmprunteure", pretMateriel.DepartementEmprunteur);
                command.Parameters.AddWithValue("@DateDebut", pretMateriel.DateDebut);
                command.Parameters.AddWithValue("@DateFin", pretMateriel.DateFin ?? (object)DBNull.Value); // Permet NULL
                command.Parameters.AddWithValue("@Raison", pretMateriel.Raison ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
                MessageBox.Show("Le prêt de matériel a été modifié avec succès", "Gestion des Prêts de Matériel");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du prêt de matériel : {ex.Message}");
            }
            finally
            {
                Utils.CloseConnection();
            }
        }
















    }
}
