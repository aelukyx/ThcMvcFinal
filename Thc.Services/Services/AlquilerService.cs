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
    public class AlquilerService :  IAlquilerService
    {

        private readonly ThcEntities entities;

        public AlquilerService(ThcEntities entities)
        {
            this.entities = entities;
        }

        public IList<Alquiler> All()
        {
            return entities.Alquileres.ToList();
        }

        public void Insert(Alquiler alquiler)
        {
            entities.Alquileres.Add(alquiler);
            entities.SaveChanges();
        }

        public Alquiler GetById(int id)
        {
            return entities.Alquileres.First(x => x.Id == id);
        }

        public Usuario GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarios()
        {
            return entities.Usuarios.ToList();
        }

        public Usuario GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetClientes()
        {
            return entities.Clientes.ToList();
        }

        public Unidad GetAutoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Auto> GetAutos()
        {
            return entities.Autos.ToList();
        }

        public Unidad GetConductorById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Conductor> GetConductores()
        {
            return entities.Conductores.ToList();
        }

        public void Update(Alquiler alquiler)
        {
            throw new NotImplementedException();
        }
    }
}
