using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviCompresseur.GestionCompresseur.Domain.Models
{
    public class FicheCompresseur
    {
        [Key]
        public Guid CompresseurID { get; set; }
        //public Guid CompFilialeID { get; set; }
        public virtual ICollection<CompresseurFiliale> CompresseurFiliales { get; set; }

        public int CodeCompresseur { get; set; }
        public string TypeCompresseur { get; set; }
        public string Constructeur { get; set; }
        public Guid FournisseurID { get; set; }
        public int Puissance { get; set; }
        public float Debit { get; set; }
       
   


    }
}
