using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Empleado empleado)
        {
            var empleadoBD = _db.Empleados.FirstOrDefault(b => b.Id == empleado.Id);
            if (empleadoBD != null)
            {
                empleadoBD.ApellidoPaterno = empleado.ApellidoPaterno;
                empleadoBD.ApellidoPaterno = empleado.ApellidoMaterno;
                empleadoBD.Nombre = empleado.Nombre;
                empleadoBD.Direccion = empleado.Direccion;
                empleadoBD.Telefono = empleado.Telefono;
                empleadoBD.LugarId = empleado.LugarId;
                empleadoBD.PuestoId = empleado.PuestoId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if(obj == "Lugar")
            {
                return _db.Lugares.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Turno,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Puesto")
            {
                return _db.Puestos.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.NombreDelPuesto,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }

    }
}
