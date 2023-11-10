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

        public event PropertyChangedEventHandler PropertyChanged;

        public Propriete(int pid, string pcategorie, double pprix, string pville, int pidproprio)
        {
            id = pid;
            categorie = pcategorie;
            prix = pprix;
            ville = pville;
            idproprio = pidproprio;
        }

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


        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
