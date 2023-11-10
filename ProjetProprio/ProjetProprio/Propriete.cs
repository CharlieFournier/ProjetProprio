using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetProprio
{
    internal class Propriete : INotifyPropertyChanged
    {
        int id;
        string categorie;
        double prix;
        string ville;
        int idproprio;
        string nomproprio;
        string prenomproprio;

        public event PropertyChangedEventHandler PropertyChanged;

        public Propriete(int pid, string pcategorie, double pprix, string pville, int pidproprio)
        {
            id = pid;
            categorie = pcategorie;
            prix = pprix;
            ville = pville;
        }

        //public Propriete(int pid, string pcategorie, double pprix, string pville, int pidproprio, string pnomproprio, string pprenomproprio)
        //{
        //    id = pid;
        //    categorie = pcategorie;
        //    prix = pprix;
        //    ville = pville;
        //    nomproprio = pnomproprio;
        //    prenomproprio = pprenomproprio;
        //}

        public Propriete()
        {

        }

        public override string ToString()
        {
            return $"{id} \n {categorie} \n {idproprio}";
        }

        public string StringCSV()
        {
            return $"{id} ; {categorie}  ;  {idproprio}";
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.OnPropertyChanged();
            }
        }
        public string Categorie
        {
            get { return categorie; }
            set
            {
                categorie = value;
                this.OnPropertyChanged();
            }
        }
        public double Prix
        {
            get { return prix; }
            set
            {
                prix = value;
                this.OnPropertyChanged();
            }
        }

        public string Ville
        {
            get { return ville; }
            set
            {
                ville = value;
                this.OnPropertyChanged();
            }
        }
        public int IdProprio
        {
            get { return idproprio; }
            set
            {
                idproprio = value;
                this.OnPropertyChanged();
            }
        }

        public String NomProprio
        {
            get { return nomproprio; }
            set
            {
                nomproprio = value;
                this.OnPropertyChanged();
            }
        }

        public String PrenomProprio
        {
            get { return prenomproprio; }
            set
            {
                prenomproprio = value;
                this.OnPropertyChanged();
            }
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
