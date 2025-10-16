namespace WindowsForm
{
    partial class PersonaDetalle
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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            direccionLabel = new Label();
            direccionTextBox = new TextBox();
            telefonoLabel = new Label();
            telefonoTextBox = new TextBox();
            legajoLabel = new Label();
            legajoTextBox = new TextBox();
            tipoDocLabel = new Label();
            tipoDocComboBox = new ComboBox();
            nroDocLabel = new Label();
            nroDocTextBox = new TextBox();
            fechaNacLabel = new Label();
            fechaNacPicker = new DateTimePicker();
            fechaNacPicker.Format = DateTimePickerFormat.Short;
            tipoPersonaLabel = new Label();
            tipoPersonaComboBox = new ComboBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(14, 52);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 1;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(99, 48);
            nombreTextBox.Margin = new Padding(3, 4, 3, 4);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(175, 27);
            nombreTextBox.TabIndex = 2;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(342, 52);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(66, 20);
            apellidoLabel.TabIndex = 3;
            apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(414, 49);
            apellidoTextBox.Margin = new Padding(3, 4, 3, 4);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(175, 27);
            apellidoTextBox.TabIndex = 4;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(14, 118);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 5;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(99, 114);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(175, 27);
            emailTextBox.TabIndex = 6;
            // 
            // direccionLabel
            // 
            direccionLabel.AutoSize = true;
            direccionLabel.Location = new Point(336, 117);
            direccionLabel.Name = "direccionLabel";
            direccionLabel.Size = new Size(72, 20);
            direccionLabel.TabIndex = 7;
            direccionLabel.Text = "Dirección";
            // 
            // direccionTextBox
            // 
            direccionTextBox.Location = new Point(414, 115);
            direccionTextBox.Margin = new Padding(3, 4, 3, 4);
            direccionTextBox.Name = "direccionTextBox";
            direccionTextBox.Size = new Size(175, 27);
            direccionTextBox.TabIndex = 8;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(14, 184);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(67, 20);
            telefonoLabel.TabIndex = 9;
            telefonoLabel.Text = "Teléfono";
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(99, 180);
            telefonoTextBox.Margin = new Padding(3, 4, 3, 4);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(175, 27);
            telefonoTextBox.TabIndex = 10;
            // 
            // legajoLabel
            // 
            legajoLabel.AutoSize = true;
            legajoLabel.Location = new Point(342, 180);
            legajoLabel.Name = "legajoLabel";
            legajoLabel.Size = new Size(54, 20);
            legajoLabel.TabIndex = 11;
            legajoLabel.Text = "Legajo";
            // 
            // legajoTextBox
            // 
            legajoTextBox.Location = new Point(414, 177);
            legajoTextBox.Margin = new Padding(3, 4, 3, 4);
            legajoTextBox.Name = "legajoTextBox";
            legajoTextBox.Size = new Size(175, 27);
            legajoTextBox.TabIndex = 12;
            // 
            // tipoDocLabel
            // 
            tipoDocLabel.AutoSize = true;
            tipoDocLabel.Location = new Point(14, 250);
            tipoDocLabel.Name = "tipoDocLabel";
            tipoDocLabel.Size = new Size(70, 20);
            tipoDocLabel.TabIndex = 13;
            tipoDocLabel.Text = "Tipo Doc";
            // 
            // tipoDocTextBox
            // 
            tipoDocComboBox.Location = new Point(99, 246);
            tipoDocComboBox.Margin = new Padding(3, 4, 3, 4);
            tipoDocComboBox.Name = "tipoDocTextBox";
            tipoDocComboBox.Size = new Size(175, 27);
            tipoDocComboBox.TabIndex = 14;
            // 
            // nroDocLabel
            // 
            nroDocLabel.AutoSize = true;
            nroDocLabel.Location = new Point(336, 249);
            nroDocLabel.Name = "nroDocLabel";
            nroDocLabel.Size = new Size(65, 20);
            nroDocLabel.TabIndex = 15;
            nroDocLabel.Text = "Nro Doc";
            // 
            // nroDocTextBox
            // 
            nroDocTextBox.Location = new Point(414, 247);
            nroDocTextBox.Margin = new Padding(3, 4, 3, 4);
            nroDocTextBox.Name = "nroDocTextBox";
            nroDocTextBox.Size = new Size(175, 27);
            nroDocTextBox.TabIndex = 16;
            // 
            // fechaNacLabel
            // 
            fechaNacLabel.AutoSize = true;
            fechaNacLabel.Location = new Point(14, 321);
            fechaNacLabel.Name = "fechaNacLabel";
            fechaNacLabel.Size = new Size(128, 20);
            fechaNacLabel.TabIndex = 17;
            fechaNacLabel.Text = "Fecha Nacimiento";
            // 
            // fechaNacPicker
            // 
            fechaNacPicker.Format = DateTimePickerFormat.Short;
            fechaNacPicker.Location = new Point(154, 318);
            fechaNacPicker.Margin = new Padding(3, 4, 3, 4);
            fechaNacPicker.Name = "fechaNacPicker";
            fechaNacPicker.Size = new Size(130, 27);
            fechaNacPicker.TabIndex = 18;
            // 
            // tipoPersonaLabel
            // 
            tipoPersonaLabel.AutoSize = true;
            tipoPersonaLabel.Location = new Point(12, 391);
            tipoPersonaLabel.Name = "tipoPersonaLabel";
            tipoPersonaLabel.Size = new Size(94, 20);
            tipoPersonaLabel.TabIndex = 19;
            tipoPersonaLabel.Text = "Tipo Persona";
            // 
            // tipoPersonaTextBox
            // 
            tipoPersonaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoPersonaComboBox.FormattingEnabled = true;
            tipoPersonaComboBox.Location = new Point(133, 388);
            tipoPersonaComboBox.Margin = new Padding(3, 4, 3, 4);
            tipoPersonaComboBox.Name = "tipoPersonaComboBox";
            tipoPersonaComboBox.Size = new Size(151, 27);
            tipoPersonaComboBox.TabIndex = 20;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(45, 474);
            aceptarButton.Margin = new Padding(3, 4, 3, 4);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(150, 31);
            aceptarButton.TabIndex = 20;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(253, 474);
            cancelarButton.Margin = new Padding(3, 4, 3, 4);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(148, 31);
            cancelarButton.TabIndex = 21;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // PersonaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 608);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(direccionLabel);
            Controls.Add(direccionTextBox);
            Controls.Add(telefonoLabel);
            Controls.Add(telefonoTextBox);
            Controls.Add(legajoLabel);
            Controls.Add(legajoTextBox);
            Controls.Add(tipoDocLabel);
            Controls.Add(tipoDocComboBox);
            Controls.Add(nroDocLabel);
            Controls.Add(nroDocTextBox);
            Controls.Add(fechaNacLabel);
            Controls.Add(fechaNacPicker);
            Controls.Add(tipoPersonaLabel);
            Controls.Add(tipoPersonaComboBox);
            Controls.Add(aceptarButton);
            Controls.Add(cancelarButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PersonaDetalle";
            Text = "PersonaDetalle";
            Load += PersonaDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label nombreLabel;
        private Label apellidoLabel;
        private Label emailLabel;
        private Label direccionLabel;
        private Label telefonoLabel;
        private Label legajoLabel;
        private Label tipoDocLabel;
        private Label nroDocLabel;
        private Label fechaNacLabel;
        private Label tipoPersonaLabel;
        private TextBox nombreTextBox;
        private TextBox apellidoTextBox;
        private TextBox emailTextBox;
        private TextBox direccionTextBox;
        private TextBox telefonoTextBox;
        private TextBox legajoTextBox;
        private ComboBox tipoDocComboBox;
        private TextBox nroDocTextBox;
        private DateTimePicker fechaNacPicker;
        private ComboBox tipoPersonaComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}