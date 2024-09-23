using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class Membres
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string CIN { get; set; }
        public string Gmail { get; set; }
        public string Specialite { get; set; }
        public string Genre { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Profil { get; set; }
        public DateTime DateCreation { get; private set; }

        public Membres(string nom, string prenom, string tel, string cin, string gmail, string specialite, string genre, DateTime dateNaissance, string profil)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.CIN = cin;
            this.Gmail = gmail;
            this.Specialite = specialite;
            this.Genre = genre;
            this.DateNaissance = dateNaissance;
            this.Profil = profil;
            this.DateCreation = DateTime.Now; // La date de création est définie automatiquement
        }
        // Méthode pour ajouter un membre
        public static void AjouterMembre(Membres membre)
        {
            try
            {
                Utils.OpenConnection();

                string query = "INSERT INTO membres (Nom, Prenom, Tel, CIN, Gmail, Specialite, Genre, DateNaissance, Profil, DateCreation) " +
                               "VALUES (@Nom, @Prenom, @Tel, @CIN, @Gmail, @Specialite, @Genre, @DateNaissance, @Profil, @DateCreation)";

                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                {
                    command.Parameters.AddWithValue("@Nom", membre.Nom);
                    command.Parameters.AddWithValue("@Prenom", membre.Prenom);
                    command.Parameters.AddWithValue("@Tel", membre.Tel);
                    command.Parameters.AddWithValue("@CIN", membre.CIN);
                    command.Parameters.AddWithValue("@Gmail", membre.Gmail);
                    command.Parameters.AddWithValue("@Specialite", membre.Specialite);
                    command.Parameters.AddWithValue("@Genre", membre.Genre);
                    command.Parameters.AddWithValue("@DateNaissance", membre.DateNaissance);
                    command.Parameters.AddWithValue("@Profil", membre.Profil);
                    command.Parameters.AddWithValue("@DateCreation", membre.DateCreation);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Le membre a été ajouté avec succès", "Gestion des Membres");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du membre : {ex.Message}");
            }
        }


        // Méthode pour modifier un membre
        public static void ModifierMembre(Membres membre, int id)
        {
            try
            {
                // Ouvrir la connexion à la base de données
                Utils.OpenConnection();

                // Requête SQL pour mettre à jour les informations du membre
                string query = "UPDATE membres SET Nom = @Nom, Prenom = @Prenom, Tel = @Tel, CIN = @CIN, " +
                               "Gmail = @Gmail, Specialite = @Specialite, Genre = @Genre, DateNaissance = @DateNaissance, Profil = @Profil " +
                               "WHERE Id = @Id";

                // Créer la commande MySQL
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                {
                    // Ajouter les paramètres à la commande
                    command.Parameters.AddWithValue("@Nom", membre.Nom);
                    command.Parameters.AddWithValue("@Prenom", membre.Prenom);
                    command.Parameters.AddWithValue("@Tel", membre.Tel);
                    command.Parameters.AddWithValue("@CIN", membre.CIN);
                    command.Parameters.AddWithValue("@Gmail", membre.Gmail);
                    command.Parameters.AddWithValue("@Specialite", membre.Specialite);
                    command.Parameters.AddWithValue("@Genre", membre.Genre);
                    command.Parameters.AddWithValue("@DateNaissance", membre.DateNaissance);
                    command.Parameters.AddWithValue("@Profil", membre.Profil);
                    command.Parameters.AddWithValue("@Id", id);  // Paramètre pour l'ID du membre à modifier

                    // Exécuter la requête
                    command.ExecuteNonQuery();

                    // Afficher un message de confirmation
                    MessageBox.Show("Le membre a été modifié avec succès", "Gestion des Membres");
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                MessageBox.Show($"Erreur lors de la modification du membre : {ex.Message}");
            }
        }


    }
}
