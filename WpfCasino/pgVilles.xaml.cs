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
    /// Logique d'interaction pour pgVilles.xaml
    /// </summary>
    public partial class pgVilles : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Pays> Pays => BDD.Pays;

        public pgVilles()
        {
            InitializeComponent();
            grpListeVilles.DataContext = BDD.Villes;
        }
        
        private void AjouterVille(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvVilles.SelectedItem = BDD.AjouterVille("Nouvelle Ville", 0001); }, nameof(AjouterVille));
        }

        private void SupprimerVille(object sender, RoutedEventArgs e)
        {
            Ville selection = (Ville)lvVilles.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la ville {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerVille(selection); }, nameof(SupprimerVille));
                }
            }
        }
    }
}
