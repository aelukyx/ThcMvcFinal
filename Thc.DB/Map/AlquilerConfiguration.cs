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
    public class AlquilerConfiguration : EntityTypeConfiguration<Alquiler>
    {

        public AlquilerConfiguration()
        {
            ToTable("Alquiler", "dbo");
            HasKey(o => o.Id);
            Property(o => o.FechaServicio).HasColumnName("FechaServicio").IsRequired();
            Property(o => o.HoraServicio).HasColumnName("HoraServicio").IsRequired();
            Property(o => o.LugarReferencia).HasColumnName("LugarReferencia").IsRequired();
            Property(o => o.FechaInicio).HasColumnName("FechaInicio").IsRequired();
            Property(o => o.FechaFin).HasColumnName("FechaFin").IsRequired();
            Property(o => o.NroDias).HasColumnName("NroDias").IsRequired();
            Property(o => o.MontoXdia).HasColumnName("MontoXdia").IsRequired();
            Property(o => o.MontoTotal).HasColumnName("MontoTotal").IsRequired();

            HasOptional(p => p.Cliente)
                .WithMany(p => p.Alquileres)
                .HasForeignKey(p => p.ClienteId);

            HasOptional(q => q.Auto)
                .WithMany(q => q.Alquileres)
                .HasForeignKey(q => q.AutoId);

            HasOptional(o => o.Conductor)
                .WithMany(o => o.Alquileres)
                .HasForeignKey(o => o.ConductorId);

        }
    }
}
