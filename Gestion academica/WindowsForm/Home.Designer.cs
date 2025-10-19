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
            btnDocenteCurso = new Button();
            SuspendLayout();
            // 
            // cursoButton
            // 
            cursoButton.Location = new Point(288, 355);
            cursoButton.Name = "cursoButton";
            cursoButton.Size = new Size(166, 48);
            cursoButton.TabIndex = 1;
            cursoButton.Text = "Cursos";
            cursoButton.UseVisualStyleBackColor = true;
            cursoButton.Click += cursoButton_Click;
            // 
            // especialidadButton
            // 
            especialidadButton.Location = new Point(46, 353);
            especialidadButton.Margin = new Padding(3, 4, 3, 4);
            especialidadButton.Name = "especialidadButton";
            especialidadButton.Size = new Size(163, 50);
            especialidadButton.TabIndex = 2;
            especialidadButton.Text = "Especialidades";
            especialidadButton.UseVisualStyleBackColor = true;
            especialidadButton.Click += especialidadButton_Click;
            // 
            // materiaButton
            // 
            materiaButton.Location = new Point(534, 357);
            materiaButton.Name = "materiaButton";
            materiaButton.Size = new Size(160, 46);
            materiaButton.TabIndex = 3;
            materiaButton.Text = "Materias";
            materiaButton.UseVisualStyleBackColor = true;
            materiaButton.Click += materiaButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label2.Location = new Point(102, 107);
            label2.Name = "label2";
            label2.Size = new Size(572, 32);
            label2.TabIndex = 3;
            label2.Text = "GESTIÓN ACADÉMICA - ADMINISTRACIÓN";
            // 
            // UsuarioButton
            // 
            UsuarioButton.Location = new Point(49, 471);
            UsuarioButton.Name = "UsuarioButton";
            UsuarioButton.Size = new Size(163, 50);
            UsuarioButton.TabIndex = 4;
            UsuarioButton.Text = "Usuarios";
            UsuarioButton.UseVisualStyleBackColor = true;
            UsuarioButton.Click += UsuarioButton_Click;
            // 
            // alumnoButton
            // 
            alumnoButton.Location = new Point(296, 471);
            alumnoButton.Name = "alumnoButton";
            alumnoButton.Size = new Size(158, 47);
            alumnoButton.TabIndex = 5;
            alumnoButton.Text = "Alumnos";
            alumnoButton.UseVisualStyleBackColor = true;
            alumnoButton.Click += alumnoButton_Click;
            // 
            // profesorButton
            // 
            profesorButton.Location = new Point(534, 212);
            profesorButton.Name = "profesorButton";
            profesorButton.Size = new Size(164, 50);
            profesorButton.TabIndex = 5;
            profesorButton.Text = "Profesores";
            profesorButton.UseVisualStyleBackColor = true;
            profesorButton.Click += profesorButton_Click;
            // 
            // planButton
            // 
            planButton.Location = new Point(288, 212);
            planButton.Name = "planButton";
            planButton.Size = new Size(160, 48);
            planButton.TabIndex = 6;
            planButton.Text = "Planes";
            planButton.UseVisualStyleBackColor = true;
            planButton.Click += planButton_Click;
            // 
            // comisionButton
            // 
            comisionButton.Location = new Point(46, 212);
            comisionButton.Name = "comisionButton";
            comisionButton.Size = new Size(166, 48);
            comisionButton.TabIndex = 7;
            comisionButton.Text = "Comisiones";
            comisionButton.UseVisualStyleBackColor = true;
            comisionButton.Click += comisionButton_Click;
            // 
            // btnDocenteCurso
            // 
            btnDocenteCurso.Location = new Point(534, 471);
            btnDocenteCurso.Name = "btnDocenteCurso";
            btnDocenteCurso.Size = new Size(164, 50);
            btnDocenteCurso.TabIndex = 8;
            btnDocenteCurso.Text = "Asignar docente a curso";
            btnDocenteCurso.UseVisualStyleBackColor = true;
            btnDocenteCurso.Click += btnDocenteCurso_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 627);
            Controls.Add(btnDocenteCurso);
            Controls.Add(alumnoButton);
            Controls.Add(profesorButton);
            Controls.Add(UsuarioButton);
            Controls.Add(label2);
            Controls.Add(especialidadButton);
            Controls.Add(cursoButton);
            Controls.Add(materiaButton);
            Controls.Add(planButton);
            Controls.Add(comisionButton);
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
        private Button btnDocenteCurso;
    }
}