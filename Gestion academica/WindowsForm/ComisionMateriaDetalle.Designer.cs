namespace WindowsForm
{
    partial class ComisionMateriaDetalle
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
            labelMateria = new Label();
            comboBoxMateria = new ComboBox();
            labelHsSemanales = new Label();
            textBoxHsSemanales = new TextBox();
            labelHsTotales = new Label();
            textBoxHsTotales = new TextBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(14, 52);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(60, 20);
            labelMateria.TabIndex = 1;
            labelMateria.Text = "Materia";
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateria.FormattingEnabled = true;
            comboBoxMateria.Location = new Point(152, 49);
            comboBoxMateria.Margin = new Padding(3, 4, 3, 4);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(205, 28);
            comboBoxMateria.TabIndex = 2;
            comboBoxMateria.SelectedIndexChanged += comboBoxMateria_SelectedIndexChanged;
            // 
            // labelHsSemanales
            // 
            labelHsSemanales.AutoSize = true;
            labelHsSemanales.Location = new Point(14, 93);
            labelHsSemanales.Name = "labelHsSemanales";
            labelHsSemanales.Size = new Size(101, 20);
            labelHsSemanales.TabIndex = 3;
            labelHsSemanales.Text = "Hs Semanales";
            // 
            // textBoxHsSemanales
            // 
            textBoxHsSemanales.Location = new Point(152, 93);
            textBoxHsSemanales.Margin = new Padding(3, 4, 3, 4);
            textBoxHsSemanales.Name = "textBoxHsSemanales";
            textBoxHsSemanales.Size = new Size(205, 27);
            textBoxHsSemanales.TabIndex = 4;
            // 
            // labelHsTotales
            // 
            labelHsTotales.AutoSize = true;
            labelHsTotales.Location = new Point(14, 133);
            labelHsTotales.Name = "labelHsTotales";
            labelHsTotales.Size = new Size(77, 20);
            labelHsTotales.TabIndex = 5;
            labelHsTotales.Text = "Hs Totales";
            // 
            // textBoxHsTotales
            // 
            textBoxHsTotales.Location = new Point(152, 133);
            textBoxHsTotales.Margin = new Padding(3, 4, 3, 4);
            textBoxHsTotales.Name = "textBoxHsTotales";
            textBoxHsTotales.Size = new Size(205, 27);
            textBoxHsTotales.TabIndex = 6;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(152, 192);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 29);
            aceptarButton.TabIndex = 7;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(263, 192);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(94, 29);
            cancelarButton.TabIndex = 8;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ComisionMateriaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 244);
            Controls.Add(textBoxHsTotales);
            Controls.Add(labelHsTotales);
            Controls.Add(textBoxHsSemanales);
            Controls.Add(labelHsSemanales);
            Controls.Add(comboBoxMateria);
            Controls.Add(labelMateria);
            Controls.Add(aceptarButton);
            Controls.Add(cancelarButton);
            Name = "ComisionMateriaDetalle";
            Text = "ComisionMateriaDetalle";
            Load += ComisionMateriaDetalle_Load;
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
        private Label labelMateria;
        private ComboBox comboBoxMateria;
        private Label labelHsSemanales;
        private TextBox textBoxHsSemanales;
        private Label labelHsTotales;
        private TextBox textBoxHsTotales;
        private Button aceptarButton;
        private Button cancelarButton;
    }
}