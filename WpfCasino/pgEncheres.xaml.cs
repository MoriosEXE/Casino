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

namespace WpfCasino
{
    /// <summary>
    /// Logique d'interaction pour pgEncheres.xaml
    /// </summary>
    public partial class pgEncheres : Page
    {
        
        BDDSingleton BDD = BDDSingleton.Instance;
        public ReadOnlyObservableCollection<Client> Clients => BDD.Clients;
        public ReadOnlyObservableCollection<Seance> Seances => BDD.Seance;
        
        public pgEncheres()
        
        {
            InitializeComponent();
            grpEnchere.DataContext = BDD.Enchere;
        }
        private void SupprimerEnchere(object sender, RoutedEventArgs e)
        {
            Enchere selection = (Enchere)lvEnchere.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le lien Enchere {selection.Seance.ID}/{selection.Client.NomComplet} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerEnchere(selection); }, nameof(SupprimerEnchere));
                }
            }
        }
        #region Code associé à l'inputBox permettant d'ajouter une année académique
        private void AjouterEnchereAfficherInbox(object sender, RoutedEventArgs e)
        {
            IAE_cmbClient.SelectedItem = null;
            IAE_cmbSeance.SelectedItem = null;
            inboxAjouterEnchere.Visibility = Visibility.Visible;
        }
        private void AjouterEnchereAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterEnchere.Visibility = Visibility.Collapsed; }
        private void AjouterEnchereConfirmerAction(object sender, RoutedEventArgs e)
        {
            try
            {
                Enchere lNouveauEnchere = BDD.AjouterEnchere((Client)IAE_cmbClient.SelectedItem, (Seance)IAE_cmbSeance.SelectedItem);
                inboxAjouterEnchere.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien écrire", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }
        #endregion

    }
}
