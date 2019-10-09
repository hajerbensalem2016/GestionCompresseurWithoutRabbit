using System;
using System.Collections.Generic;
using System.Text;

namespace Pgh.Auth.Model.Models
{
    public   class Filiale
    {
        public Guid FilialeID { get; set; }

        public string Nom { get; set; }
        public string Code { get; set; }




        public virtual ICollection<Users> Users { get; set; }





    }
}
