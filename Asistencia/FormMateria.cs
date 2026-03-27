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
    public partial class FormMateria : Form
    {
        int id = 0;
        bool updating = false;
        Datos dt = new Datos();

        public FormMateria(int id, string materia, string cve)
        {
            InitializeComponent();
            this.id = id;
            txtCVE.Text = cve;
            txtMateria.Text = materia;
            updating = true;
        }
        public FormMateria()
        {
            InitializeComponent();
        }

        private void butAgregar_Click(object sender, EventArgs e)
        {
            if(updating == false)
            {
                bool resultado = dt.ejecutarComando($"Insert into Materia(cve,nombre) values" +
                    $"('{txtCVE.Text}', '{txtMateria.Text}')");

                if (resultado)
                {
                    MessageBox.Show("Materia agregada correctamente");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error al agregar la materia");
                }
            }
            else
            {
                bool resultado = dt.ejecutarComando($"Update Materia set nombre='{txtMateria.Text}', cve='{txtCVE.Text}' where id={id}");
                if (resultado)
                {
                    MessageBox.Show("Materia actualizada correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la materia");
                }
            }

        }
    }
}
