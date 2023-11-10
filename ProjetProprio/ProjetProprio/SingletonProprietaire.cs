using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetProprio
{
    internal class SingletonProprietaire
    {
        static SingletonProprietaire instance = null;
        MySqlConnection con;
        ObservableCollection<Proprietaire> listeProprietaire;
        DataSet ds;

        public SingletonProprietaire()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=h2022_420214_gr02_2052524-charlie-fournier;Uid=2052524;Pwd=2052524;");
            listeProprietaire = new ObservableCollection<Proprietaire>();
        }

        public static SingletonProprietaire getInstance()
        {
            if (instance == null)
                instance = new SingletonProprietaire();

            return instance;
        }

        public ObservableCollection<Proprietaire> getProprietaire()
        {

            listeProprietaire.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Proprietaire");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure; ;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string nom = (string)r["nom"];
                    string prenom = (string)r["prenom"];



                    Proprietaire proprietaire = new Proprietaire { Id = id, Nom = nom, Prenom = prenom};
                    listeProprietaire.Add(proprietaire);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listeProprietaire;


        }

        public void supprimer(int position)
        {
            Proprietaire p = SingletonProprietaire.getInstance().getListe()[position];
            int id = p.Id;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"DELETE FROM proprietaire WHERE id = @id;";

                commande.Parameters.AddWithValue("@id", id);
                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public void update(Proprietaire m, int position)
        {

            Proprietaire propri = SingletonProprietaire.getInstance().getListe()[position];
            int id = propri.Id;

            string nom = propri.Nom;
            string prenom = propri.Prenom;




            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"update proprietaire set nom= @nom, prenom= @prenom WHERE id = @id;";

                commande.Parameters.AddWithValue("@id", id);

                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }


        public void Ajout(Proprietaire propri)
        {
            int id = propri.Id;

            string nom = propri.Nom;
            string prenom = propri.Prenom;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into propriete values(@id, @nom, @prenom)";

                commande.Parameters.AddWithValue("@id", id);

                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public ObservableCollection<Proprietaire> getListe()
        {
            return listeProprietaire;
        }


    }
}