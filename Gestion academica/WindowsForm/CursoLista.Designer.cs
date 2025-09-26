namespace WindowsForm
{
    partial class CursoLista
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
            buscarTextBox = new TextBox();
            buscarButton = new Button();
            cursosDataGridView = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cursosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(0, 0);
            buscarTextBox.Margin = new Padding(4, 4, 4, 4);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.Size = new Size(345, 31);
            buscarTextBox.TabIndex = 0;
            buscarTextBox.Text = "Buscar por nombre...";
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(406, -2);
            buscarButton.Margin = new Padding(4, 4, 4, 4);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(142, 36);
            buscarButton.TabIndex = 1;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            // 
            // cursosDataGridView
            // 
            cursosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cursosDataGridView.Location = new Point(15, 76);
            cursosDataGridView.Margin = new Padding(4, 4, 4, 4);
            cursosDataGridView.Name = "cursosDataGridView";
            cursosDataGridView.RowHeadersWidth = 51;
            cursosDataGridView.Size = new Size(915, 349);
            cursosDataGridView.TabIndex = 2;
            cursosDataGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(596, 499);
            eliminarButton.Margin = new Padding(4, 4, 4, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(118, 36);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(721, 499);
            modificarButton.Margin = new Padding(4, 4, 4, 4);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(118, 36);
            modificarButton.TabIndex = 4;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += button2_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(846, 499);
            agregarButton.Margin = new Padding(4, 4, 4, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(118, 36);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // CursoLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(cursosDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Margin = new Padding(4, 4, 4, 4);
            Name = "CursoLista";
            Text = "CursoLista";
            Load += CursoLista_Load;
            ((System.ComponentModel.ISupportInitialize)cursosDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscarTextBox;
        private Button buscarButton;
        private DataGridView cursosDataGridView;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
    }
}