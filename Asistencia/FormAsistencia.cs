using Asistencia.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asistencia
{
    public partial class FormAsistencia : Form
    {
        Datos dt = new Datos();
        bool cargarreporte = false;
        public FormAsistencia()
        {
            InitializeComponent();

        }

        public void Asistencia()
        {

            string fecha = dtpAsistencia.Value.ToString("yyyy-MM-dd");

            DataSet ds = dt.ejecutar($@"select a.idAlumno,a.matricula, a.nombre, a.apellidos,COALESCE(asis.asistio, 0) AS asistio
                                       FROM Alumno a LEFT JOIN Asistencia asis ON a.idAlumno = asis.idAlumno
                                        AND asis.fecha = '{fecha}'
                                        WHERE a.nombre LIKE '%{txtBusqueda.Text.Trim()}%'
                                        GROUP BY a.idAlumno, a.matricula, a.nombre, a.apellidos, asis.asistio");

            if (ds != null && ds.Tables.Count > 0)
            {
                dgvAsistencia.DataSource = ds.Tables[0];
                //ocultamos columnas por nombre
                if (dgvAsistencia.Columns["asistio"] != null)
                    dgvAsistencia.Columns["asistio"].Visible = false;

                if (dgvAsistencia.Columns["idAlumno"] != null)
                    dgvAsistencia.Columns["idAlumno"].Visible = false;

                //Para poder configurar el check box
                if (dgvAsistencia.Columns["Column1"] != null)
                {
                    // Configuración del CheckBox de la columna existente
                    DataGridViewCheckBoxColumn chk = (DataGridViewCheckBoxColumn)dgvAsistencia.Columns["Column1"];
                    chk.DataPropertyName = "asistio";
                    chk.TrueValue = 1;
                    chk.FalseValue = 0;
                    chk.ValueType = typeof(int);
                }
            }
            marcarAusencia();
            actualizarContador();
        }
        private void FormAsistemcia_Load(object sender, EventArgs e)
        {
            Asistencia();
            marcarAusencia();
            actualizarContador();
            dgvAsistencia.CurrentCellDirtyStateChanged += DgvAsistencia_CurrentCellDirtyStateChanged;

        }

        private void dtpAsistencia_ValueChanged(object sender, EventArgs e)
        {  
            txtBusqueda.Clear();    
            Asistencia();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                txtBusqueda.Focus();
                txtBusqueda.Select();
            };
            timer.Start();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {

            //enter
            if (e.KeyCode == Keys.Enter)
            {
                //Obtenemos el texto del texbox y le quitamos los espacios
                string matriculaBuscar = txtBusqueda.Text.Trim();

                foreach (DataGridViewRow fila in dgvAsistencia.Rows)
                {
                    if (fila.Cells["matricula"].Value?.ToString() == matriculaBuscar)
                    {
                        //Obtenemos las matricula de la fila actual para poder compararla con la que estamos buscando
                        string matricula = fila.Cells["matricula"].Value?.ToString();
                        //Comparamos
                        if (matriculaBuscar == matricula)
                        {
                            //Validamos
                            if (fila.Cells["Column1"].Value != null && Convert.ToBoolean(fila.Cells["Column1"].Value))
                            {
                                //Desmarcamos la casilla
                                fila.Cells["Column1"].Value = false;
                                //asignamos color rojo
                                fila.DefaultCellStyle.BackColor = Color.LightCoral;
                                //Limpiamos
                                txtBusqueda.Clear();
                                return;
                            }
                        }

                        //Marcamos el checkBox 
                        fila.Cells["Column1"].Value = true;

                        //color verde para confirmar que asistio
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;

                        //Limpiamos el txt para poder volver a escribir algo
                        txtBusqueda.Clear();
                        return;
                    }
                }

                txtBusqueda.Clear();
            }
        }

        private void marcarAusencia()
        {
            foreach (DataGridViewRow fila in dgvAsistencia.Rows)
            {
                bool marcado = fila.Cells["Column1"].Value != null && Convert.ToBoolean(fila.Cells["Column1"].Value);

                if (marcado)
                {   
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                    fila.DefaultCellStyle.ForeColor = Color.Black; // Color de la letra
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
                    fila.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void dgvAsistencia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvAsistencia.Columns["Column1"] == null) return;
            if (e.ColumnIndex != dgvAsistencia.Columns["Column1"].Index) return;

            DataGridViewRow filaActual = dgvAsistencia.Rows[e.RowIndex];
            string fecha = dtpAsistencia.Value.ToString("yyyy-MM-dd");
            string idAlumno = filaActual.Cells["idAlumno"].Value.ToString();
            int valor = Convert.ToBoolean(filaActual.Cells["Column1"].Value) ? 1 : 0;

            // Procesar en segundo plano para no trabar la pantalla
            new Thread(() =>
            {
                DataSet ds = dt.ejecutar($"select count(*) from Asistencia where idAlumno={idAlumno} and fecha='{fecha}'");
                int existe = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (existe == 0)
                    dt.ejecutarComando($"insert into Asistencia (idAlumno,fecha,asistio) VALUES({idAlumno},'{fecha}',{valor})");
                else
                    dt.ejecutarComando($"update Asistencia set asistio={valor} where idAlumno={idAlumno} and fecha='{fecha}'");

                //hilo
                this.Invoke((MethodInvoker)delegate {
                    marcarAusencia();
                    actualizarContador();
                });
            })
            { IsBackground = true }.Start();
        }


        private void actualizarContador()
        {
            int presentes = 0, ausentes = 0;
           
            foreach (DataGridViewRow fila in dgvAsistencia.Rows)
            {
                //Guardamos en ina variable el valor del checkbox de la fila en la que se encuentra
                if (fila.Cells["Column1"].Value != null && Convert.ToBoolean(fila.Cells["Column1"].Value))
                {
                    presentes++;
                }
                else
                {
                    ausentes++;
                }

            }

            txtPresentes.Text = $"Presentes: {presentes}";
            txtPresentes.ForeColor = Color.Green; // Texto en verde

            txtAusentes.Text = $"Ausentes:  {ausentes}";
            txtAusentes.ForeColor = Color.Red;   // Texto en rojo
        }
        private void DgvAsistencia_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dgvAsistencia.IsCurrentCellDirty)
            {

                dgvAsistencia.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
