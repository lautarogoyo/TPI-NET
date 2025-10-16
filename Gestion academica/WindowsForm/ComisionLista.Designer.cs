namespace WindowsForm
{
    partial class ComisionLista
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
            comisionesDataGridView = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            verMateriasButton = new Button();
            ((System.ComponentModel.ISupportInitialize)comisionesDataGridView).BeginInit();
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
            // comisionesDataGridView
            // 
            comisionesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            comisionesDataGridView.Location = new Point(24, 57);
            comisionesDataGridView.Margin = new Padding(3, 4, 3, 4);
            comisionesDataGridView.Name = "comisionesDataGridView";
            comisionesDataGridView.RowHeadersWidth = 51;
            comisionesDataGridView.Size = new Size(677, 245);
            comisionesDataGridView.TabIndex = 2;
            comisionesDataGridView.CellContentClick += comisionesDataGridView_CellContentClick;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(354, 349);
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
            modificarButton.Location = new Point(458, 349);
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
            agregarButton.Location = new Point(564, 349);
            agregarButton.Margin = new Padding(3, 4, 3, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(137, 31);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Nueva Comision";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // verMateriasButton
            // 
            verMateriasButton.Location = new Point(24, 347);
            verMateriasButton.Margin = new Padding(3, 4, 3, 4);
            verMateriasButton.Name = "verMateriasButton";
            verMateriasButton.Size = new Size(132, 31);
            verMateriasButton.TabIndex = 3;
            verMateriasButton.Text = "Ver Materias";
            verMateriasButton.UseVisualStyleBackColor = true;
            verMateriasButton.Click += verMateriasButton_Click;
            // 
            // ComisionLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 393);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(comisionesDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Controls.Add(verMateriasButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ComisionLista";
            Text = "comisionLista";
            Load += ComisionLista_Load;
            ((System.ComponentModel.ISupportInitialize)comisionesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscarTextBox;
        private Button buscarButton;
        private DataGridView comisionesDataGridView;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button verMateriasButton;
    }
}