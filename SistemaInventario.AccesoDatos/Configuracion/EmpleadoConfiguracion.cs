using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Configuracion
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ApellidoPaterno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.ApellidoMaterno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Telefono).IsRequired().HasMaxLength(15);
            builder.Property(x => x.PuestoId).IsRequired();
            builder.Property(x => x.LugarId).IsRequired();

            //Hagamos las Relaciones en Fluent API

            builder.HasOne(x => x.Puesto).WithMany()
                .HasForeignKey(x => x.PuestoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Lugar).WithMany()
                .HasForeignKey(x => x.LugarId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
