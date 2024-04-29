using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos.ViewModels
{
    public class EmpleadoVM
    {
        public Empleado Empleado { get; set; }
        public IEnumerable<SelectListItem> LugarLista { get; set; }
        public IEnumerable<SelectListItem> PuestoLista { get; set; }
    }
}
