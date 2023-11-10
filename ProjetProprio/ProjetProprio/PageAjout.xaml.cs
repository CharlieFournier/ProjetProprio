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
using static System.Runtime.CompilerServices.RuntimeHelpers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetProprio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjout : Page
    {
        public PageAjout()
        {
            this.InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (tbxId.Text == "")
            {
                tbxId.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            else if (tbxPrix.Text == "")
            {
                tbxPrix.BorderBrush = new SolidColorBrush(Colors.Red);

            }

            else if (tbxVille.Text == "")
            {
                tbxVille.BorderBrush = new SolidColorBrush(Colors.Red);

            }

            else if (tbxProprio.Text == "")
            {
                tbxProprio.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            else
            {
                int code = Convert.ToInt32(tbxId.Text);
                string categorie = cbCategorie.SelectedValue.ToString();
                int prix = Convert.ToInt32(tbxPrix.Text);
                string ville = tbxVille.Text;
                int proprio = Convert.ToInt32(tbxProprio.Text);



                Propriete propriete = new Propriete(code, categorie, prix, ville, proprio);

                SingletonPropriete.getInstance().Ajout(propriete);

                afficher();
            }
        }

        private void afficher()
        {
            SingletonPropriete.getInstance().getPropriete();
        }
    }
}
