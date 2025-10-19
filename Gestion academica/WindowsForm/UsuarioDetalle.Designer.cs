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
            NombreUsuarioLabel = new Label();
            NombreUsuarioTextBox = new TextBox();
            ClaveLabel = new Label();
            ClaveTextBox = new TextBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(54, 64);
            NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            NombreUsuarioLabel.Size = new Size(121, 20);
            NombreUsuarioLabel.TabIndex = 1;
            NombreUsuarioLabel.Text = "Nombre Usuario:";
            // 
            // NombreUsuarioTextBox
            // 
            NombreUsuarioTextBox.Location = new Point(224, 57);
            NombreUsuarioTextBox.Name = "NombreUsuarioTextBox";
            NombreUsuarioTextBox.Size = new Size(125, 27);
            NombreUsuarioTextBox.TabIndex = 2;
            // 
            // ClaveLabel
            // 
            ClaveLabel.AutoSize = true;
            ClaveLabel.Location = new Point(54, 125);
            ClaveLabel.Name = "ClaveLabel";
            ClaveLabel.Size = new Size(48, 20);
            ClaveLabel.TabIndex = 3;
            ClaveLabel.Text = "Clave:";
            // 
            // ClaveTextBox
            // 
            ClaveTextBox.Location = new Point(224, 125);
            ClaveTextBox.Name = "ClaveTextBox";
            ClaveTextBox.Size = new Size(125, 27);
            ClaveTextBox.TabIndex = 4;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(81, 206);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 10;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(224, 206);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 287);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(NombreUsuarioTextBox);
            Controls.Add(ClaveTextBox);
            Controls.Add(ClaveLabel);
            Controls.Add(NombreUsuarioLabel);
            Name = "UsuarioDetalle";
            Text = "UsuarioDetalle";
            Load += UsuarioDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NombreUsuarioLabel;
        private Label ClaveLabel;
        private TextBox ClaveTextBox;
        private TextBox NombreUsuarioTextBox;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}