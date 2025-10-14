namespace WindowsForm
{
    partial class ComisionDetalle
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
            label2 = new Label();
            textBox1 = new TextBox();
            labelAnio = new Label();
            textBoxAnio = new TextBox();
            label3 = new Label();
            comboBoxPlan = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 52);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 1;
            label2.Text = "Descripción";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 45);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 27);
            textBox1.TabIndex = 2;
            // 
            // labelAnio
            // 
            labelAnio.AutoSize = true;
            labelAnio.Location = new Point(14, 93);
            labelAnio.Name = "labelAnio";
            labelAnio.Size = new Size(145, 20);
            labelAnio.TabIndex = 3;
            labelAnio.Text = "Año de especialidad";
            // 
            // textBoxAnio
            // 
            textBoxAnio.Location = new Point(188, 90);
            textBoxAnio.Margin = new Padding(3, 4, 3, 4);
            textBoxAnio.Name = "textBoxAnio";
            textBoxAnio.Size = new Size(185, 27);
            textBoxAnio.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 133);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 5;
            label3.Text = "Plan";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(188, 130);
            comboBoxPlan.Margin = new Padding(3, 4, 3, 4);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(185, 28);
            comboBoxPlan.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(188, 183);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 7;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += aceptarButton;
            // 
            // button2
            // 
            button2.Location = new Point(270, 183);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(103, 31);
            button2.TabIndex = 8;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += cancelarButton;
            // 
            // ComisionDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 240);
            Controls.Add(comboBoxPlan);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(labelAnio);
            Controls.Add(textBoxAnio);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ComisionDetalle";
            Text = "ComisionDetalle";
            Load += ComisionDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private ComboBox comboBoxPlan;
        private Label label2;
        private Label label3;
        private Label labelAnio;
        private TextBox textBoxAnio;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
    }
}