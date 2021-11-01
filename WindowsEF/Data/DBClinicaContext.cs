using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WindowsEF.Models;

//Agrego el using para el Entity Framework
using System.Data.Entity;

namespace WindowsEF.Data
{
    //Hereda de una clase de Entity Framework
    public class DBClinicaContext : DbContext
    {
        //Constructor de la clase base (tengo que configurar la Key)
        public DBClinicaContext() : base("KeyDbClinica") { }

        //Propiedades DbSet<m>
        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }

    }
}
