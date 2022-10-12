using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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


namespace WpfCasino
{
    /// <summary>
    /// Logique d'interaction pour pgClients.xaml
    /// </summary>
    public partial class pgClients : Page
    {

        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Ville> Villes => BDD.Villes;



        public pgClients()
        {
            InitializeComponent();
            grpClients.DataContext = BDD.Clients;
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvClients.SelectedItem = BDD.AjouterClient("Nouveau", "Client", BDD.Villes.FirstOrDefault(), 1); }, nameof(AjouterClient));
        }

        private void SupprimerClient(object sender, RoutedEventArgs e)
        {
            Client selection = (Client)lvClients.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le client {selection.NomComplet} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerClient(selection); }, nameof(SupprimerClient));
                }
            }
        }

    }
    
}
