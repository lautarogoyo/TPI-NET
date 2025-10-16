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
            cupoTextBox = new TextBox();
            añocalendarioTextBox = new TextBox();
            descripcionTextBox = new TextBox();
            materiaComboBox = new ComboBox();
            comisionComboBox = new ComboBox();
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
            // cupoTextBox
            // 
            cupoTextBox.BackColor = SystemColors.Window;
            cupoTextBox.Location = new Point(223, 209);
            cupoTextBox.Name = "cupoTextBox";
            cupoTextBox.Size = new Size(67, 27);
            cupoTextBox.TabIndex = 1;
            // 
            // añocalendarioTextBox
            // 
            añocalendarioTextBox.BackColor = SystemColors.Window;
            añocalendarioTextBox.Location = new Point(223, 154);
            añocalendarioTextBox.Name = "añocalendarioTextBox";
            añocalendarioTextBox.Size = new Size(67, 27);
            añocalendarioTextBox.TabIndex = 2;
            // 
            // descripcionTextBox
            // 
            descripcionTextBox.BackColor = SystemColors.Window;
            descripcionTextBox.Location = new Point(223, 270);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.Size = new Size(174, 27);
            descripcionTextBox.TabIndex = 3;
            // 
            // materiaComboBox
            // 
            materiaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            materiaComboBox.FormattingEnabled = true;
            materiaComboBox.Location = new Point(223, 98);
            materiaComboBox.Name = "materiaComboBox";
            materiaComboBox.Size = new Size(174, 28);
            materiaComboBox.TabIndex = 4;
            // 
            // comisionComboBox
            // 
            comisionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comisionComboBox.FormattingEnabled = true;
            comisionComboBox.Location = new Point(223, 44);
            comisionComboBox.Name = "comisionComboBox";
            comisionComboBox.Size = new Size(174, 28);
            comisionComboBox.TabIndex = 5;
            comisionComboBox.SelectedIndexChanged += comisionComboBox_SelectedIndexChanged;
            // 
            // añoCalendarioLabel
            // 
            añoCalendarioLabel.AutoSize = true;
            añoCalendarioLabel.Location = new Point(43, 154);
            añoCalendarioLabel.Name = "añoCalendarioLabel";
            añoCalendarioLabel.Size = new Size(119, 20);
            añoCalendarioLabel.TabIndex = 7;
            añoCalendarioLabel.Text = "Año Calendario :";
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(43, 216);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(51, 20);
            cupoLabel.TabIndex = 8;
            cupoLabel.Text = "Cupo :";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(43, 273);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(94, 20);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Text = "Descripcion :";
            // 
            // comisionLabel
            // 
            comisionLabel.AutoSize = true;
            comisionLabel.Location = new Point(43, 44);
            comisionLabel.Name = "comisionLabel";
            comisionLabel.Size = new Size(82, 20);
            comisionLabel.TabIndex = 10;
            comisionLabel.Text = "Comision : ";
            // 
            // materiaLabel
            // 
            materiaLabel.AutoSize = true;
            materiaLabel.Location = new Point(43, 98);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(67, 20);
            materiaLabel.TabIndex = 11;
            materiaLabel.Text = "Materia :";
            // 
            // aceptarBoton
            // 
            aceptarBoton.Location = new Point(117, 370);
            aceptarBoton.Name = "aceptarBoton";
            aceptarBoton.Size = new Size(95, 29);
            aceptarBoton.TabIndex = 12;
            aceptarBoton.Text = "Aceptar";
            aceptarBoton.UseVisualStyleBackColor = true;
            aceptarBoton.Click += aceptarButton_Click;
            // 
            // cancelarBoton
            // 
            cancelarBoton.Location = new Point(302, 370);
            cancelarBoton.Name = "cancelarBoton";
            cancelarBoton.Size = new Size(95, 29);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(469, 440);
            Controls.Add(cancelarBoton);
            Controls.Add(aceptarBoton);
            Controls.Add(materiaLabel);
            Controls.Add(comisionLabel);
            Controls.Add(descripcionLabel);
            Controls.Add(cupoLabel);
            Controls.Add(añoCalendarioLabel);
            Controls.Add(comisionComboBox);
            Controls.Add(materiaComboBox);
            Controls.Add(descripcionTextBox);
            Controls.Add(añocalendarioTextBox);
            Controls.Add(cupoTextBox);
            Name = "CursoDetalle";
            Text = "CursoDetalle";
            Load += CursoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox cupoTextBox;
        private TextBox añocalendarioTextBox;
        private TextBox descripcionTextBox;
        private ComboBox materiaComboBox;
        private ComboBox comisionComboBox;
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
    