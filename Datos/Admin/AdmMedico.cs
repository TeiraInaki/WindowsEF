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
    public static class AdmMedico
    {
        private static DBClinicaContext context = new DBClinicaContext();

        public static List<Medico> Listar()
        {
            //Con entity framework es mucho mas simple listar por tabla


            //Retorno todos los pacientes
            return context.Medicos.ToList();
        }

        public static List<Medico> ListarPorEspecialidad(int EspecialidadId)
        {
            List<Medico> listaTotal = Listar();

            List<Medico> filtro = new List<Medico>();

            foreach (Medico medico in listaTotal)
            {
                if (medico.EspecialidadId == EspecialidadId)
                {
                    filtro.Add(medico);
                }

            }

            return filtro;
        }

        public static Medico TraerPorId(int Id)
        {
            //Funcion para encontrar por primary key (ID)
            return context.Medicos.Find(Id);
        }

        public static int Insertar(Medico medico)
        {
            //Funcion para insertar
            context.Medicos.Add(medico);
            //Con este guardo los cambios que haya hecho y devuelve las filas afectadas
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Modificar(Medico medico)
        {
            Medico MedicoOrigen = context.Medicos.Find(medico.MedicoId);

            if (MedicoOrigen != null)
            {
                MedicoOrigen.Nombre = medico.Nombre;
                MedicoOrigen.Apellido = medico.Apellido;
                MedicoOrigen.Matricula = medico.Matricula;  
                MedicoOrigen.EspecialidadId = medico.EspecialidadId;
                return context.SaveChanges();
            }

            return 0;
        }

        public static int Eliminar(int Id)
        {
            Medico MedicoOrigen = context.Medicos.Find(Id);

            if (MedicoOrigen != null)
            {
                context.Medicos.Remove(MedicoOrigen);

                return context.SaveChanges();
            }

            return 0;
        }
    }
}
