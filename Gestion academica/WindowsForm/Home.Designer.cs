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
            button1 = new Button();
            materiaButton = new Button();
            label2 = new Label();
            UsuarioButton = new Button();
            personaButton = new Button();
            SuspendLayout();
            // 
            // cursoButton
            // 
            cursoButton.Location = new Point(43, 95);
            cursoButton.Name = "cursoButton";
            cursoButton.Size = new Size(103, 33);
            cursoButton.TabIndex = 1;
            cursoButton.Text = "Cursos";
            cursoButton.UseVisualStyleBackColor = true;
            cursoButton.Click += cursoButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(169, 95);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(120, 33);
            button1.TabIndex = 2;
            button1.Text = "Especialidades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Especialidades;
            // 
            // materiaButton
            // 
            materiaButton.Location = new Point(312, 95);
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
            UsuarioButton.Location = new Point(448, 97);
            UsuarioButton.Name = "UsuarioButton";
            UsuarioButton.Size = new Size(109, 29);
            UsuarioButton.TabIndex = 4;
            UsuarioButton.Text = "Usuario";
            UsuarioButton.UseVisualStyleBackColor = true;
            UsuarioButton.Click += UsuarioButton_Click;
            // 
            // personaButton
            // 
            personaButton.Location = new Point(582, 99);
            personaButton.Name = "personaButton";
            personaButton.Size = new Size(108, 29);
            personaButton.TabIndex = 5;
            personaButton.Text = "Persona";
            personaButton.UseVisualStyleBackColor = true;
            personaButton.Click += personaButton_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(personaButton);
            Controls.Add(UsuarioButton);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(cursoButton);
            Controls.Add(materiaButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button cursoButton;
        private Button button1;
        private Button materiaButton;
        private Label label2;
        private Button UsuarioButton;
        private Button personaButton;
    }
}