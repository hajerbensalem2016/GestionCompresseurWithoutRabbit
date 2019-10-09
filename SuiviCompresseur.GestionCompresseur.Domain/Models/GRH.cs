using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviCompresseur.GestionCompresseur.Domain.Models
{
    public class GRH
    {
        [Key]
        public Guid GRhID { get; set; }
        public Guid CompFilialeID { get; set; }
        public CompresseurFiliale CompresseurFiliale { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public decimal Salaire { get; set; }
        //[RegularExpression("^[0-9]*[.]?[0-9]+", ErrorMessage = "UPRN must be numeric")] il faut chercher la relation entre l expression et string
        //kanet string w badelnaha float 
        public float Charge_Compresseur { get; set; }
        [Required]
        public float Charge_Secteur { get; set; }
        [Required]
        public float Charge_Total { get; set; }
        [Required]
        public float Compresseur_Pourcentage { get; set; }
        [Required]
        public float Secheur_Pourcentage { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }





    }

}
