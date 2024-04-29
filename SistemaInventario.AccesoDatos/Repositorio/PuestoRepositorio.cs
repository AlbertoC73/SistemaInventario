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
    public class PuestoRepositorio : Repositorio<Puesto>, IPuestoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PuestoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Puesto puesto)
        {
            var puestoBD = _db.Puestos.FirstOrDefault(b => b.Id == puesto.Id);
            if (puestoBD != null)
            {
                puestoBD.NombreDelPuesto = puesto.NombreDelPuesto;
                puestoBD.TipoPuesto = puesto.TipoPuesto;
                puestoBD.Salario = puesto.Salario;
                puestoBD.Horario = puesto.Horario;
                puestoBD.Estado = puesto.Estado;
                _db.SaveChanges();
            }
        }
    }
}
