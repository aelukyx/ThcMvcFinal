using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Thc.DB.DB;
using Thc.Interfaces.Services;
using Thc.Models.Models;


namespace Thc.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ThcEntities entities;

        public ClienteService(ThcEntities entities)
        {
            this.entities = entities;
        }

        public IList<Cliente> All()
        {
            return entities.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return entities.Clientes.First(x => x.Id == id);
        }

        public void Insert(Cliente cliente)
        {
            entities.Clientes.Add(cliente);
            entities.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetFromClienteByRucDni(string DniRuc)
        {
            var query = from c in entities.Clientes
                        select c;

            if (!string.IsNullOrEmpty(DniRuc))
            {
                query = from c in query
                        where c.DniRuc.ToUpper().Contains(DniRuc.ToUpper())
                        select c;
            }

            return query;
        }
    }
}
