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

namespace WpfCasino
{
    /// <summary>
    /// Logique d'interaction pour pgPays.xaml
    /// </summary>
    public partial class pgPays : Page
    {
        BDDSingleton BDD = BDDSingleton.Instance;
        public pgPays()
        {
            InitializeComponent();
            grpListePays.DataContext = BDD.Pays;
        }
        private void AjouterPays(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvPays.SelectedItem = BDD.AjouterPays("Nouveau pays"); }, nameof(AjouterPays));
        }

        private void SupprimerPays(object sender, RoutedEventArgs e)
        {
            Pays selection = (Pays)lvPays.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la ville {selection.Nom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { BDD.SupprimerPays(selection); }, nameof(SupprimerPays));
                }
            }
        }
    }
}
