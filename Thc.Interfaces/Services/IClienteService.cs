using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Thc.Models.Models;

namespace Thc.Interfaces.Services
{
    public interface IClienteService
    {
        IList<Cliente> All();
        IEnumerable<Cliente> GetFromClienteByRucDni(string DniRuc);
        Cliente GetById(int id);
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
    }
}
