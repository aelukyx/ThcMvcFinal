using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thc.Models.Models
{
    public class Conductor
    {

        public Conductor()
        {
            this.Alquileres = new List<Alquiler>();
        }

        [Key]
        public int Id { get; set; }
        public String NameConductor { get; set; }

        public virtual ICollection<Alquiler> Alquileres { get; set; }

    }
}