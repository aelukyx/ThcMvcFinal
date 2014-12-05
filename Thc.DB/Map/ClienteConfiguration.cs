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
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {

        public ClienteConfiguration()
        {
            ToTable("Cliente", "dbo");
            HasKey(o => o.Id);
            Property(o => o.DniRuc).HasColumnName("DniRuc")
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DniRuc") { IsUnique = true }));
            Property(o => o.TipoDoc).HasColumnName("TipoDoc").IsRequired();
            Property(o => o.NombresRazonSocial).HasColumnName("NombresRazonSocial").IsRequired();
            Property(o => o.AppPaterno).HasColumnName("AppPaterno").IsOptional();
            Property(o => o.AppMaterno).HasColumnName("AppMaterno").IsOptional();
            Property(o => o.Celular).HasColumnName("Celular").IsRequired();
            Property(o => o.Telefono).HasColumnName("Telefono").IsRequired();
            Property(o => o.Direccion).HasColumnName("Direccion").IsRequired();
            Property(o => o.Email).HasColumnName("Email").IsRequired();
            Property(o => o.Comentarios).HasColumnName("Comentarios").IsOptional();


        }
    }
}
