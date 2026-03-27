using Asistencia.Clases;
using OfficeOpenXml;
using System.Text;
using System.Threading;
using System.Data;

namespace Asistencia
{
    public partial class FormAlumno : Form
    {
        public FormAlumno()
        {
            InitializeComponent();
        }
        Datos dt = new Datos();

        private void butImportar_Click(object sender, EventArgs e)
        {
            string path; //Variable para ir almacenar la ruta del archivo seleccionado
            DialogResult dr = ofd.ShowDialog(); //Es la ventana para poder seleccionar el archivo

            if (dr == DialogResult.OK)
            {
                path = ofd.FileName;//Guardamos la ruta del archivo
                ExcelPackage.License.SetNonCommercialPersonal("Andres"); //Solo es para confugurar la licencia de EPPlus, no es necesario para la funcionalidad del programa
                //Es para abrir el archivo excel usando un bloque using para asegurar que se cierre al terminar 
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    //Obtener la primera columna del excel 
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    //El numero total de filas con datos 
                    int rowCount = worksheet.Dimension.Rows;
                    //Para definir el tamaño del bloque para poder ir procesando de 50 en 50
                    int lote = 50;
                    //Laista para ir almacenando los hilos que se van creando para cada bloque de datos
                    List<Thread> hilos = new List<Thread>();

                    //ciclo para recorrer las filas del excel saltando de 50 en 50 para ir creando los bloques de datos
                    for (int i = 2; i <= rowCount; i+=lote)
                    {
                        //Para construir consultas mas largas
                        StringBuilder masivo = new StringBuilder();
                        //Estamos creando la consulta de inserción masiva, el "Insert ignore" es para evitar errores por duplicados, si ya existe un alumno con la misma matricula simplemente se ignora esa fila
                        masivo.Append("Insert ignore into Alumno(nombre,apellidos,matricula)values");
                        bool hayDatos = false;
                        //Este ciclo es para recorrer cada bloque de 50 filas y construir la parte de valores de la consulta de inserción masiva
                        for (int j = i; j < i + lote && j <= rowCount; j++)
                        {
                            string nombre = worksheet.Cells[j, 2].Value?.ToString().Trim();
                            string pat = worksheet.Cells[j, 3].Value?.ToString().Trim();
                            string mat = worksheet.Cells[j, 4].Value?.ToString().Trim();
                            string matricula = worksheet.Cells[j, 1].Value?.ToString().Trim();
                            //Solo es para validar que el nombre y el apellido paterno no estén vacíos, si alguno de los dos está vacío se omite esa fila, esto es para evitar insertar registros con datos incompletosq
                            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(pat))
                            {
                                //Solo es para jutnar los apellidos juntos
                                string apellidos = $"{pat} {mat}";
                                //Es para agregar los datos a la consulta
                                masivo.Append($"('{nombre}','{apellidos}','{matricula}'),");
                                hayDatos = true;
                            }
                        }
                        //Si esta vacia nos pasamos a la siguiente 
                        if (!hayDatos)
                        {
                            continue;
                        }
                        //Para eliminar la ultima coma sobrante de la consulta 
                        string comando = masivo.ToString().TrimEnd(',');
                        //Creamos el nuevo hilo para ejcutar la consulta
                        Thread hilo = new Thread(() =>
                        {
                            //Es la instancia de la clase que tenemos para ejecutar consultas etc..
                            Datos dt = new Datos();
                            try
                            {
                                //Ejecuta el insert masivo para ese bloque de datos
                                dt.ejecutarComando(comando);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al insertar lote: {ex.Message}");
                            }
                        });

                        hilos.Add(hilo);//Agrega el hilo a la lista de control
                        hilo.Start();//Inicia la ejecucion del hilo

                    }
                    //Para esperar a que todos los hilos terminen de hacer su chamba
                    for (int i = 0; i < hilos.Count; i++)
                    {
                        //Detiene el hilo principal cada que el hilo en esa pos termine 
                        hilos[i].Join();
                     
                    }
                    //Usa Invoke para actualizar la UI desde un hilo distinto al principal.
                    this.Invoke((Action)(() =>
                    {
                        //Refrescamos el grid 
                        Busqueda();
                        MessageBox.Show("Importación completada exitosamente.");
                    }));
                }


            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Busqueda();
        }

        public void Busqueda()
        {
            DataSet ds = dt.ejecutar($"select matricula,nombre,apellidos from Alumno " +
                $"where nombre like '%{txtBusqueda.Text}%'");

            if (ds != null && ds.Tables.Count > 0)
            {
                dgvAlumnos.DataSource = ds.Tables[0];
            }


        }

        private void FormAlumno_Load(object sender, EventArgs e)
        {
            Busqueda();
        }
    }
}
