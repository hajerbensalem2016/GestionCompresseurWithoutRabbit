using System;
using System.Collections.Generic;
using System.Text;

namespace SuiviCompresseur.Gestion.Responsable.Domain.Models
{
  public   class Filiale
    {
        public Guid FilialeID { get; set; }

        public string Nom { get; set; }
        public string Code { get; set; }




        public virtual ICollection<Users> Users { get; set; }





    }
}
