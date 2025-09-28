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
            IdTextBox.Location = new Point(260, 25);
            IdTextBox.Margin = new Padding(3, 2, 3, 2);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.Size = new Size(120, 23);
            IdTextBox.TabIndex = 0;
            // 
            // cupoTextBox
            // 
            cupoTextBox.BackColor = SystemColors.Window;
            cupoTextBox.Location = new Point(260, 107);
            cupoTextBox.Margin = new Padding(3, 2, 3, 2);
            cupoTextBox.Name = "cupoTextBox";
            cupoTextBox.Size = new Size(120, 23);
            cupoTextBox.TabIndex = 1;
            // 
            // añocalendarioTextBox
            // 
            añocalendarioTextBox.BackColor = SystemColors.Window;
            añocalendarioTextBox.Location = new Point(260, 69);
            añocalendarioTextBox.Margin = new Padding(3, 2, 3, 2);
            añocalendarioTextBox.Name = "añocalendarioTextBox";
            añocalendarioTextBox.Size = new Size(120, 23);
            añocalendarioTextBox.TabIndex = 2;
            // 
            // descripcionTextBox
            // 
            descripcionTextBox.BackColor = SystemColors.Window;
            descripcionTextBox.Location = new Point(260, 147);
            descripcionTextBox.Margin = new Padding(3, 2, 3, 2);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.Size = new Size(120, 23);
            descripcionTextBox.TabIndex = 3;
            // 
            // materiaComboBox
            // 
            materiaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            materiaComboBox.FormattingEnabled = true;
            materiaComboBox.Location = new Point(260, 233);
            materiaComboBox.Margin = new Padding(3, 2, 3, 2);
            materiaComboBox.Name = "materiaComboBox";
            materiaComboBox.Size = new Size(120, 23);
            materiaComboBox.TabIndex = 4;
            // 
            // comisionComboBox
            // 
            comisionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comisionComboBox.FormattingEnabled = true;
            comisionComboBox.Location = new Point(260, 188);
            comisionComboBox.Margin = new Padding(3, 2, 3, 2);
            comisionComboBox.Name = "comisionComboBox";
            comisionComboBox.Size = new Size(120, 23);
            comisionComboBox.TabIndex = 5;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(38, 30);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 15);
            idLabel.TabIndex = 6;
            idLabel.Text = "ID :";
            // 
            // añoCalendarioLabel
            // 
            añoCalendarioLabel.AutoSize = true;
            añoCalendarioLabel.Location = new Point(38, 71);
            añoCalendarioLabel.Name = "añoCalendarioLabel";
            añoCalendarioLabel.Size = new Size(95, 15);
            añoCalendarioLabel.TabIndex = 7;
            añoCalendarioLabel.Text = "Año Calendario :";
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(38, 113);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(42, 15);
            cupoLabel.TabIndex = 8;
            cupoLabel.Text = "Cupo :";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(38, 152);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(75, 15);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Text = "Descripcion :";
            // 
            // comisionLabel
            // 
            comisionLabel.AutoSize = true;
            comisionLabel.Location = new Point(38, 188);
            comisionLabel.Name = "comisionLabel";
            comisionLabel.Size = new Size(67, 15);
            comisionLabel.TabIndex = 10;
            comisionLabel.Text = "Comision : ";
            // 
            // materiaLabel
            // 
            materiaLabel.AutoSize = true;
            materiaLabel.Location = new Point(38, 233);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(53, 15);
            materiaLabel.TabIndex = 11;
            materiaLabel.Text = "Materia :";
            // 
            // aceptarBoton
            // 
            aceptarBoton.Location = new Point(435, 296);
            aceptarBoton.Margin = new Padding(3, 2, 3, 2);
            aceptarBoton.Name = "aceptarBoton";
            aceptarBoton.Size = new Size(83, 22);
            aceptarBoton.TabIndex = 12;
            aceptarBoton.Text = "Aceptar";
            aceptarBoton.UseVisualStyleBackColor = true;
            aceptarBoton.Click += aceptarButton_Click;
            // 
            // cancelarBoton
            // 
            cancelarBoton.Location = new Point(546, 296);
            cancelarBoton.Margin = new Padding(3, 2, 3, 2);
            cancelarBoton.Name = "cancelarBoton";
            cancelarBoton.Size = new Size(83, 22);
            cancelarBoton.TabIndex = 13;
            cancelarBoton.Text = "Cancelar";
            cancelarBoton.UseVisualStyleBackColor = true;
            cancelarBoton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // CursoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(700, 337);
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
            Margin = new Padding(3, 2, 3, 2);
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