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
    public class ProveedorService : IProveedorService
    {
        private readonly ThcEntities entities;

        public ProveedorService(ThcEntities entities)
        {
            this.entities = entities;
        }

        public IList<Proveedor> All()
        {
            return entities.Proveedores.ToList();
        }

        public Proveedor GetById(int id)
        {
            return entities.Proveedores.First(x => x.Id == id);
        }

        public void Insert(Proveedor proveedor)
        {
            entities.Proveedores.Add(proveedor);
            entities.SaveChanges();
        }

        public void Update(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }


        Ciudad IProveedorService.GetCiudadById(int id)
        {
            return entities.Ciudadess.First(x => x.Id == id);
        }


        public List<Ciudad> GetCiudades()
        {
            return entities.Ciudadess.ToList();
        }
    }
}
