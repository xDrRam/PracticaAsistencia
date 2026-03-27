namespace Asistencia
{
    partial class FormAsistencia
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
            splitContainer1 = new SplitContainer();
            txtAusentes = new TextBox();
            txtPresentes = new TextBox();
            lblAusentes = new Label();
            lblpresentes = new Label();
            label2 = new Label();
            txtBusqueda = new TextBox();
            label1 = new Label();
            dtpAsistencia = new DateTimePicker();
            dgvAsistencia = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(txtAusentes);
            splitContainer1.Panel1.Controls.Add(txtPresentes);
            splitContainer1.Panel1.Controls.Add(lblAusentes);
            splitContainer1.Panel1.Controls.Add(lblpresentes);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txtBusqueda);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(dtpAsistencia);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvAsistencia);
            splitContainer1.Size = new Size(828, 450);
            splitContainer1.SplitterDistance = 140;
            splitContainer1.TabIndex = 0;
            // 
            // txtAusentes
            // 
            txtAusentes.Location = new Point(663, 103);
            txtAusentes.Name = "txtAusentes";
            txtAusentes.Size = new Size(125, 27);
            txtAusentes.TabIndex = 9;
            // 
            // txtPresentes
            // 
            txtPresentes.Location = new Point(448, 103);
            txtPresentes.Name = "txtPresentes";
            txtPresentes.Size = new Size(125, 27);
            txtPresentes.TabIndex = 8;
            // 
            // lblAusentes
            // 
            lblAusentes.AutoSize = true;
            lblAusentes.Location = new Point(590, 103);
            lblAusentes.Name = "lblAusentes";
            lblAusentes.Size = new Size(68, 20);
            lblAusentes.TabIndex = 7;
            lblAusentes.Text = "Ausentes";
            // 
            // lblpresentes
            // 
            lblpresentes.AutoSize = true;
            lblpresentes.Location = new Point(371, 106);
            lblpresentes.Name = "lblpresentes";
            lblpresentes.Size = new Size(71, 20);
            lblpresentes.TabIndex = 6;
            lblpresentes.Text = "Presentes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 21);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 5;
            label2.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(34, 54);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(397, 27);
            txtBusqueda.TabIndex = 4;
            txtBusqueda.KeyDown += txtBusqueda_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(503, 21);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 3;
            label1.Text = "Fecha";
            // 
            // dtpAsistencia
            // 
            dtpAsistencia.Location = new Point(503, 52);
            dtpAsistencia.Name = "dtpAsistencia";
            dtpAsistencia.Size = new Size(250, 27);
            dtpAsistencia.TabIndex = 0;
            dtpAsistencia.ValueChanged += dtpAsistencia_ValueChanged;
            // 
            // dgvAsistencia
            // 
            dgvAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencia.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dgvAsistencia.Dock = DockStyle.Fill;
            dgvAsistencia.Location = new Point(0, 0);
            dgvAsistencia.Name = "dgvAsistencia";
            dgvAsistencia.RowHeadersWidth = 51;
            dgvAsistencia.Size = new Size(828, 306);
            dgvAsistencia.TabIndex = 0;
            dgvAsistencia.CellValueChanged += dgvAsistencia_CellValueChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "Asistencia";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // FormAsistencia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 450);
            Controls.Add(splitContainer1);
            Name = "FormAsistencia";
            Text = "FormAsistemcia";
            Load += FormAsistemcia_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private DateTimePicker dtpAsistencia;
        private DataGridView dgvAsistencia;
        private TextBox txtBusqueda;
        private Label label2;
        private DataGridViewCheckBoxColumn Column1;
        private TextBox txtAusentes;
        private TextBox txtPresentes;
        private Label lblAusentes;
        private Label lblpresentes;
    }
}