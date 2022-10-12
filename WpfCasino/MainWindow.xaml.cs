using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private BDDSingleton BDD = BDDSingleton.Instance;

        public MainWindow()
        {
            InitializeComponent();
            //Affichage d'un cadre par défaut.
            Cadre.NavigationService.Navigate(new pgClients());
        }

        #region Méthodes liées au Menu du haut de la fenêtre
        private void AfficherObjets(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgObjets()); }
        private void AfficherClients(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgClients()); }
        private void AfficherEnchere(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgEncheres()); }
        private void AfficherPays(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgPays()); }
        private void AfficherVilles(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgVilles()); }
        private void AfficherSeance(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgSeances()); }
        private void SauvegarderModifications(object sender, RoutedEventArgs e)

        {
            BDD.SauvegarderModifications();
            MessageBox.Show("Modifications sauvegardées dans la base de données.", "Sauvegarde des modifications", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Quitter(object sender, RoutedEventArgs e) { this.Close(); }
        #endregion

        /// <summary>
        /// Méthode appelée une fois qu'une page a été chargée à l'écran.
        /// Efface l'historique de navigation (les anciennes pages chargées) de la mémoire.
        /// </summary>
        private void NavServiceOnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e) { while (Cadre.NavigationService.RemoveBackEntry() != null) ; }
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BDD.ModificationsEnAttente)
            {
                if (MessageBox.Show("Il y a des modifications en attente voulez vous les sauvegarder avant de quitter ?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    if (MessageBox.Show("La fermeture de l'application va entrainer la perte des modifications non sauvegardées dans la base de données. Etes-vous sûr de vouloir fermer l'application?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else { BDD.SauvegarderModifications(); }
            }
        }
    }
}

