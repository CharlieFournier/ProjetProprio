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
    internal class SingletonPropriete
    {
        static SingletonPropriete instance = null;
        MySqlConnection con;
        ObservableCollection<Propriete> listePropriete;
        DataSet ds;

        public SingletonPropriete()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=h2022_420214_gr02_2052524-charlie-fournier;Uid=2052524;Pwd=2052524;");
            listePropriete = new ObservableCollection<Propriete>();
        }

        public static SingletonPropriete getInstance()
        {
            if (instance == null)
                instance = new SingletonPropriete();

            return instance;
        }

        public ObservableCollection<Propriete> getPropriete()
        {

            listePropriete.Clear();
            try
            {
                MySqlCommand commande = new MySqlCommand("P_Select_Propriete");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure; ;

                con.Open();

                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string categorie = (string)r["categorie"];
                    double prix = (double)r["prix"];
                    string ville = (string)r["ville"];
                    int idproprio = (int)r["idproprio"];



                    Propriete propriete = new Propriete { Id = id, Categorie = categorie, Prix = prix, Ville = ville, IdProprio = idproprio};
                    listePropriete.Add(propriete);
                }

                r.Close();
                con.Close();


            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open) { }
                con.Close();
            }

            return listePropriete;


        }

        public void supprimer(int position)
        {
            Propriete p = SingletonPropriete.getInstance().getListe()[position];
            int id = p.Id;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"DELETE FROM propriete WHERE id = @id;";

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

        public void update(Propriete m, int position)
        {

            Propriete propri = SingletonPropriete.getInstance().getListe()[position];
            int id = propri.Id;

            string categorie = propri.Categorie;
            double prix = propri.Prix;
            string ville = propri.Ville;
            int idproprio = propri.IdProprio;




            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"update propriete set categorie= @categorie, prix= @prix, ville= @ville, idproprio= @idproprio WHERE id = @id;";

                commande.Parameters.AddWithValue("@id", id);

                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@ville", ville);
                commande.Parameters.AddWithValue("@idproprio", idproprio);
                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch (MySqlException ex)
            {
                con.Close();
            }
        }


        public void Ajout(Propriete propri)
        {

            int id = propri.Id;

            string categorie = propri.Categorie;
            double prix = propri.Prix;
            string ville = propri.Ville;
            int idproprio = propri.IdProprio;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into propriete values(@id, @categorie, @prix, @ville, @idproprio)";

                commande.Parameters.AddWithValue("@id", id);

                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@ville", ville);
                commande.Parameters.AddWithValue("@idproprio", idproprio);

                con.Open();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                con.Close();
            }
        }

        public ObservableCollection<Propriete> getListe()
        {
            return listePropriete;
        }


    }
}
