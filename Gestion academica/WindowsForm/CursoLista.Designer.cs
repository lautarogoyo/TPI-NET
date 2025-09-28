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
            buscarTextBox.Margin = new Padding(3, 2, 3, 2);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.Size = new Size(243, 23);
            buscarTextBox.TabIndex = 0;
            buscarTextBox.Text = "Buscar por nombre...";
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(284, -2);
            buscarButton.Margin = new Padding(3, 2, 3, 2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(100, 22);
            buscarButton.TabIndex = 1;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            // 
            // cursosDataGridView
            // 
            cursosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cursosDataGridView.Location = new Point(10, 46);
            cursosDataGridView.Margin = new Padding(3, 2, 3, 2);
            cursosDataGridView.Name = "cursosDataGridView";
            cursosDataGridView.RowHeadersWidth = 51;
            cursosDataGridView.Size = new Size(640, 209);
            cursosDataGridView.TabIndex = 2;
            cursosDataGridView.CellContentClick += cursosDataGridView_CellContentClick;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(417, 299);
            eliminarButton.Margin = new Padding(3, 2, 3, 2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(82, 22);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(505, 299);
            modificarButton.Margin = new Padding(3, 2, 3, 2);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(82, 22);
            modificarButton.TabIndex = 4;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(592, 299);
            agregarButton.Margin = new Padding(3, 2, 3, 2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(82, 22);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // CursoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(cursosDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Margin = new Padding(3, 2, 3, 2);
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