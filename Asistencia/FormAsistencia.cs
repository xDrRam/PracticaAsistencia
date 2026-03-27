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
                //Este es solo para ocultar la columna asistio que estoy generando de la consulta
                if (dgvAsistencia.Columns["asistio"] != null)
                    dgvAsistencia.Columns["asistio"].Visible = false;

                if (dgvAsistencia.Columns["idAlumno"] != null)
                    dgvAsistencia.Columns["idAlumno"].Visible = false;

                //Para poder configurar el check box
                if (dgvAsistencia.Columns["Column1"] != null)
                {
                    //Este es para poder accder a las propiedades del check box
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

        /* private void butAsistencia_Click(object sender, EventArgs e)
         {
             //Para obtener la fecha seleccionada en el datetimepicker y darle el formato adecuado para la consulta SQL
             string fecha = dtpAsistencia.Value.ToString("yyyy-MM-dd");
             //Hacemos una lista de tuplas para almacenar el id del alumno y si es que asistio 
             List<(string idAlumno, int valor)> fila = new List<(string idAlumno, int valor)>();


             for (int i = 0; i < dgvAsistencia.Rows.Count; i++)
             {
                 //Si es la fila nueva del final la ignoramos porque esa fila no tiene datos y no queremos procesarla
                 if (dgvAsistencia.Rows[i].IsNewRow)
                 {
                     continue;
                 }
                 //Obtener el id del alumno de la fila actual 
                 string idAlumno = dgvAsistencia.Rows[i].Cells["idAlumno"].Value.ToString();
                 //Checamos el valor del checkBox de la fila actual
                 bool asistencia = dgvAsistencia.Rows[i].Cells["Column1"].Value != null &&
                   Convert.ToBoolean(dgvAsistencia.Rows[i].Cells["Column1"].Value);
                 //Agregamos el id y el valor a la lista (1 true ,0 false)
                 fila.Add((idAlumno, asistencia ? 1 : 0));
             }
             //Creamos un nuevo hilo para procesar los datos sin que se congele la interfaz
             Thread hilo = new Thread(() =>
             {
                 //Recorre la lista que creamos 
                 for (int i = 0; i < fila.Count; i++)
                 {
                     //Consulta de si ya existe un registro de asistencia para ese alumno en esa fecha,
                     //si existe se actualiza el valor de asistio, si no existe se inserta un nuevo registro, esto es para evitar tener registros duplicados de asistencia para el mismo alumno en la misma fecha
                     string sql = $"Select count(*) from Asistencia where idAlumno={fila[i].idAlumno} and fecha='{fecha}'";
                     DataSet ds = dt.ejecutar(sql);
                     //Convierte el resultado del conteo a un número entero.
                     int existe = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                     //Si el conteo es 0 significa que no existe un registro de asistencia para ese alumno en esa fecha, entonces se inserta un nuevo registro
                     if (existe == 0)
                     {
                         dt.ejecutarComando($"Insert into Asistencia (idAlumno,fecha,asistio) values({fila[i].idAlumno}, '{fecha}', {fila[i].valor})");
                     }
                     else
                     {
                         //Si ya existe, actualiza el estado de la asistencia 
                         dt.ejecutarComando($"Update Asistencia set asistio = {fila[i].valor} where idAlumno = {fila[i].idAlumno} and fecha = '{fecha}'");
                     }
                 }
                 //Una vez terminado de procesar los datos regresa al hilo principal
                 this.Invoke((Action)(() =>
                 {
                     MessageBox.Show("Asistencia registrada correctamente");
                 }));
             });
             //Configura el hilo como 'Background' para que se cierre automáticamente si el programa se cierra.
             hilo.IsBackground = true;
             //Inicia el hilo para procesar los datos de asistencia.
             hilo.Start();
             marcarAusencia();
         }*/



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

            // Verificamos si la tecla presionada fue enter
            if (e.KeyCode == Keys.Enter)
            {
                //Obtenemos el texto del texbox y le quitamos los espacios
                string matriculaBuscar = txtBusqueda.Text.Trim();

                // Recorremos el Grid para buscar la matrícula aunque se puede usar un for normal pero es mas sencillo el each
                //for(int i= 0; i < dgvAsistencia.Rows.Count; i++) 
                foreach (DataGridViewRow fila in dgvAsistencia.Rows)
                {
                    if (fila.Cells["matricula"].Value?.ToString() == matriculaBuscar)
                    {
                        //Obtenemos las matricula de la fila actual para poder compararla con la que estamos buscando
                        string matricula = fila.Cells["matricula"].Value?.ToString();
                        //Comparamos
                        if (matriculaBuscar == matricula)
                        {
                            //Validamos que este marcado y convertimos el valor a booleano en pocas palbras si esta marcada entra
                            if (fila.Cells["Column1"].Value != null && Convert.ToBoolean(fila.Cells["Column1"].Value))
                            {
                                //Desmarcamos la casilla
                                fila.Cells["Column1"].Value = false;
                                //Y le asignamos un color rojo
                                fila.DefaultCellStyle.BackColor = Color.LightCoral;
                                //Limpiamos el txt para poder volver a escribir algo
                                txtBusqueda.Clear();
                                return;
                            }
                        }

                        //Marcamos la columna o el checkBox 
                        fila.Cells["Column1"].Value = true;

                        //La pintamos de color verde para confirmar que asistio
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
            //Tambien puede ser for(int i = 0; i < dgvAsistencia.Rows.Count; i++)
            //Recorremos cada fila del dgv para verfiicar cada checkbox

            foreach (DataGridViewRow fila in dgvAsistencia.Rows)
            {

                //Guardamos en una variable si el checkbox esta marcado o no y convertimos el valor en booleano
                bool marcado = fila.Cells["Column1"].Value != null && Convert.ToBoolean(fila.Cells["Column1"].Value);

                if (!marcado)
                {
                    //Si no esta marcado le damos un color rojo
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    //Si esta marcado le damos un color verde 
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

        }

        private void dgvAsistencia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Practicamente lo mismo que hice en el boton pero ahora por cada que vaya marcando validar 
            //Todos estos if son para verificar que solo cuando se hace click en la casilla del check
            //Este de aqui si damos click en el encabezado de la columna o en cualquier parte que no sea una celda valida se regresa para evitar errores
            if (e.RowIndex < 0)
            {
                return;
            }
            //Para verificar que la columna exista
            if (dgvAsistencia.Columns["Column1"] == null)
            {
                return;
            }
            //Solo continuo su la celda que cambio es la del checkbox
            if (e.ColumnIndex != dgvAsistencia.Columns["Column1"].Index)
            {
                return;
            }

            //Obtenemos la fila actual donde se hizo el cambio
            DataGridViewRow filaActual = dgvAsistencia.Rows[e.RowIndex];

            //Obtenemos la fecha seleccionada del dtp y le damos el formato adecuado
            string fecha = dtpAsistencia.Value.ToString("yyyy-MM-dd");
            //Obtenemmos el id del alumno de la fila en la que estamos actualmente
            string idAlumno = filaActual.Cells["idAlumno"].Value.ToString();
            //Obtenemos el valor del checkbox y la convertimos a booleano para saber si esta marcado
            bool asistio = filaActual.Cells["Column1"].Value != null &&
                           Convert.ToBoolean(filaActual.Cells["Column1"].Value);
            //Guardamos 1 o 0 si esta marcado o no 
            int valor = asistio ? 1 : 0;
            //declaramos los hilo para poder procesar la informacion de manera mas rapida
            Thread hilo = new Thread(() =>
            {
                //Ya no uso string builder ya que lo hare por cada que estoy marcando y es ma rapido 
                //Ejecuto la consulta
                DataSet ds = dt.ejecutar($"select count(*) from Asistencia where idAlumno={idAlumno} and fecha='{fecha}'");
                //Si el resultado es mayor a 0 entonces ya estaba registrado ese dia 
                int existe = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (existe == 0)
                    //Hago el insert si no existe un registro de asistencia para ese alumno en esa fecha
                    dt.ejecutarComando($"insert into Asistencia (idAlumno,fecha,asistio) VALUES({idAlumno},'{fecha}',{valor})");
                else
                    //Si ya existe un registro de asistencia para ese alumno en esa fecha
                    dt.ejecutarComando($"update Asistencia set asistio={valor} where idAlumno={idAlumno} and fecha='{fecha}'");
                //Una vez que se actualiza la base de datos regresa al hilo principal para actualizar el color de la fila y el contador de presentes y ausentes
                this.Invoke((Action)(() =>
                {
                    marcarAusencia();
                    actualizarContador();
                }));
            });
            //Configura el hilo como back para cerrarlo automaticamente si es que se cierra
            hilo.IsBackground = true;
            //Inicia el hilo para procesar la información de asistencia
            hilo.Start();
        }


        private void actualizarContador()
        {
            int presentes = 0;
            int ausentes = 0;
            //Ciclo para recorrer el dgv y contar las presencias y ausencias
            foreach (DataGridViewRow fila in dgvAsistencia.Rows)
            {
                //Guardamos en ina variable el valor del checkbox de la fila en la que se encuentra
                bool marcado = fila.Cells["Column1"].Value != null &&
                               Convert.ToBoolean(fila.Cells["Column1"].Value);
                if (marcado)
                {
                    presentes++;
                }
                else
                {
                    ausentes++;
                }

            }

            txtPresentes.Text = $"Presentes: {presentes}";
            txtAusentes.Text = $"Ausentes:  {ausentes}";
        }
        //Este metodo es para que cada que se marque o se desmarque un checkbox se actualice el valor de la celda inmediatamente sin tener que esperar a que se pierda el foco de la celda,
        //esto es para que se actualice el color de la fila y el contador de presentes y ausentes al instante
        private void DgvAsistencia_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //Si la celda actual esta en estado de edicion, entonces se confirma la edición para que se dispare el evento CellValueChanged y se actualice el color y el contador al instante
            if (dgvAsistencia.IsCurrentCellDirty)
            {
                //Este metodo es para confirmar la edición de la celda actual, esto es necesario para que se dispare el evento CellValueChanged al instante y se actualice el color de la fila y
                //el contador de presentes y ausentes sin tener que esperar a que se pierda el foco de la celda
                dgvAsistencia.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
