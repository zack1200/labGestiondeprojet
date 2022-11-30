using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labgestiondeprojet
{
    internal class GestionBDE
    {
        MySqlConnection con;
        ObservableCollection<Employe> liste2;
        static GestionBDE gestionBDE = null;
        public GestionBDE()
        {
            //ne pas oublier de mettre vos informtions de connexion
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2023268-zakaria-el-bahodi;Uid=2023268;Pwd=2023268;"); ;
            liste2 = new ObservableCollection<Employe>();
        }
        public static GestionBDE getInstance()
        {
            if (gestionBDE == null)
                gestionBDE = new GestionBDE();

            return gestionBDE;
        }
        public ObservableCollection<Employe> GetEmployes()
        {
            liste2.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Employe e = new Employe()
                {
                    Matricule = r.GetString("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom"),
                    
                   

                };

                liste2.Add(e);
            }

            r.Close();
            con.Close();
            return liste2;
        }
       

        public void AjouterEmployer(Employe e)
        {
            string matricule = e.Matricule;
            string nom = e.Nom;
            string prenom = e.Prenom;


            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values(@matricule, @nom, @prenom) ";

                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
               


                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        public ObservableCollection<Employe> rechercher_employeN(string name)
        {
            try
            {
                liste2.Clear();
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from employe where nom = '" + name + "' or prenom ='"+ name + "'" ;
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    liste2.Add(new Employe()
                    {
                        Matricule = r.GetString(0),
                        Nom = r.GetString(1),
                        Prenom = r.GetString(2)

                    });
                }
                r.Close();
                con.Close();
                return liste2;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return null;
            }

        }
       


    }
}
