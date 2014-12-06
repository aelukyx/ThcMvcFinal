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
    public class AutoConfiguration : EntityTypeConfiguration<Auto>
    {

        public AutoConfiguration()
        {
            ToTable("Auto", "dbo");
            HasKey(o => o.Id);
            Property(o => o.Placa).HasColumnName("Placa")
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Placa") { IsUnique = true }));

            Property(o => o.Imagen).HasColumnName("Imagen").HasColumnType("image");

            HasOptional(o => o.Estado)
                .WithMany(o => o.Autos)
                .HasForeignKey(o => o.EstadoId);

            HasOptional(o => o.Unidad)
                .WithMany(o => o.Autos)
                .HasForeignKey(o => o.UnidadId);

        }
    }
}
