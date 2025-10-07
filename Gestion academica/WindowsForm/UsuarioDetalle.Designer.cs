namespace WindowsForm
{
    partial class UsuarioDetalle
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
            IdLabel = new Label();
            NombreUsuarioLabel = new Label();
            ClaveLabel = new Label();
            HabilitadoLabel = new Label();
            IdPersonaLabel = new Label();
            IdTextBox = new TextBox();
            ClaveTextBox = new TextBox();
            NombreUsuarioTextBox = new TextBox();
            HabilitadoTextBox = new TextBox();
            PersonaComboBox = new ComboBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(54, 45);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(81, 20);
            IdLabel.TabIndex = 0;
            IdLabel.Text = "ID Usuario:";
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(54, 100);
            NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            NombreUsuarioLabel.Size = new Size(121, 20);
            NombreUsuarioLabel.TabIndex = 1;
            NombreUsuarioLabel.Text = "Nombre Usuario:";
            // 
            // ClaveLabel
            // 
            ClaveLabel.AutoSize = true;
            ClaveLabel.Location = new Point(54, 157);
            ClaveLabel.Name = "ClaveLabel";
            ClaveLabel.Size = new Size(48, 20);
            ClaveLabel.TabIndex = 2;
            ClaveLabel.Text = "Clave:";
            // 
            // HabilitadoLabel
            // 
            HabilitadoLabel.AutoSize = true;
            HabilitadoLabel.Location = new Point(54, 212);
            HabilitadoLabel.Name = "HabilitadoLabel";
            HabilitadoLabel.Size = new Size(83, 20);
            HabilitadoLabel.TabIndex = 3;
            HabilitadoLabel.Text = "Habilitado:";
            // 
            // IdPersonaLabel
            // 
            IdPersonaLabel.AutoSize = true;
            IdPersonaLabel.Location = new Point(54, 272);
            IdPersonaLabel.Name = "IdPersonaLabel";
            IdPersonaLabel.Size = new Size(76, 20);
            IdPersonaLabel.TabIndex = 4;
            IdPersonaLabel.Text = "IdPersona:";
            // 
            // IdTextBox
            // 
            IdTextBox.Location = new Point(322, 45);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.Size = new Size(125, 27);
            IdTextBox.TabIndex = 5;
            // 
            // ClaveTextBox
            // 
            ClaveTextBox.Location = new Point(322, 150);
            ClaveTextBox.Name = "ClaveTextBox";
            ClaveTextBox.Size = new Size(125, 27);
            ClaveTextBox.TabIndex = 6;
            // 
            // NombreUsuarioTextBox
            // 
            NombreUsuarioTextBox.Location = new Point(322, 97);
            NombreUsuarioTextBox.Name = "NombreUsuarioTextBox";
            NombreUsuarioTextBox.Size = new Size(125, 27);
            NombreUsuarioTextBox.TabIndex = 7;
            // 
            // HabilitadoTextBox
            // 
            HabilitadoTextBox.Location = new Point(322, 205);
            HabilitadoTextBox.Name = "HabilitadoTextBox";
            HabilitadoTextBox.Size = new Size(125, 27);
            HabilitadoTextBox.TabIndex = 8;
            // 
            // PersonaComboBox
            // 
            PersonaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PersonaComboBox.FormattingEnabled = true;
            PersonaComboBox.Location = new Point(322, 269);
            PersonaComboBox.Name = "PersonaComboBox";
            PersonaComboBox.Size = new Size(125, 28);
            PersonaComboBox.TabIndex = 9;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(499, 373);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 10;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(627, 373);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(PersonaComboBox);
            Controls.Add(HabilitadoTextBox);
            Controls.Add(NombreUsuarioTextBox);
            Controls.Add(ClaveTextBox);
            Controls.Add(IdTextBox);
            Controls.Add(IdPersonaLabel);
            Controls.Add(HabilitadoLabel);
            Controls.Add(ClaveLabel);
            Controls.Add(NombreUsuarioLabel);
            Controls.Add(IdLabel);
            Name = "UsuarioDetalle";
            Text = "UsuarioDetalle";
            Load += UsuarioDetalle_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdLabel;
        private Label NombreUsuarioLabel;
        private Label ClaveLabel;
        private Label HabilitadoLabel;
        private Label IdPersonaLabel;
        private TextBox IdTextBox;
        private TextBox ClaveTextBox;
        private TextBox NombreUsuarioTextBox;
        private TextBox HabilitadoTextBox;
        private ComboBox PersonaComboBox;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}