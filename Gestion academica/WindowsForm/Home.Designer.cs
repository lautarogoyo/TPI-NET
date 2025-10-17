namespace WindowsForms
{
    partial class Home
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
            cursoButton = new Button();
            especialidadButton = new Button();
            materiaButton = new Button();
            label2 = new Label();
            UsuarioButton = new Button();
            alumnoButton = new Button();
            profesorButton = new Button();
            planButton = new Button();
            comisionButton = new Button();
            inscripcionButton = new Button();
            SuspendLayout();
            // 
            // cursoButton
            // 
            cursoButton.Location = new Point(171, 181);
            cursoButton.Name = "cursoButton";
            cursoButton.Size = new Size(103, 33);
            cursoButton.TabIndex = 1;
            cursoButton.Text = "Cursos";
            cursoButton.UseVisualStyleBackColor = true;
            cursoButton.Click += cursoButton_Click;
            // 
            // especialidadButton
            // 
            especialidadButton.Location = new Point(19, 91);
            especialidadButton.Margin = new Padding(3, 4, 3, 4);
            especialidadButton.Name = "especialidadButton";
            especialidadButton.Size = new Size(120, 33);
            especialidadButton.TabIndex = 2;
            especialidadButton.Text = "Especialidades";
            especialidadButton.UseVisualStyleBackColor = true;
            especialidadButton.Click += especialidadButton_Click;
            // 
            // materiaButton
            // 
            materiaButton.Location = new Point(317, 95);
            materiaButton.Name = "materiaButton";
            materiaButton.Size = new Size(103, 33);
            materiaButton.TabIndex = 3;
            materiaButton.Text = "Materias";
            materiaButton.UseVisualStyleBackColor = true;
            materiaButton.Click += materiaButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label2.Location = new Point(31, 31);
            label2.Name = "label2";
            label2.Size = new Size(407, 32);
            label2.TabIndex = 3;
            label2.Text = "ALTA - BAJA - MODIFICACION";
            // 
            // UsuarioButton
            // 
            UsuarioButton.Location = new Point(463, 97);
            UsuarioButton.Name = "UsuarioButton";
            UsuarioButton.Size = new Size(113, 37);
            UsuarioButton.TabIndex = 4;
            UsuarioButton.Text = "Usuario";
            UsuarioButton.UseVisualStyleBackColor = true;
            UsuarioButton.Click += UsuarioButton_Click;
            // 
            // alumnoButton
            // 
            alumnoButton.Location = new Point(634, 99);
            alumnoButton.Name = "AlumnoButton";
            alumnoButton.Size = new Size(114, 35);
            alumnoButton.TabIndex = 5;
            alumnoButton.Text = "Alumnos";
            alumnoButton.UseVisualStyleBackColor = true;
            alumnoButton.Click += alumnoButton_Click;
            // 
            // alumnoButton
            // 
            profesorButton.Location = new Point(800, 99);
            profesorButton.Name = "profesorButton";
            profesorButton.Size = new Size(114, 35);
            profesorButton.TabIndex = 5;
            profesorButton.Text = "Profesores";
            profesorButton.UseVisualStyleBackColor = true;
            profesorButton.Click += profesorButton_Click;
            // 
            // planButton
            // 
            planButton.Location = new Point(171, 93);
            planButton.Name = "planButton";
            planButton.Size = new Size(108, 29);
            planButton.TabIndex = 6;
            planButton.Text = "Planes";
            planButton.UseVisualStyleBackColor = true;
            planButton.Click += planButton_Click;
            // 
            // comisionButton
            // 
            comisionButton.Location = new Point(19, 181);
            comisionButton.Name = "comisionButton";
            comisionButton.Size = new Size(118, 33);
            comisionButton.TabIndex = 7;
            comisionButton.Text = "Comisiones";
            comisionButton.UseVisualStyleBackColor = true;
            comisionButton.Click += comisionButton_Click;
            // 
            // inscripcionButton
            // 
            inscripcionButton.Location = new Point(350, 181);
            inscripcionButton.Name = "inscripcionButton";
            inscripcionButton.Size = new Size(159, 42);
            inscripcionButton.TabIndex = 8;
            inscripcionButton.Text = "Inscribirse";
            inscripcionButton.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(alumnoButton);
            Controls.Add(profesorButton);
            Controls.Add(UsuarioButton);
            Controls.Add(label2);
            Controls.Add(especialidadButton);
            Controls.Add(cursoButton);
            Controls.Add(materiaButton);
            Controls.Add(planButton);
            Controls.Add(comisionButton);
            Controls.Add(inscripcionButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cursoButton;
        private Button especialidadButton;
        private Button materiaButton;
        private Label label2;
        private Button UsuarioButton;
        private Button alumnoButton;
        private Button profesorButton;
        private Button planButton;
        private Button comisionButton;
        private Button inscripcionButton;
    }
}