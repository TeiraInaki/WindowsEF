using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Datos.Admin;
using Datos.Models;

namespace WindowsEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            gridPacientes.DataSource = AdmPaciente.Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente()
            {
                Nombre = "Jorge",
                Apellido = "Caminiti",
                FechaNacimiento = new DateTime(2002, 07, 10),
                NroHistoriaClinica = 17289,
                MedicoId = 1
            };

            int filasAfectadas = AdmPaciente.Insertar(paciente);

            if (filasAfectadas > 0)
            {
                CargarGrid();
            }
        }
    }
}
