using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Casino

{
    public class Pays
    {
      
       
        public int ID { get; set; }
        public string Nom { get; set; }
        [ForeignKey("Villes")]
        public ObservableCollection<Ville> Villes { get; set; } = new ObservableCollection<Ville>();
        
    }
}
