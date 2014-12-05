using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thc.Models.Models
{
    public class Alquiler
    {

        public int Id { get; set; }

        public String FechaServicio { get; set; }

        public String HoraServicio { get; set; }

        public String LugarReferencia { get; set; }

        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int? AutoId { get; set; }
        public virtual Auto Auto { get; set; }

        public int? ConductorId { get; set; }
        public virtual Conductor Conductor { get; set; }

        public String FechaInicio { get; set; }

        public String FechaFin { get; set; }

        public int NroDias { get; set; }

        public double MontoXdia { get; set; }

        public double MontoTotal { get; set; }

    }
}
