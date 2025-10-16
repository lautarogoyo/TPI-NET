namespace WindowsForm
{
    partial class ComisionMateriaLista
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
            cmDataGridView = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cmDataGridView).BeginInit();
            SuspendLayout();
            // 
            // cmDataGridView
            // 
            cmDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cmDataGridView.Location = new Point(26, 13);
            cmDataGridView.Margin = new Padding(3, 4, 3, 4);
            cmDataGridView.Name = "cmDataGridView";
            cmDataGridView.RowHeadersWidth = 51;
            cmDataGridView.Size = new Size(570, 203);
            cmDataGridView.TabIndex = 2;
            cmDataGridView.CellContentClick += cmDataGridView_CellContentClick;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(181, 240);
            eliminarButton.Margin = new Padding(3, 4, 3, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(126, 31);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Quitar Materia";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(313, 240);
            modificarButton.Margin = new Padding(3, 4, 3, 4);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(137, 31);
            modificarButton.TabIndex = 4;
            modificarButton.Text = "Modificar horas";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(465, 240);
            agregarButton.Margin = new Padding(3, 4, 3, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(131, 31);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar Materia";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // ComisionVerMaterias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 314);
            Controls.Add(agregarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(cmDataGridView);
            Name = "ComisionVerMaterias";
            Text = "ComisionVerMaterias";
            Load += ComisionVerMaterias_Load;
            ((System.ComponentModel.ISupportInitialize)cmDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView cmDataGridView;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
    }
}