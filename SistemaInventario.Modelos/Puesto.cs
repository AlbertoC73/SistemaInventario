using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Puesto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre del Puesto es Requerido")]
        [MaxLength(60, ErrorMessage = "El nombre del puesto solo se compone de 60 caracteres como máximo")]
        public string NombreDelPuesto { get; set; }

        [Required(ErrorMessage = "El Tipo de Puesto es Requerido")]
        public string TipoPuesto { get; set; }

        [Required(ErrorMessage = "El Salario es Requerido")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "El Horario es Requerido")]
        [MaxLength(100, ErrorMessage = "El Horario solo se compone de 100 Caracteres como Máximo")]
        public string Horario { get; set; }

        [Required(ErrorMessage = "El estado del Puesto es Requerido")]
        public bool Estado { get; set; }
    }
}
