using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asistencia
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlumno oFa = new FormAlumno();
            oFa.ShowDialog();
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsistencia oFas = new FormAsistencia();
            oFas.ShowDialog();
        }
    }
}
