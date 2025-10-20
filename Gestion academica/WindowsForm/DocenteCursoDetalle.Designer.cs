namespace WindowsForm
{
    partial class DocenteCursoDetalle
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxDocente = new ComboBox();
            comboBoxCurso = new ComboBox();
            comboBoxCargo = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 161);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Curso:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 94);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Cargo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 221);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 2;
            label3.Text = "Docente:";
            // 
            // comboBoxDocente
            // 
            comboBoxDocente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDocente.FormattingEnabled = true;
            comboBoxDocente.Location = new Point(190, 221);
            comboBoxDocente.Name = "comboBoxDocente";
            comboBoxDocente.Size = new Size(151, 28);
            comboBoxDocente.TabIndex = 3;
            // 
            // comboBoxCurso
            // 
            comboBoxCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCurso.FormattingEnabled = true;
            comboBoxCurso.Location = new Point(190, 161);
            comboBoxCurso.Name = "comboBoxCurso";
            comboBoxCurso.Size = new Size(247, 28);
            comboBoxCurso.TabIndex = 4;
            // 
            // comboBoxCargo
            // 
            comboBoxCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCargo.FormattingEnabled = true;
            comboBoxCargo.Location = new Point(190, 94);
            comboBoxCargo.Name = "comboBoxCargo";
            comboBoxCargo.Size = new Size(151, 28);
            comboBoxCargo.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(362, 310);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(480, 310);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // DocenteCursoDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 364);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(comboBoxCargo);
            Controls.Add(comboBoxCurso);
            Controls.Add(comboBoxDocente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DocenteCursoDetalle";
            Text = "DocenteCursoDetalle";
            Load += DocenteCursoDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxDocente;
        private ComboBox comboBoxCurso;
        private ComboBox comboBoxCargo;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}