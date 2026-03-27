namespace Asistencia
{
    partial class FormMenu
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            catalogoToolStripMenuItem = new ToolStripMenuItem();
            alumnoToolStripMenuItem = new ToolStripMenuItem();
            materiaToolStripMenuItem = new ToolStripMenuItem();
            maestroToolStripMenuItem = new ToolStripMenuItem();
            asistenciaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, catalogoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(121, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // catalogoToolStripMenuItem
            // 
            catalogoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { alumnoToolStripMenuItem, materiaToolStripMenuItem, maestroToolStripMenuItem, asistenciaToolStripMenuItem });
            catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
            catalogoToolStripMenuItem.Size = new Size(84, 24);
            catalogoToolStripMenuItem.Text = "Catalogo";
            // 
            // alumnoToolStripMenuItem
            // 
            alumnoToolStripMenuItem.Name = "alumnoToolStripMenuItem";
            alumnoToolStripMenuItem.Size = new Size(224, 26);
            alumnoToolStripMenuItem.Text = "Alumno";
            alumnoToolStripMenuItem.Click += alumnoToolStripMenuItem_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(224, 26);
            materiaToolStripMenuItem.Text = "Materia";
            // 
            // maestroToolStripMenuItem
            // 
            maestroToolStripMenuItem.Name = "maestroToolStripMenuItem";
            maestroToolStripMenuItem.Size = new Size(224, 26);
            maestroToolStripMenuItem.Text = "Maestro";
            // 
            // asistenciaToolStripMenuItem
            // 
            asistenciaToolStripMenuItem.Name = "asistenciaToolStripMenuItem";
            asistenciaToolStripMenuItem.Size = new Size(224, 26);
            asistenciaToolStripMenuItem.Text = "Asistencia";
            asistenciaToolStripMenuItem.Click += asistenciaToolStripMenuItem_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenu";
            Text = "FormMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem catalogoToolStripMenuItem;
        private ToolStripMenuItem alumnoToolStripMenuItem;
        private ToolStripMenuItem materiaToolStripMenuItem;
        private ToolStripMenuItem maestroToolStripMenuItem;
        private ToolStripMenuItem asistenciaToolStripMenuItem;
    }
}