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
    public static class AdmPaciente
    {
        //Esta instancia es requerida para poder generar los cambios en la BD
        private static DBClinicaContext context = new DBClinicaContext();

        public static List<Paciente> Listar()
        {
            //Con entity framework es mucho mas simple listar por tabla
            

            //Retorno todos los pacientes
            return context.Pacientes.ToList();
        }

        public static Paciente TraerPorId(int Id)
        {
            //Funcion para encontrar por primary key (ID)
            return context.Pacientes.Find(Id);
        }

        public static int Insertar(Paciente paciente)
        {
            //Funcion para insertar
            context.Pacientes.Add(paciente);
            //Con este guardo los cambios que haya hecho y devuelve las filas afectadas
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }

        public static int Modificar(Paciente paciente)
        {
            Paciente pacienteOrigen = context.Pacientes.Find(paciente.Id);

            if (pacienteOrigen != null)
            {
                pacienteOrigen.Nombre = paciente.Nombre;
                pacienteOrigen.Apellido = paciente.Apellido;
                pacienteOrigen.FechaNacimiento = paciente.FechaNacimiento;
                pacienteOrigen.NroHistoriaClinica = paciente.NroHistoriaClinica;
                pacienteOrigen.MedicoId = paciente.MedicoId;
                return context.SaveChanges();
            }

            return 0;
        }

        public static int Eliminar(int Id)
        {
            Paciente pacienteOrigen = context.Pacientes.Find(Id);

            if (pacienteOrigen != null)
            {
                context.Pacientes.Remove(pacienteOrigen);

                return context.SaveChanges();
            }

            return 0;
        }
    }
}
