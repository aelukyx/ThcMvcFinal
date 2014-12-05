using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Thc.Models.Models
{
    public class Auto
    {

        public Auto()
        {
            this.Alquileres = new List<Alquiler>();
        }

        public int Id { get; set; }

        public String Placa { get; set; }

        public byte[] Imagen { get; set; }

        public int? EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        
        public int? UnidadId { get; set; }

        public virtual Unidad Unidad { get; set; }

        public virtual ICollection<Alquiler> Alquileres { get; set; }

    }
}
