using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Casino 
{
    /// <summary>
    /// Classe représeant la Cardinalité de type [M:N] entre Client et Seance.
    /// </summary>

    public class Enchere : INotifyPropertyChanged
    {
        
        public decimal Montant { get; set; }

        public DateTime Moment { get; set; }
        [ForeignKey("ClientID")]
        public int? ClientID { get; set; }
        [ForeignKey("SeanceID")]
        public int? SeanceID { get; set; }

        public Client Client { get; set; } 
        public Seance Seance { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
