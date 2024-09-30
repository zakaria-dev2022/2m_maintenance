using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2M_Maintenace
{
    internal class Utils
    {
        public static MySqlConnection cnx = new MySqlConnection("server=localhost;database=2m_maintenance;uid=root;password=");
        public static DataTable dataTable = new DataTable();

        public static void OpenConnection()
        {
            try
            {
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                    // Console.WriteLine("Connexion à la base de données ouverte avec succès.");
                    //MessageBox.Show("Connexion à la base de données ouverte avec succès.", "Zakaria Location");
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Erreur lors de l'ouverture de la connexion : " + ex.Message);
                //MessageBox.Show("Erreur lors de l'ouverture de la connexion : " + ex.Message, "Zakaria Location");
            }
        }

        // Méthode pour fermer la connexion
        public static void CloseConnection()
        {
            try
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                    //Console.WriteLine("Connexion à la base de données fermée avec succès.");
                    // MessageBox.Show("Connexion à la base de données fermer avec succès.", "Zakaria Location");
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Erreur lors de la fermeture de la connexion : " + ex.Message);
                //MessageBox.Show("Connexion à la base de données fermer avec succès.", "Zakaria Location");
            }
        }


        public static void SuprimerDonner(string table, string id)
        {
            try
            {
                {
                    cnx.Open();

                    string query = $"delete from {table} where id=  {id}";

                    //using (SqlCommand command = new SqlCommand(query,cnx))
                    MySqlCommand command = new MySqlCommand(query, cnx);
                    {
                        command.ExecuteNonQuery();
                        //Console.WriteLine($"La colonne {id} a été supprimée de la table {table} avec succès.");
                        //MessageBox.Show($"La colonne {id} a été supprimée de la table {table} avec succès.", "Zakaria Location");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression de la colonne : {ex.Message}");
                // MessageBox.Show($"Erreur lors de la suppression de la colonne : {ex.Message}");
            }
        }

        public static void obtenirNomApp(Label label)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                string query = $"SELECT nom_app FROM admin where id =1 "; // Requête SQL pour compter les employés

                MySqlCommand command = new MySqlCommand(query, cnx);
                string appName = command.ExecuteScalar()?.ToString(); // Exécutez la requête et récupérez le nom de l'application
                label.Text = appName;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Gestion Restaurant");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }
        }

        public static DataTable ObtenirDonnees(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);

                {
                    cnx.Open();
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des données : {ex.Message}");
                MessageBox.Show($"Erreur lors de la récupération des données .{ex.Message}", "Zakaria Location");
            }

            return dataTable;
        }

        public static void AfficherLogo(PictureBox pictureBox)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                string query = "SELECT logo FROM admin WHERE id = @Id"; // Requête SQL pour récupérer le chemin de l'image de la table admin
                MySqlCommand command = new MySqlCommand(query, cnx);
                command.Parameters.AddWithValue("@Id", 1); // Remplacer 1 par l'ID de l'admin dont vous voulez afficher l'image

                // Récupérer le chemin de l'image à partir de la base de données
                string imagePath = (string)command.ExecuteScalar();

                pictureBox.Load(AppDomain.CurrentDomain.BaseDirectory + @"\img\" + imagePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Zakaria Location");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }
        }

        public static void VerifierLogin(string email, string password)
        {
            bool isValidAdmin = false; // Variable pour vérifier si l'utilisateur est un admin
            bool isValidProfil = false; // Variable pour vérifier si l'utilisateur est un profil standard

            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour vérifier si l'email et le mot de passe correspondent dans la table admin
                string query = "SELECT COUNT(*) FROM admin WHERE email = @Email AND password = @Password";
                MySqlCommand command = new MySqlCommand(query, cnx);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password); // Assurez-vous que le mot de passe est hashé (par exemple, avec bcrypt)

                // Exécuter la requête pour la table admin
                int count = Convert.ToInt32(command.ExecuteScalar());

                // Si un administrateur est trouvé
                if (count > 0)
                {
                    isValidAdmin = true;
                }
                else
                {

                    // Si aucun résultat n'est trouvé dans la table admin, vérifier dans la table profil
                    isValidProfil = VerifierProfil(email, password); // Appeler la fonction VerifierProfil
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la vérification du login : " + ex.Message);
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion
            }

            // Affichage du formulaire en fonction du rôle de l'utilisateur
            if (isValidAdmin)
            {
                // Afficher le formulaire du tableau de bord admin
                FormDashboard dashboard = new FormDashboard();
                dashboard.Show();
                Application.OpenForms["FormConnection"].Hide();
            }
            else if (isValidProfil)
            {
                // Afficher le formulaire du tableau de bord profil standard
                FormDashboard dash = new FormDashboard();
                dash.Show();
                Application.OpenForms["FormConnection"].Hide();
            }
            else
            {
                // Afficher un message d'erreur si les identifiants ne sont pas valides
                MessageBox.Show("Identifiants incorrects. Veuillez réessayer.");
            }
        }

        public static bool VerifierProfil(string email, string password)
        {
            bool isAuthenticated = false;

            try
            {
                Utils.OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour vérifier si le Gmail se trouve dans la table membre
                string query = "SELECT id FROM membres WHERE Gmail = @Email";
                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                command.Parameters.AddWithValue("@Email", email);

                // Exécuter la requête pour obtenir l'ID de l'utilisateur dans la table membre
                object membreIdObj = command.ExecuteScalar();

                // Vérifier si un membre a été trouvé
                if (membreIdObj != null)
                {
                    int membreId = Convert.ToInt32(membreIdObj); // Convertir l'ID en entier

                    // Si un membre est trouvé, vérifier si le membre_id de la table profil correspond et que le mot de passe est correct
                    query = "SELECT COUNT(*) FROM profils WHERE membre_id = @MembreId AND password = @Password";
                    command = new MySqlCommand(query, Utils.cnx);
                    command.Parameters.AddWithValue("@MembreId", membreId);
                    command.Parameters.AddWithValue("@Password", password); // Assurez-vous de comparer un mot de passe haché

                    // Exécuter la requête pour la table profil
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    // Si le compte est trouvé dans la table profil avec le mot de passe correct, authentification réussie
                    if (count > 0)
                    {
                        isAuthenticated = true;
                    }
                    else
                    {

                        Console.WriteLine("Mot de passe incorrect pour le profil avec membre_id: " + membreId);
                    }
                }
                else
                {
                    Console.WriteLine("Aucun membre trouvé avec cet email : " + email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la vérification du login : " + ex.Message);
            }
            finally
            {
                if (Utils.cnx.State == System.Data.ConnectionState.Open)
                    Utils.cnx.Close(); // Fermer la connexion
            }

            return isAuthenticated; // Retourner true si authentifié, sinon false
        }

        public static void statistique(Label label,string table)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour sélectionner toutes les réservations pour la date de demain
                string query = $"SELECT COUNT(*) FROM "+table;

                MySqlCommand command = new MySqlCommand(query, cnx);
                int statistique = Convert.ToInt32(command.ExecuteScalar());

                // Afficher le nombre de réservations dans la Label
                label.Text = statistique.ToString();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                //MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Gestion Restaurant");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }
        }
        
        public static void statistiqueIntervention(Label label)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                // Requête SQL pour sélectionner toutes les réservations pour la date de demain
                string query = $"SELECT COUNT(*) FROM intervention where status ='A Faire'";

                MySqlCommand command = new MySqlCommand(query, cnx);
                int statistique = Convert.ToInt32(command.ExecuteScalar());

                // Afficher le nombre de réservations dans la Label
                label.Text = statistique.ToString();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                //MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Gestion Restaurant");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }
        }











    }
}
