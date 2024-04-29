using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [MaxLength(60, ErrorMessage = "Máximo 60 caracteres")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        [MaxLength(60, ErrorMessage = "Máximo 60 caracteres")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(60, ErrorMessage = "Máximo 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Dirección es requerida")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Teléfono es requerido")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Telefono { get; set; }

        // Llave foránea para la relación con la tabla Puesto
        [Required(ErrorMessage = "El Puesto es requerido")]
        public int PuestoId { get; set; }
        [ForeignKey("PuestoId")]
        public Puesto Puesto { get; set; }

        // Llave foránea para la relación con la tabla Area
        [Required(ErrorMessage = "El Área es requerida")]
        public int LugarId { get; set; }
        [ForeignKey("LugarId")]
        public Lugar Lugar { get; set; }
    }
}
