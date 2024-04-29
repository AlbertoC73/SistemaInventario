using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaInventario.Modelos;

namespace SistemaInventario.AccesoDatos.Configuracion
{
    public class PuestoConfiguracion : IEntityTypeConfiguration<Puesto>
    {
        public void Configure(EntityTypeBuilder<Puesto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.NombreDelPuesto).IsRequired().HasMaxLength(60);
            builder.Property(x => x.TipoPuesto).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.Horario).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}
