using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Casino
{
    internal class CasinoDBContext : DbContext
    {
        internal DbSet<Client> Clients { get; set; }
        internal DbSet<Objet> Objets { get; set; }
        internal DbSet<Seance> Seances { get; set; }
        internal DbSet<Ville> Villes { get; set; }
        internal DbSet<Pays> Pays { get; set; }
        internal DbSet<Enchere> Encheres { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;");
            }
        }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Bibliotheque;Integrated Security=true");
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "Casino.db")}");
            optionsBuilder.EnableSensitiveDataLogging(true);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD
            modelBuilder.Entity<Enchere>()

                .HasKey(t => new { t.ClientID, t.SeanceID });
            /*
            modelBuilder.Entity<Enchere>()
                 .HasOne(pt => pt.Client)
                 .WithMany(p => p.Encheres)
                 .HasForeignKey(pt => pt.SeanceID);

            modelBuilder.Entity<Enchere>()
                .HasOne(pt => pt.Seance)
                .WithMany(t => t.Encheres)
                .HasForeignKey(pt => pt.ClientID);
            
            */



            #endregion

            #region Données présentes par défaut dans la BDD
            modelBuilder.Entity<Ville>().HasData(
                new Ville() { ID = 1, CodePostal = 2000, Nom = "Anvers", PaysID = 1 },
                new Ville() { ID = 2, CodePostal = 1000, Nom = "Bruxelles", PaysID = 1 },
                new Ville() { ID = 3, CodePostal = 6000, Nom = "Charleroi", PaysID = 1 },
                new Ville() { ID = 4, CodePostal = 9000, Nom = "Gand", PaysID = 1 },
                new Ville() { ID = 5, CodePostal = 7000, Nom = "Mons", PaysID = 1 },
                new Ville() { ID = 6, CodePostal = 7700, Nom = "Mouscron", PaysID = 1 },
                new Ville() { ID = 7, CodePostal = 7500, Nom = "Tournai", PaysID = 1 },
                new Ville() { ID = 8, CodePostal = 100023, Nom = "New York", PaysID = 2 },
                new Ville() { ID = 9, CodePostal = 41001, Nom = "Seville", PaysID = 2 }
            );

            modelBuilder.Entity<Pays>().HasData(

                new Pays() { ID = 1, Nom = "Belgique" },
                new Pays() { ID = 2, Nom = "USA" },
                new Pays() { ID = 3, Nom = "France" },
                new Pays() { ID = 4, Nom = "allemagne" },
                new Pays() { ID = 5, Nom = "Espagne" }
            );



            modelBuilder.Entity<Seance>().HasData(
                 new Seance() { ID = 1, DateDebut = new DateTime(2020, 02, 24), DateFin = new DateTime(2020, 04, 18), MontantMini = 200, MontantinInstantane = 20000, Osffet = 1, ObjetID = 0 },
                 new Seance() { ID = 2, DateDebut = new DateTime(2020, 03, 24), DateFin = new DateTime(2020, 10, 24), MontantMini = 23000, Osffet = 15, ObjetID = 4 }
             );

            modelBuilder.Entity<Objet>().HasData(
                new Objet() { ID = 1, Estimation = 2, ClientID = 2, PrixDepart = 4, PrixActuel = 12000, Texte = "papier toilette" },
                new Objet() { ID = 2, Estimation = 4, ClientID = 2, PrixDepart = 2, PrixActuel = 4500, Texte = "gel hydroalcooliquee" },
                new Objet() { ID = 3, Estimation = 2, ClientID = 2, PrixDepart = 8, PrixActuel = 25000, Texte = "hydrochloroquine" },
                new Objet() { ID = 4, Estimation = 1, ClientID = 2, PrixDepart = 1, PrixActuel = 240, Texte = "Riz" },
                new Objet() { ID = 5, Estimation = 1, ClientID = 2, PrixDepart = 4, PrixActuel = 85, Texte = "pates" },
                new Objet() { ID = 6, Estimation = 1, ClientID = 2, PrixDepart = 4, PrixActuel = 325, Texte = "Farine" }
            );
            
            modelBuilder.Entity<Enchere>().HasData(
                new Enchere() { SeanceID = 1, ClientID = 1  },
                new Enchere() { SeanceID = 1, ClientID = 2 },
                new Enchere() { SeanceID = 2, ClientID = 1 },
                new Enchere() { SeanceID = 2, ClientID = 2 }



            );
            
            modelBuilder.Entity<Client>().HasData(
                new Client() { ID = 1, Nom = "Boomer", Prenom = "Angry", Rue = "Rue de Fontigny ", NumRue = 35, VilleID = 6 },
                new Client() { ID = 2, Nom = "ZeroTout", Prenom = "Celestin", Rue = "Rue Libert ", NumRue = 8, VilleID = 2 },
                new Client() { ID = 3, Nom = "LaChance", Prenom = "Larry", Rue = "Flushing ", NumRue = 1, VilleID = 4 },
                new Client() { ID = 4, Nom = "Deter", Prenom = "Chad", Rue = "Rue du Monument ", NumRue = 94, VilleID = 7 },
                new Client() { ID = 5, Nom = "LaChancla", Prenom = "Risitas", Rue = "AV. Manuel Siurot ", NumRue = 2, VilleID = 8 }
                );
            #endregion


        }

        internal Client AjouterClient(string aNom, string aPrenom, Ville aVille, int aNumRue)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (aPrenom == null || aPrenom == "") { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un prénom (valeur NULL ou chaine vide)."); }
            if (aVille == null) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir une ville (valeur NULL)."); }


            //Ajout du nouveau client
            Client lClient = new Client() { Nom = aNom, Prenom = aPrenom, Ville = aVille, NumRue = aNumRue };
            Clients.Local.Add(lClient);
            return lClient;
        }
        internal Objet AjouterObjet(int aPrix, string aTexte, Client aClient)
        {
            //Gestion des erreurs
            if (aPrix <= 0) { throw new ArgumentNullException($"{nameof(AjouterObjet)} : L'objet doit avoir une valeur minimale "); }
            if (aTexte == null || aTexte == "") { throw new ArgumentNullException($"{nameof(AjouterObjet)} : L'objet doit être décrit "); }
            if (aClient == null) { throw new ArgumentNullException($"{nameof(AjouterObjet)} : L'objet doit appartenir a quelqu'un (valeur NULL)."); }


            //Ajout du nouveau client
            Objet lObjet = new Objet() { };
            Objets.Local.Add(lObjet);
            return lObjet;
        }

        internal Enchere AjouterEnchere(Client aClient, Seance aSeance)
        {
            //Gestion des erreurs.
            if (aClient == null) { throw new ArgumentNullException($"{nameof(AjouterEnchere)} : Il faut un Client pour le lien Seance/Client (valeur NULL)."); }
            if (aSeance == null) { throw new ArgumentNullException($"{nameof(AjouterEnchere)} : Il faut une Seance pour le lien Seance/Client (valeur NULL)."); }
            if (Encheres.Local.FirstOrDefault(ecr => ecr.ClientID == aClient.ID && ecr.SeanceID == aSeance.ID) != null)
            { throw new InvalidOperationException($"{nameof(AjouterEnchere)} : Le lien Enchere existe déjà."); }

            //Ajout du nouveau lien ecrire (livre/auteur).
            Enchere lEnchere = new Enchere() { Seance = aSeance, Client = aClient , ClientID = aClient.ID, SeanceID = aSeance.ID, Moment = DateTime.Now };
            
            Encheres.Local.Add(lEnchere);
            aSeance.MontantMini = aSeance.ProchaineEnchere;
            
            return lEnchere;
        }
        internal Seance AjouterSeance(Objet aObjet, DateTime aDebut, DateTime aFin, decimal aMini, float aInstantane, float aOffset)
        {
            //Gestion des erreurs
            
            if (aDebut == null) { throw new ArgumentNullException($"{nameof(AjouterSeance)} :La seance a besoin d'une date de début pour exister (valeur NULL) "); }
            if (aFin == null) { throw new ArgumentNullException($"{nameof(AjouterSeance)} : La seance a besoin d'une date de fin pour exister  (valeur NULL)."); }
            if (aMini <= 0) { throw new ArgumentNullException($"{nameof(AjouterSeance)} : L'objet doit avoir une valeur minimale "); }
            if (aInstantane <= 1) { throw new ArgumentNullException($"{nameof(AjouterSeance)} : L'objet doit avoir un multiplicateur instané "); }
            if (aOffset <= 1) { throw new ArgumentNullException($"{nameof(AjouterSeance)} : L'objet doit avoir un multiplicateur d'enchére  ."); }

            //Ajout du nouveau client
            Seance lSeance = new Seance() { DateDebut = DateTime.Now,MontantinInstantane = 2 , Osffet = 1.1f };
            Seances.Local.Add(lSeance);
            return lSeance;
        }
        internal Ville AjouterVille(string aNom, int aCodePostal)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un nom (valeur NULL ou chaine vide)."); }
            if (aCodePostal == 0) { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un code postal ."); }


            //Ajout de la nouvelle ville
            Ville lVille = new Ville() { Nom = aNom, CodePostal = aCodePostal };
            Villes.Local.Add(lVille);
            return lVille;
        }
        internal Pays AjouterPays(string aNom)
        {
            //Gestion des erreurs
            if (aNom == null || aNom == "") { throw new ArgumentNullException($"{nameof(AjouterVille)} : La ville doit avoir un nom (valeur NULL ou chaine vide)."); }


            //Ajout de la nouvelle ville
            Pays lPays = new Pays() { Nom = aNom, };
            Pays.Local.Add(lPays);
            return lPays;
        }
        internal void SupprimerClient(Client aClient)
        {
            //Gestion des erreurs
            if (aClient == null) { throw new ArgumentNullException($"{nameof(SupprimerClient)} : Il faut un client en argument (valeur NULL)."); }
            if ((aClient.Objets?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerClient)} : Il faut d'abord supprimer les Objets du client."); }
            if ((aClient.Seances?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerClient)} : Le client ne doit pas participer a une seance."); }
          
            Clients.Local.Remove(aClient);

        }
        internal void SupprimerEnchere(Enchere aEnchere)
        {
            //Gestion des erreurs
            if (aEnchere == null) { throw new ArgumentException($"{nameof(SupprimerEnchere)} : Il faut un lien Enchere (Client/Seance) en argument (valeur NULL)."); }

            //Suppression du lien ecrire
            Encheres.Local.Remove(aEnchere);
        }
        internal void SupprimerVille(Ville aVille)
        {
            //Gestion des erreurs
            if (aVille == null) { throw new ArgumentNullException($"{nameof(SupprimerVille)} : Il faut une ville en argument (valeur NULL)."); }
            if ((aVille.Clients?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerVille)} : Il faut d'abord supprimer les clients habitant la ville."); }

            //Suppression de la ville.
            Villes.Local.Remove(aVille);
        }
        internal void SupprimerSeance(Seance aSeance)
        {
            //Gestion des erreurs
            if (aSeance == null) { throw new ArgumentNullException($"{nameof(SupprimerSeance)} : Il faut une Seance en argument (valeur NULL)."); }
            

            //Suppression de la ville.
            Seances.Local.Remove(aSeance);
        }
        internal void SupprimerObjet(Objet aObjet)
        {
            //Gestion des erreurs
            if (aObjet == null) { throw new ArgumentNullException($"{nameof(SupprimerObjet)} : Il faut une ville en argument (valeur NULL)."); }
            

            //Suppression de la ville.
            Objets.Local.Remove(aObjet);
        }
        internal void SupprimerPays(Pays aPays)
        {
            //Gestion des erreurs
            if (aPays == null) { throw new ArgumentNullException($"{nameof(SupprimerPays)} : Il faut un pays en argument (valeur NULL)."); }
            if ((aPays.Villes?.Count ?? 0) > 0) { throw new InvalidOperationException($"{nameof(SupprimerPays)} : Il faut d'abord supprimer les Villes du pays."); }

            //Suppression de la ville.
            Pays.Local.Remove(aPays);
        }
    }
}