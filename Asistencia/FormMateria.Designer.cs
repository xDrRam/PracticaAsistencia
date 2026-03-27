namespace Asistencia
{
    partial class FormMateria
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
            label1 = new Label();
            txtMateria = new TextBox();
            butAgregar = new Button();
            txtCVE = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 30);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Materia";
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(26, 63);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(336, 27);
            txtMateria.TabIndex = 1;
            // 
            // butAgregar
            // 
            butAgregar.Location = new Point(268, 134);
            butAgregar.Name = "butAgregar";
            butAgregar.Size = new Size(94, 29);
            butAgregar.TabIndex = 2;
            butAgregar.Text = "Agregar";
            butAgregar.UseVisualStyleBackColor = true;
            butAgregar.Click += butAgregar_Click;
            // 
            // txtCVE
            // 
            txtCVE.Location = new Point(26, 134);
            txtCVE.Name = "txtCVE";
            txtCVE.Size = new Size(199, 27);
            txtCVE.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 111);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 3;
            label2.Text = "CVE";
            // 
            // FormMateria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 187);
            Controls.Add(txtCVE);
            Controls.Add(label2);
            Controls.Add(butAgregar);
            Controls.Add(txtMateria);
            Controls.Add(label1);
            Name = "FormMateria";
            Text = "FormMateria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMateria;
        private Button butAgregar;
        private TextBox txtCVE;
        private Label label2;
    }
}