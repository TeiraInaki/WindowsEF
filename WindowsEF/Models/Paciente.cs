using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    //Personalizo el esquema de la tabla con decoraciones
    [Table("Paciente")] //Con esto EF sabe el nombre que le debe poner a la tabla, sino por convencion pluraliza
    

    public class Paciente
    {
        public int Id { get; set; }

        //Las decoraciones van por encima de la propiedad a la que van a afectar
        [Required] //Que no sea nullable
        [Column(TypeName = "varchar")] //Declaro el tipo de dato en Sql
        [MaxLength(50)] //Tamaño del varchar
        public string Nombre { get; set; }
        [Required] //Que no sea nullable
        [Column(TypeName = "varchar")] //Declaro el tipo de dato en Sql
        [MaxLength(50)] //Tamaño del varchar
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        public int NroHistoriaClinica { get; set; }

        //Foreign Key (FK)       
        public int MedicoId { get; set; }

        //Propiedad de navegacion (de muchos a uno)
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
    }
}
