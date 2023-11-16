using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetProprio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjoutProprietaire : Page
    {
        public PageAjoutProprietaire()
        {
            this.InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (tbxId.Text == "")
            {
                tbxId.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            else if (tbxNom.Text == "")
            {
                tbxNom.BorderBrush = new SolidColorBrush(Colors.Red);

            }

            else if (tbxPrenom.Text == "")
            {
                tbxPrenom.BorderBrush = new SolidColorBrush(Colors.Red);

            }


            else
            {
                int code = Convert.ToInt32(tbxId.Text);
                string nom = tbxNom.Text;
                string prenom = tbxPrenom.Text;



                Proprietaire proprietaire = new Proprietaire(code, nom, prenom);

                SingletonProprietaire.getInstance().Ajout(proprietaire);

                afficher();
            }
        }

        private void afficher()
        {
            SingletonPropriete.getInstance().getPropriete();
        }
    }
}
