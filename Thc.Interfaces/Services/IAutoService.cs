using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Thc.Models.Models;

namespace Thc.Interfaces.Services
{
    public interface IAutoService
    {
        IList<Auto> All();
        Auto GetById(int id);

        Unidad GetUnidadById(int id);
        List<Unidad> GetUnidades();

        Estado GetEstadoById(int id);
        List<Estado> GetEstados();

        void Insert(Auto auto);
        void Update(Auto auto);
    }
}
