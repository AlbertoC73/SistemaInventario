using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El Campo Descripción es Requerido")]
        [MaxLength(100, ErrorMessage = "La Descripción solo se compone de 100 Caracteres como Máximo")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Turno es Requerido")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "El estado de la Área es Requerido")]
        public bool Estado { get; set; }
        
    }
}
