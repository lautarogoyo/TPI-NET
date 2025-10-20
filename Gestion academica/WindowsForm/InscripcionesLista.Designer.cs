namespace WindowsForm
{
    partial class InscripcionesLista
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
            dgvInscriptos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInscriptos).BeginInit();
            SuspendLayout();
            // 
            // dgvInscriptos
            // 
            dgvInscriptos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscriptos.Location = new Point(12, 12);
            dgvInscriptos.Name = "dgvInscriptos";
            dgvInscriptos.RowHeadersWidth = 51;
            dgvInscriptos.Size = new Size(776, 426);
            dgvInscriptos.TabIndex = 0;
            //dgvInscriptos.CellContentClick += dgvInscriptos_CellContentClick;
            // 
            // InscripcionesLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvInscriptos);
            Name = "InscripcionesLista";
            Text = "InscripcionesLista";
            Load += InscripcionesLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInscriptos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvInscriptos;
    }
}