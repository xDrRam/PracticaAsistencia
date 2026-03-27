namespace Asistencia
{
    partial class FormMaterias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            butAgregar = new Button();
            txtBuscar = new TextBox();
            label1 = new Label();
            dgvMaterias = new DataGridView();
            cmsEliminar = new ContextMenuStrip(components);
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            cmsEliminar.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(butAgregar);
            splitContainer1.Panel1.Controls.Add(txtBuscar);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvMaterias);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 128;
            splitContainer1.TabIndex = 0;
            // 
            // butAgregar
            // 
            butAgregar.Location = new Point(656, 60);
            butAgregar.Name = "butAgregar";
            butAgregar.Size = new Size(94, 29);
            butAgregar.TabIndex = 2;
            butAgregar.Text = "Agregar";
            butAgregar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(30, 62);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(508, 27);
            txtBuscar.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 23);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar";
            // 
            // dgvMaterias
            // 
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Dock = DockStyle.Fill;
            dgvMaterias.Location = new Point(0, 0);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.RowHeadersWidth = 51;
            dgvMaterias.Size = new Size(800, 318);
            dgvMaterias.TabIndex = 0;
            dgvMaterias.CellContentDoubleClick += dgvMaterias_CellContentDoubleClick;
            // 
            // cmsEliminar
            // 
            cmsEliminar.ImageScalingSize = new Size(20, 20);
            cmsEliminar.Items.AddRange(new ToolStripItem[] { eliminarToolStripMenuItem });
            cmsEliminar.Name = "cmsEliminar";
            cmsEliminar.Size = new Size(211, 56);
            cmsEliminar.Opening += contextMenuStrip1_Opening;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(210, 24);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // FormMaterias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FormMaterias";
            Text = "FormMaterias";
            Activated += FormMaterias_Activated;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            cmsEliminar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button butAgregar;
        private TextBox txtBuscar;
        private Label label1;
        private DataGridView dgvMaterias;
        private ContextMenuStrip cmsEliminar;
        private ToolStripMenuItem eliminarToolStripMenuItem;
    }
}