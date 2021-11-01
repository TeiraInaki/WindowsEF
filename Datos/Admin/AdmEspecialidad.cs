using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos.Models;
using Datos.Data;
using System.Data.Entity;

namespace Datos.Admin
{
    public static class AdmEspecialidad
    {
        static DBClinicaContext context = new DBClinicaContext();
        public static List<Especialidad> Listar()
        {
            return context.Especialidades.ToList();
        }

        public static Especialidad TraerPorId(int Id)
        {
            return context.Especialidades.Find(Id);
        }

        public static int Insertar(Especialidad especialidad)
        {
            context.Especialidades.Add(especialidad);

            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Modificar(Especialidad especialidad)
        {
            Especialidad especialidadOrigen = context.Especialidades.Find(especialidad.Id);

            if (especialidadOrigen != null)
            {
                especialidadOrigen.Nombre = especialidad.Nombre;
                return context.SaveChanges();
            }

            return 0;
        }

        public static int Eliminar(int Id)
        {
            Especialidad especialidadOrigen = context.Especialidades.Find(Id);

            if (especialidadOrigen != null)
            {
                context.Especialidades.Remove(especialidadOrigen);
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
