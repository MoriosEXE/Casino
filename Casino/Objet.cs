using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Casino
{
    public class Objet : INotifyPropertyChanged
    {

       
        
        public int ID { get; set; }

        public decimal Estimation { get; set; }

        public decimal PrixDepart { get; set; }

        public decimal PrixActuel { get; set; }

        public string Texte { get; set; }
        [ForeignKey("ClientID")]
        public int ClientID { get; set; }

        public Client Client { get; set; }
        [ForeignKey("Seances")]
        public ObservableCollection<Seance> Seances { get; set; } = new ObservableCollection<Seance>();
        public event PropertyChangedEventHandler PropertyChanged;

        public string Resume => $"{Texte} - {Client.NomComplet} ";
        public string ResumePossession => $"{Texte} - {Client.NomComplet} ";
        

        public override string ToString() => Resume;

    }
}
