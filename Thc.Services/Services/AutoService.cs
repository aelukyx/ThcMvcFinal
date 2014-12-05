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
    public class AutoService : IAutoService
    {
        private readonly ThcEntities entities;

        public AutoService(ThcEntities entities)
        {
            this.entities = entities;
        }

        public IList<Auto> All()
        {
            return entities.Autos.ToList();
        }

        public Auto GetById(int id)
        {
            return entities.Autos.First(x => x.Id == id);
        }

        public Unidad GetUnidadById(int id)
        {
            return entities.Unidades.First(x => x.Id == id);
        }

        public List<Unidad> GetUnidades()
        {
            return entities.Unidades.ToList();
        }

        public Estado GetEstadoById(int id)
        {
            return entities.Estados.First(x => x.Id == id);
        }

        public List<Estado> GetEstados()
        {
            return entities.Estados.ToList();
        }

        public void Insert(Auto auto)
        {
            entities.Autos.Add(auto);
            entities.SaveChanges();
        }

        public void Update(Auto auto)
        {
            throw new NotImplementedException();
        }

    }
}
