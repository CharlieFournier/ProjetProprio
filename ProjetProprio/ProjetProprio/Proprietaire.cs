using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetProprio
{
    internal class Proprietaire : INotifyPropertyChanged
    {
        int id;
        string nom;
        string prenom;

        public event PropertyChangedEventHandler PropertyChanged;

        public Proprietaire(int pid, string pnom, string pprenom)
        {
            id = pid;
            nom = pnom;
            prenom = pprenom;
        }

        public Proprietaire()
        {

        }

        public override string ToString()
        {
            return $"{id} \n {nom} \n {prenom}";
        }

        public string StringCSV()
        {
            return $"{id} ; {nom}  ;  {prenom}";
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
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                this.OnPropertyChanged();
            }
        }
    
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                this.OnPropertyChanged();
            }
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
