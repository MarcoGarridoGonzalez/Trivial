namespace WindowsFormsApp1
{
    partial class Preguntas
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
            this.label2 = new System.Windows.Forms.Label();
            this.Preguntalabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Uno = new System.Windows.Forms.RadioButton();
            this.Dos = new System.Windows.Forms.RadioButton();
            this.Tres = new System.Windows.Forms.RadioButton();
            this.Cuatro = new System.Windows.Forms.RadioButton();
            this.Enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione la respuesta correcta:";
            // 
            // Preguntalabel
            // 
            this.Preguntalabel.AutoSize = true;
            this.Preguntalabel.BackColor = System.Drawing.SystemColors.Control;
            this.Preguntalabel.ForeColor = System.Drawing.Color.Black;
            this.Preguntalabel.Location = new System.Drawing.Point(63, 118);
            this.Preguntalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Preguntalabel.Name = "Preguntalabel";
            this.Preguntalabel.Size = new System.Drawing.Size(128, 25);
            this.Preguntalabel.TabIndex = 2;
            this.Preguntalabel.Text = "PREGUNTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(389, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tema";
            // 
            // Uno
            // 
            this.Uno.AutoSize = true;
            this.Uno.Location = new System.Drawing.Point(38, 229);
            this.Uno.Name = "Uno";
            this.Uno.Size = new System.Drawing.Size(165, 29);
            this.Uno.TabIndex = 7;
            this.Uno.TabStop = true;
            this.Uno.Text = "radioButton1";
            this.Uno.UseVisualStyleBackColor = true;
            // 
            // Dos
            // 
            this.Dos.AutoSize = true;
            this.Dos.Location = new System.Drawing.Point(38, 289);
            this.Dos.Name = "Dos";
            this.Dos.Size = new System.Drawing.Size(165, 29);
            this.Dos.TabIndex = 8;
            this.Dos.TabStop = true;
            this.Dos.Text = "radioButton2";
            this.Dos.UseVisualStyleBackColor = true;
            // 
            // Tres
            // 
            this.Tres.AutoSize = true;
            this.Tres.Location = new System.Drawing.Point(38, 353);
            this.Tres.Name = "Tres";
            this.Tres.Size = new System.Drawing.Size(165, 29);
            this.Tres.TabIndex = 9;
            this.Tres.TabStop = true;
            this.Tres.Text = "radioButton3";
            this.Tres.UseVisualStyleBackColor = true;
            // 
            // Cuatro
            // 
            this.Cuatro.AutoSize = true;
            this.Cuatro.Location = new System.Drawing.Point(38, 412);
            this.Cuatro.Name = "Cuatro";
            this.Cuatro.Size = new System.Drawing.Size(165, 29);
            this.Cuatro.TabIndex = 10;
            this.Cuatro.TabStop = true;
            this.Cuatro.Text = "radioButton4";
            this.Cuatro.UseVisualStyleBackColor = true;
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(444, 289);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(185, 104);
            this.Enviar.TabIndex = 11;
            this.Enviar.Text = "Enviar Respuesta";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // Preguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.Cuatro);
            this.Controls.Add(this.Tres);
            this.Controls.Add(this.Dos);
            this.Controls.Add(this.Uno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Preguntalabel);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Preguntas";
            this.Text = "Preguntas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preguntas_FormClosing);
            this.Load += new System.EventHandler(this.Preguntas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Preguntalabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Uno;
        private System.Windows.Forms.RadioButton Dos;
        private System.Windows.Forms.RadioButton Tres;
        private System.Windows.Forms.RadioButton Cuatro;
        private System.Windows.Forms.Button Enviar;
    }
}