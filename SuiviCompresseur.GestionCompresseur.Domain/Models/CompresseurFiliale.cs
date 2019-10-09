using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviCompresseur.GestionCompresseur.Domain.Models
{
    public class CompresseurFiliale
    {
        [Key]
        public Guid CompFilialeID { get; set; }
        public Guid CompresseurID { get; set; }
        public Guid FilialeID { get; set; }
        // Concatination du constructeur+typeComp+num
        public string Name { get; set; }
        //  [RegularExpression("^[0-9]*[.]?[0-9]+", ErrorMessage = "UPRN must be numeric")] , il fau tester avec c exp

        public float MontantTotal { get; set; }
        public float MontantMensuel { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        public int Duree { get; set; }
        public FicheCompresseur FicheCompresseur { get; set; }
        ///c est quoi ca   public ICollection<FicheCompresseur> FicheCompresseurs { get; set; } 
        
        public virtual ICollection<Consommable>Consommables { get; set; }
        public virtual ICollection<Fiche_Suivi> Fiche_Suivis { get; set; }

        public virtual ICollection<GRH> GRHs { get; set; }





    }
}
