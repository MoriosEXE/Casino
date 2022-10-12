using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Casino
{
    public class Seance : INotifyPropertyChanged
    {
        public Seance()
        {
        }

        public int ID { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public decimal MontantMini { get; set; }

        public float MontantinInstantane { get; set; }

        public decimal MontantInstantaneCalculé => Convert.ToDecimal ( MontantinInstantane )* MontantMini;

        public decimal ProchaineEnchere => Convert.ToDecimal(Osffet) * MontantMini;

        public float Osffet { get; set; }
        [ForeignKey("ObjetID")]
        public int ObjetID { get; set; }


        //public ObservableCollection<Enchere> Encheres { get; set; } = new ObservableCollection<Enchere>();
        [ForeignKey("Clients")]

        public ObservableCollection<Enchere> Clients { get; set; } = new ObservableCollection<Enchere>();

        
        public Objet Objets { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
