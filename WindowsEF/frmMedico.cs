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
    public partial class frmMedico : Form
    {
        public frmMedico()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                EspecialidadId = Convert.ToInt32(comboEspecialidad.SelectedValue),
                Matricula = Convert.ToInt32(txtMatricula.Text)
            };

            int filasAfectadas = AdmMedico.Insertar(medico);

            if (filasAfectadas>0)
            {
                CargarGrid();
            }
        }

        private void frmMedico_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarCombo();
            CargarComboBuscar();
        }

        private void CargarGrid()
        {
            gridMedicos.DataSource = AdmMedico.Listar();
        }

        private void CargarCombo()
        {
            List<Especialidad> especialidades1 = AdmEspecialidad.Listar();

            comboEspecialidad.DataSource = especialidades1;
            comboEspecialidad.DisplayMember = "Nombre";
            comboEspecialidad.ValueMember = "Id";           
        }

        private void CargarComboBuscar()
        {
            List<Especialidad> especialidades2 = AdmEspecialidad.Listar();

            especialidades2.Insert(0, new Especialidad()
            {
                Id = 0,
                Nombre = "[TODAS]"
            });

            comboBuscarPorEspecialidad.DataSource = especialidades2;
            comboBuscarPorEspecialidad.DisplayMember = "Nombre";
            comboBuscarPorEspecialidad.ValueMember = "Id";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico()
            {
                MedicoId = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                EspecialidadId = Convert.ToInt32(comboEspecialidad.SelectedValue),
                Matricula = Convert.ToInt32(txtMatricula.Text)
            };

            int filasAfectadas = AdmMedico.Modificar(medico);

            if (filasAfectadas > 0)
            {
                CargarGrid();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int filasAfectadas = AdmMedico.Eliminar(Convert.ToInt32(txtId.Text));

            if (filasAfectadas > 0)
            {
                CargarGrid();
            }
        }

        private void comboBuscarPorEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int seleccion = Convert.ToInt32(comboBuscarPorEspecialidad.SelectedValue);

            if (seleccion == 0)
            {
                CargarGrid();
            }
            else
            {
                gridMedicos.DataSource = AdmMedico.ListarPorEspecialidad(seleccion);
            }
        }
    }
}
