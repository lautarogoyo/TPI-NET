namespace WindowsForm
{
    partial class PersonasSinUsuario
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
            // agregarButton
            // 
            agregarButton.Location = new Point(1219, 502);
            agregarButton.Margin = new Padding(3, 4, 3, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(142, 38);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Crear Usuario";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // PersonasSinUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1426, 569);
            Controls.Add(agregarButton);
            Controls.Add(personasDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PersonasSinUsuario";
            Text = "Personas sin usuario";
            Load += PersonasSinUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)personasDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscarTextBox;
        private Button buscarButton;
        private DataGridView personasDataGridView;
        private Button agregarButton;
    }
}