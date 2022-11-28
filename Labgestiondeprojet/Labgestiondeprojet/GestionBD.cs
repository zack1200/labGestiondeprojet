using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Labgestiondeprojet
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Projet> liste;
        static GestionBD gestionBD = null;
        public GestionBD()
        {
            //ne pas oublier de mettre vos informtions de connexion
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=2023268-zakaria-el-bahodi;Uid=2023268;Pwd=2023268;"); ;
            liste = new ObservableCollection<Projet>();
        }
        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        public ObservableCollection<Projet> GetProjet()
        {
            liste.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Projet c = new Projet()
                {
                    Numero = r.GetString("numero"),
                    Date = r.GetString("debut"),
                    Budget = r.GetString("budget"),
                    Description = r.GetString("description"),
                    Employe = r.GetString("employe"),

                };

                liste.Add(c);
            }

            r.Close();
            con.Close();
            return liste;
        }

        public void AjouterProjet(Projet c)
        {
            string numero =c.Numero;
            string date =c.Date;
            string budget =c.Budget;
            string description =c.Description;
            string employe =c.Employe;


            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into projet values(@numero, @debut, @budget, @description, @employe) ";

                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@debut", date);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@employe", employe);


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
    }
}
