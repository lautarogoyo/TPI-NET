namespace WindowsForm
{
    partial class UsuarioLista
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
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            usuariosDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)usuariosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(0, 0);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.Size = new Size(297, 27);
            buscarTextBox.TabIndex = 0;
            buscarTextBox.Text = "Buscar por nombre...";
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(383, 0);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(94, 29);
            buscarButton.TabIndex = 1;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(416, 377);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 2;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(537, 377);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(94, 29);
            modificarButton.TabIndex = 3;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(654, 377);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(94, 29);
            agregarButton.TabIndex = 4;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            // 
            // usuariosDataGridView
            // 
            usuariosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usuariosDataGridView.Location = new Point(12, 71);
            usuariosDataGridView.Name = "usuariosDataGridView";
            usuariosDataGridView.RowHeadersWidth = 51;
            usuariosDataGridView.Size = new Size(673, 277);
            usuariosDataGridView.TabIndex = 5;
            usuariosDataGridView.CellContentClick += usuariosDataGridView_CellContentClick_1;
            // 
            // UsuarioLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(usuariosDataGridView);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Name = "UsuarioLista";
            Text = "UsuarioLista";
            ((System.ComponentModel.ISupportInitialize)usuariosDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscarTextBox;
        private Button buscarButton;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private DataGridView usuariosDataGridView;
    }
}