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
    /// Logique d'interaction pour pgSeances.xaml
    /// </summary>
    public partial class pgSeances : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Objet> Objets => BDD.Objet;
        public ReadOnlyObservableCollection<Client> Clients => BDD.Clients;
        public ReadOnlyObservableCollection<Enchere> Encheres => BDD.Enchere;
        public pgSeances()
        {
            InitializeComponent();
            grpListeSeance.DataContext = BDD.Seance;
        }
        private void AjouterSeance(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvSeance.SelectedItem = BDD.AjouterSeance(null, new DateTime(2008, 3, 15), new DateTime(2020, 3, 15), 2,2,2); }, nameof(AjouterSeance));
        }

        private void SupprimerSeance(object sender, RoutedEventArgs e)
        {
            Seance selection = (Seance)lvSeance.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la ville {selection.ID} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerSeance(selection); }, nameof(SupprimerSeance));
                }
            }
        }

        


    }
}
