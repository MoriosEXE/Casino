using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;

namespace Casino
{
    public class BDDSingleton
    {
        #region Propriétés représentant la Base de données ou la rendant accessible à l'extérieur du projet
        private CasinoDBContext BDD { get; set; }
        public static BDDSingleton Instance { get; set; } = new BDDSingleton();// null; //





        #endregion

        #region Propriétés
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;
        #endregion

        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        private ReadOnlyObservableCollection<Enchere> _Enchere;
        private ReadOnlyObservableCollection<Client> _Clients;
        private ReadOnlyObservableCollection<Pays> _Payss;
        private ReadOnlyObservableCollection<Seance> _Seances;
        private ReadOnlyObservableCollection<Objet> _Objets;
        private ReadOnlyObservableCollection<Ville> _Villes;

        public ReadOnlyObservableCollection<Enchere> Enchere => _Enchere;
        public ReadOnlyObservableCollection<Client> Clients => _Clients;
        public ReadOnlyObservableCollection<Pays> Pays => _Payss;
        public ReadOnlyObservableCollection<Seance> Seance => _Seances;
        public ReadOnlyObservableCollection<Objet> Objet => _Objets;
        public ReadOnlyObservableCollection<Ville> Villes => _Villes;
        #endregion

        #region Constructeur de la classe
        public BDDSingleton()
        {
            BDD = new CasinoDBContext();
            BDD.Database.EnsureCreated();

            BDD.Clients.Load();
            _Clients = new ReadOnlyObservableCollection<Client>(BDD?.Clients.Local.ToObservableCollection());
            BDD.Pays.Load();
            _Payss = new ReadOnlyObservableCollection<Pays>(BDD?.Pays.Local.ToObservableCollection());
            BDD.Seances.Load();
            _Seances = new ReadOnlyObservableCollection<Seance>(BDD?.Seances.Local.ToObservableCollection());
            BDD.Objets.Load();
            _Objets = new ReadOnlyObservableCollection<Objet>(BDD?.Objets.Local.ToObservableCollection());
            BDD.Villes.Load();
            _Villes = new ReadOnlyObservableCollection<Ville>(BDD?.Villes.Local.ToObservableCollection());
            BDD.Encheres.Load();
            _Enchere = new ReadOnlyObservableCollection<Enchere>(BDD?.Encheres.Local.ToObservableCollection());
        }

        // public Enchere AjouterAuteur(string aNom, string aPrenom) { return BDD?.AjouterAuteur(aNom, aPrenom); }

        #endregion
        
        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        public Enchere AjouterEnchere(Client aClient, Seance aSeance) { return BDD?.AjouterEnchere(aClient, aSeance); }
        public Client AjouterClient(string aNom, string aPrenom, Ville aVille, int aNumRue) { return BDD?.AjouterClient(aNom, aPrenom, aVille, aNumRue); }
        public Seance AjouterSeance(Objet aObjet, DateTime aDebut, DateTime aFin, decimal aMini, float aInstantane, float aOffset) { return BDD?
                .AjouterSeance(aObjet, aDebut, aFin , aMini, aInstantane, aOffset); }
        public Pays AjouterPays(string aNom) { return BDD?.AjouterPays(aNom); }
        public Objet AjouterObjet(int aPrix, string aTexte, Client aClient) { return BDD?.AjouterObjet(aPrix,aTexte,aClient); }
        public Ville AjouterVille(string aNom, int aCodePostal) { return BDD?.AjouterVille(aNom, aCodePostal); }

        public void SupprimerEnchere(Enchere aEnchere) { BDD?.SupprimerEnchere(aEnchere); }
        public void SupprimerClient(Client aClient) { BDD?.SupprimerClient(aClient); }
        public void SupprimerSeance(Seance aSeance) { BDD?.SupprimerSeance(aSeance); }
        public void SupprimerPays(Pays aPays) { BDD?.SupprimerPays(aPays); }
        public void SupprimerObjet(Objet aObjet) { BDD?.SupprimerObjet(aObjet); }
        public void SupprimerVille(Ville aVille) { BDD?.SupprimerVille(aVille); }
        #endregion
        
        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
        
    }
}
