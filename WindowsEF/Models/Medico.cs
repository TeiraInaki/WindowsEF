using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }

        //Propiedad de navegacion (de uno a muchos)
        public List<Paciente> Pacientes { get; set; }

        //Foreign Key a Especialidad
        public int EspecialidadId { get; set; }

        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }
    }
}
