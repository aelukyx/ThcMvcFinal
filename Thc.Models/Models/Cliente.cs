using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thc.Models.Models
{
    public class Cliente
    {
        public Cliente()
        {
            this.Alquileres = new List<Alquiler>();
        }

        public int Id { get; set; }

        public String DniRuc { get; set; }

        public bool TipoDoc { get; set; }

        public String NombresRazonSocial { get; set; }

        public String AppPaterno { get; set; }

        public String AppMaterno { get; set; }

        public int Celular { get; set; }

        public String Telefono { get; set; }

        public String Direccion { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_]+[@][a-zA-Z_]+[.][a-zA-Z0-9]+$")]
        public String Email { get; set; }

        public String Comentarios { get; set; }

        public virtual ICollection<Alquiler> Alquileres { get; set; }

    }
}
