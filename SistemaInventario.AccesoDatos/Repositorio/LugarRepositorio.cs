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
    public class LugarRepositorio : Repositorio<Lugar>, ILugarRepositorio
    {
        private readonly ApplicationDbContext _db;

        public LugarRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Lugar lugar)
        {
            var lugarBD = _db.Lugares.FirstOrDefault(b => b.Id == lugar.Id);
            if (lugarBD != null)
            {
                lugarBD.Descripcion = lugar.Descripcion;
                lugarBD.Turno = lugar.Turno;
                lugarBD.Estado = lugar.Estado;
                _db.SaveChanges();
            }
        }
    }
}
