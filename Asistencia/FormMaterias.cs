using Asistencia.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asistencia
{
    public partial class FormMaterias : Form
    {
        Datos dt = new Datos();
        DataSet ds;
        public FormMaterias()
        {
            InitializeComponent();
        }

        private void FormMaterias_Activated(object sender, EventArgs e)
        {
            try
            {
                ds = dt.ejecutar("Select * from Materia");
                if (ds != null)
                {
                    dgvMaterias.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}");
            }
        }

        private void dgvMaterias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormMateria materia = new FormMateria(Convert.ToInt32(dgvMaterias.CurrentRow.Cells[0].Value),
                dgvMaterias.CurrentRow.Cells[0].Value.ToString(),
                dgvMaterias.CurrentRow.Cells[1].Value.ToString());
            materia.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idMateria = Convert.ToInt32(dgvMaterias.CurrentRow.Cells[0].Value);
            if(MessageBox.Show("¿Desea eliminar esta materia?" + dgvMaterias.CurrentRow.Cells[1].Value.ToString()
                ,"sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool f = dt.ejecutarComando($"Delete from Materia where idMateria = {idMateria}");

                if (f)
                {
                    MessageBox.Show("Materia eliminada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar materia");
                }
            }
        }
    }
}
