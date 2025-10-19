namespace WindowsForm
{
    partial class PersonaLista
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
            personasDataGridView = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)personasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(24, 19);
            buscarTextBox.Margin = new Padding(3, 4, 3, 4);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por nombre...";
            buscarTextBox.Size = new Size(204, 27);
            buscarTextBox.TabIndex = 0;
            buscarTextBox.TextChanged += buscarTextBox_TextChanged;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(235, 17);
            buscarButton.Margin = new Padding(3, 4, 3, 4);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(86, 31);
            buscarButton.TabIndex = 1;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // personasDataGridView
            // 
            personasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personasDataGridView.Location = new Point(24, 57);
            personasDataGridView.Margin = new Padding(3, 4, 3, 4);
            personasDataGridView.Name = "personasDataGridView";
            personasDataGridView.RowHeadersWidth = 51;
            personasDataGridView.Size = new Size(1377, 409);
            personasDataGridView.TabIndex = 2;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(962, 505);
            eliminarButton.Margin = new Padding(3, 4, 3, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(86, 31);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(1122, 505);
            modificarButton.Margin = new Padding(3, 4, 3, 4);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(86, 31);
            modificarButton.TabIndex = 4;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(1274, 505);
            agregarButton.Margin = new Padding(3, 4, 3, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(86, 31);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // PersonaLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1426, 569);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(personasDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PersonaLista";
            Text = "PersonaLista";
            Load += PersonaLista_Load;
            ((System.ComponentModel.ISupportInitialize)personasDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscarTextBox;
        private Button buscarButton;
        private DataGridView personasDataGridView;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
    }
}