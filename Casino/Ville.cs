using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Casino
{
    public class Ville : INotifyPropertyChanged
    {

       
        public int ID { get; set; }
        public string Nom { get; set; }
        public int CodePostal { get; set; }


        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        [ForeignKey("PaysID")]
        public int PaysID { get; set; }
        public Pays Payss { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Description()
        {
            Console.WriteLine("ville de " +this.Nom+ "le code postal est"+ this.CodePostal+ " son numero d'indentification est "+ this.ID) ;
        }
           
    }
}
