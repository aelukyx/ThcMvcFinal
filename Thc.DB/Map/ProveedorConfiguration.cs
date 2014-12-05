using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;

using Thc.Models.Models;


namespace Thc.DB.Map
{
    public class ProveedorConfiguration : EntityTypeConfiguration<Proveedor>
    {

        public ProveedorConfiguration()
        {
            ToTable("Proveedor", "dbo");
            HasKey(o => o.Id);
            Property(o => o.NroRUC).HasColumnName("NroRUC")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_NroRUC") { IsUnique = true }));
            Property(o => o.RazonSocial).HasColumnName("RazonSocial").IsRequired();
            Property(o => o.Direccion).HasColumnName("Direccion").IsOptional();
            Property(o => o.Telefono).HasColumnName("Telefono").IsOptional();
            Property(o => o.Celular).HasColumnName("Celular").IsOptional();
            Property(o => o.Email).HasColumnName("Email").IsOptional();

            HasOptional(o => o.Ciudad)
                .WithMany(o => o.Proveedores)
                .HasForeignKey(o => o.CiudadId);

        }
    }
}
