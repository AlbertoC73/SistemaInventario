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
    public class LugarConfiguracion : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Turno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}
