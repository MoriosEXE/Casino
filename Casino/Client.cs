
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Casino


{
    public class Client : INotifyPropertyChanged
    {
        
              
        
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Token { get; set; }
        public string Rue { get; set; }
        public int NumRue { get; set; }
        protected string MDP { get; set; }
        public string Email { get; set; }
        public string NomComplet => $"{Nom} {Prenom}";
        

        [ForeignKey("VilleID")]
        public int VilleID { get; internal set; }
        public Ville Ville { get; set; }


        [ForeignKey("Objets")]
        public ObservableCollection<Objet> Objets { get; set; } = new ObservableCollection<Objet>();


        [ForeignKey("Seances")]
        public ObservableCollection<Enchere> Seances { get; set; } = new ObservableCollection<Enchere>();

        

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
