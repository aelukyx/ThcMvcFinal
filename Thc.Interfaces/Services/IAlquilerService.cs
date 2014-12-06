using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Thc.Models.Models;

namespace Thc.Interfaces.Services
{
    public interface IAlquilerService
    {
        IList<Alquiler> All();
        Alquiler GetById(int id);

        //
        Usuario GetUsuarioById(int id);
        List<Usuario> GetUsuarios();

        Usuario GetClienteById(int id);
        List<Cliente> GetClientes();

        Unidad GetAutoById(int id);
        List<Auto> GetAutos();

        Unidad GetConductorById(int id);
        List<Conductor> GetConductores();
        //

        void Insert(Alquiler alquiler);
        void Update(Alquiler alquiler);
    }
}
