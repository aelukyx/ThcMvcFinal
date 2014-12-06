using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Thc.Models.Models;
using Thc.DB.Map;

namespace Thc.DB.DB
{
    public class ThcEntities : DbContext
    {

        public virtual IDbSet<Cliente> Clientes { get; set; }
        public virtual IDbSet<Proveedor> Proveedores { get; set; }
        public virtual IDbSet<Ciudad> Ciudadess { get; set; }
        public virtual IDbSet<Auto> Autos { get; set; }
        public virtual IDbSet<Estado> Estados { get; set; }
        public virtual IDbSet<Unidad> Unidades { get; set; }
        public virtual IDbSet<Alquiler> Alquileres { get; set; }
        public virtual IDbSet<Conductor> Conductores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<DemoEntities>(null);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add<Cliente>(new ClienteConfiguration());
            modelBuilder.Configurations.Add<Proveedor>(new ProveedorConfiguration());
            modelBuilder.Configurations.Add<Auto>(new AutoConfiguration());
            modelBuilder.Configurations.Add<Alquiler>(new AlquilerConfiguration());
        }
    }
}