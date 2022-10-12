using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Casino;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfCasino
{
    /// <summary>
    /// Logique d'interaction pour pgObjets.xaml
    /// </summary>
    public partial class pgObjets : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Client> Clients => BDD.Clients;
        public pgObjets()
        {
            InitializeComponent();
            grpListeObjet.DataContext = BDD.Objet;

        }
        private void AjouterObjet(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvObjet.SelectedItem = BDD.AjouterObjet(1,"texte vide",null); }, nameof(AjouterObjet));
        }

        private void SupprimerObjet(object sender, RoutedEventArgs e)
        {
            Objet selection = (Objet)lvObjet.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer l'Objet {selection.ID} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerObjet(selection); }, nameof(SupprimerObjet));
                }
            }
        }

    }
}
