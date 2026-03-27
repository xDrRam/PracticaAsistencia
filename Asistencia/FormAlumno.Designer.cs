namespace Asistencia
{
    partial class FormAlumno
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            txtBusqueda = new TextBox();
            label1 = new Label();
            butAgregar = new Button();
            butImportar = new Button();
            menuStrip1 = new MenuStrip();
            asistenciaToolStripMenuItem = new ToolStripMenuItem();
            dgvAlumnos = new DataGridView();
            ofd = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtBusqueda);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(butAgregar);
            splitContainer1.Panel1.Controls.Add(butImportar);
            splitContainer1.Panel1.Controls.Add(menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvAlumnos);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 133;
            splitContainer1.TabIndex = 0;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(52, 80);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(447, 27);
            txtBusqueda.TabIndex = 4;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 44);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 3;
            label1.Text = "Alumno";
            // 
            // butAgregar
            // 
            butAgregar.Location = new Point(563, 44);
            butAgregar.Name = "butAgregar";
            butAgregar.Size = new Size(94, 29);
            butAgregar.TabIndex = 1;
            butAgregar.Text = "Agreagr";
            butAgregar.UseVisualStyleBackColor = true;
            // 
            // butImportar
            // 
            butImportar.Location = new Point(679, 44);
            butImportar.Name = "butImportar";
            butImportar.Size = new Size(94, 29);
            butImportar.TabIndex = 0;
            butImportar.Text = "Importar";
            butImportar.UseVisualStyleBackColor = true;
            butImportar.Click += butImportar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { asistenciaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "mstrip";
            // 
            // asistenciaToolStripMenuItem
            // 
            asistenciaToolStripMenuItem.Name = "asistenciaToolStripMenuItem";
            asistenciaToolStripMenuItem.Size = new Size(89, 24);
            asistenciaToolStripMenuItem.Text = "Asistencia";
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Dock = DockStyle.Fill;
            dgvAlumnos.Location = new Point(0, 0);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersWidth = 51;
            dgvAlumnos.Size = new Size(800, 313);
            dgvAlumnos.TabIndex = 0;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // FormAlumno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "FormAlumno";
            Text = "Form1";
            Load += FormAlumno_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button butAgregar;
        private Button butImportar;
        private DataGridView dgvAlumnos;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem asistenciaToolStripMenuItem;
        private OpenFileDialog ofd;
        private TextBox txtBusqueda;
        private Label label1;
    }
}
