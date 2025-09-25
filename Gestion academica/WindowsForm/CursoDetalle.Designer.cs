namespace WindowsForm
{
    partial class CursoDetalle
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
            IdTextBox = new TextBox();
            cupoTextBox = new TextBox();
            añocalendarioTextBox = new TextBox();
            descripcionTextBox = new TextBox();
            materiaComboBox = new ComboBox();
            comisionComboBox = new ComboBox();
            idLabel = new Label();
            añoCalendarioLabel = new Label();
            cupoLabel = new Label();
            descripcionLabel = new Label();
            comisionLabel = new Label();
            materiaLabel = new Label();
            aceptarBoton = new Button();
            cancelarBoton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // IdTextBox
            // 
            IdTextBox.BackColor = SystemColors.Window;
            IdTextBox.Location = new Point(297, 33);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.ReadOnly = true;
            IdTextBox.Size = new Size(136, 27);
            IdTextBox.TabIndex = 0;
            // 
            // cupoTextBox
            // 
            cupoTextBox.BackColor = SystemColors.Window;
            cupoTextBox.Location = new Point(297, 143);
            cupoTextBox.Name = "cupoTextBox";
            cupoTextBox.ReadOnly = true;
            cupoTextBox.Size = new Size(136, 27);
            cupoTextBox.TabIndex = 1;
            cupoTextBox.TextChanged += textBox2_TextChanged;
            // 
            // añocalendarioTextBox
            // 
            añocalendarioTextBox.BackColor = SystemColors.Window;
            añocalendarioTextBox.Location = new Point(297, 92);
            añocalendarioTextBox.Name = "añocalendarioTextBox";
            añocalendarioTextBox.ReadOnly = true;
            añocalendarioTextBox.Size = new Size(136, 27);
            añocalendarioTextBox.TabIndex = 2;
            // 
            // descripcionTextBox
            // 
            descripcionTextBox.BackColor = SystemColors.Window;
            descripcionTextBox.Location = new Point(297, 196);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.ReadOnly = true;
            descripcionTextBox.Size = new Size(136, 27);
            descripcionTextBox.TabIndex = 3;
            descripcionTextBox.TextChanged += descripcionTextBox_TextChanged;
            // 
            // materiaComboBox
            // 
            materiaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            materiaComboBox.FormattingEnabled = true;
            materiaComboBox.Location = new Point(297, 310);
            materiaComboBox.Name = "materiaComboBox";
            materiaComboBox.Size = new Size(136, 28);
            materiaComboBox.TabIndex = 4;
            materiaComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comisionComboBox
            // 
            comisionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comisionComboBox.FormattingEnabled = true;
            comisionComboBox.Location = new Point(297, 251);
            comisionComboBox.Name = "comisionComboBox";
            comisionComboBox.Size = new Size(136, 28);
            comisionComboBox.TabIndex = 5;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(44, 40);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(31, 20);
            idLabel.TabIndex = 6;
            idLabel.Text = "ID :";
            idLabel.Click += label1_Click;
            // 
            // añoCalendarioLabel
            // 
            añoCalendarioLabel.AutoSize = true;
            añoCalendarioLabel.Location = new Point(44, 95);
            añoCalendarioLabel.Name = "añoCalendarioLabel";
            añoCalendarioLabel.Size = new Size(119, 20);
            añoCalendarioLabel.TabIndex = 7;
            añoCalendarioLabel.Text = "Año Calendario :";
            añoCalendarioLabel.Click += label2_Click;
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(44, 150);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(51, 20);
            cupoLabel.TabIndex = 8;
            cupoLabel.Text = "Cupo :";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(44, 203);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(94, 20);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Text = "Descripcion :";
            // 
            // comisionLabel
            // 
            comisionLabel.AutoSize = true;
            comisionLabel.Location = new Point(44, 251);
            comisionLabel.Name = "comisionLabel";
            comisionLabel.Size = new Size(82, 20);
            comisionLabel.TabIndex = 10;
            comisionLabel.Text = "Comision : ";
            // 
            // materiaLabel
            // 
            materiaLabel.AutoSize = true;
            materiaLabel.Location = new Point(44, 310);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(67, 20);
            materiaLabel.TabIndex = 11;
            materiaLabel.Text = "Materia :";
            // 
            // aceptarBoton
            // 
            aceptarBoton.Location = new Point(498, 395);
            aceptarBoton.Name = "aceptarBoton";
            aceptarBoton.Size = new Size(94, 29);
            aceptarBoton.TabIndex = 12;
            aceptarBoton.Text = "Aceptar";
            aceptarBoton.UseVisualStyleBackColor = true;
            // 
            // cancelarBoton
            // 
            cancelarBoton.Location = new Point(624, 395);
            cancelarBoton.Name = "cancelarBoton";
            cancelarBoton.Size = new Size(94, 29);
            cancelarBoton.TabIndex = 13;
            cancelarBoton.Text = "Cancelar";
            cancelarBoton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // CursoDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelarBoton);
            Controls.Add(aceptarBoton);
            Controls.Add(materiaLabel);
            Controls.Add(comisionLabel);
            Controls.Add(descripcionLabel);
            Controls.Add(cupoLabel);
            Controls.Add(añoCalendarioLabel);
            Controls.Add(idLabel);
            Controls.Add(comisionComboBox);
            Controls.Add(materiaComboBox);
            Controls.Add(descripcionTextBox);
            Controls.Add(añocalendarioTextBox);
            Controls.Add(cupoTextBox);
            Controls.Add(IdTextBox);
            Name = "CursoDetalle";
            Text = "CursoDetalle";
            Load += CursoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IdTextBox;
        private TextBox cupoTextBox;
        private TextBox añocalendarioTextBox;
        private TextBox descripcionTextBox;
        private ComboBox materiaComboBox;
        private ComboBox comisionComboBox;
        private Label idLabel;
        private Label añoCalendarioLabel;
        private Label cupoLabel;
        private Label descripcionLabel;
        private Label comisionLabel;
        private Label materiaLabel;
        private Button aceptarBoton;
        private Button cancelarBoton;
        private ErrorProvider errorProvider;
    }
}