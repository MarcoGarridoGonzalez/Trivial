namespace WindowsFormsApp1
{
    partial class Tablero
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
            this.playersGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Rojo = new System.Windows.Forms.Label();
            this.Azul = new System.Windows.Forms.Label();
            this.Verde = new System.Windows.Forms.Label();
            this.Dado6 = new System.Windows.Forms.PictureBox();
            this.Dado5 = new System.Windows.Forms.PictureBox();
            this.Dado4 = new System.Windows.Forms.PictureBox();
            this.Dado3 = new System.Windows.Forms.PictureBox();
            this.Dado2 = new System.Windows.Forms.PictureBox();
            this.Amarillo = new System.Windows.Forms.Label();
            this.Dado1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Abandonar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playersGridView
            // 
            this.playersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersGridView.Location = new System.Drawing.Point(50, 58);
            this.playersGridView.Margin = new System.Windows.Forms.Padding(4);
            this.playersGridView.MaximumSize = new System.Drawing.Size(468, 288);
            this.playersGridView.MinimumSize = new System.Drawing.Size(468, 288);
            this.playersGridView.Name = "playersGridView";
            this.playersGridView.RowHeadersWidth = 62;
            this.playersGridView.RowTemplate.Height = 28;
            this.playersGridView.Size = new System.Drawing.Size(468, 288);
            this.playersGridView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 449);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.MaximumSize = new System.Drawing.Size(186, 46);
            this.button1.MinimumSize = new System.Drawing.Size(186, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lanzar Dados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Rojo
            // 
            this.Rojo.Location = new System.Drawing.Point(370, 50);
            this.Rojo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Rojo.Name = "Rojo";
            this.Rojo.Size = new System.Drawing.Size(70, 25);
            this.Rojo.TabIndex = 3;
            this.Rojo.Text = "label1";
            this.Rojo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Azul
            // 
            this.Azul.AutoSize = true;
            this.Azul.Location = new System.Drawing.Point(377, 968);
            this.Azul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Azul.Name = "Azul";
            this.Azul.Size = new System.Drawing.Size(70, 25);
            this.Azul.TabIndex = 4;
            this.Azul.Text = "label2";
            // 
            // Verde
            // 
            this.Verde.AutoSize = true;
            this.Verde.Location = new System.Drawing.Point(473, 854);
            this.Verde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Verde.Name = "Verde";
            this.Verde.Size = new System.Drawing.Size(70, 25);
            this.Verde.TabIndex = 5;
            this.Verde.Text = "label3";
            // 
            // Dado6
            // 
            this.Dado6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dado6.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Dado6;
            this.Dado6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dado6.Location = new System.Drawing.Point(199, 538);
            this.Dado6.Name = "Dado6";
            this.Dado6.Size = new System.Drawing.Size(109, 100);
            this.Dado6.TabIndex = 12;
            this.Dado6.TabStop = false;
            // 
            // Dado5
            // 
            this.Dado5.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Dado5;
            this.Dado5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dado5.Location = new System.Drawing.Point(199, 538);
            this.Dado5.Name = "Dado5";
            this.Dado5.Size = new System.Drawing.Size(100, 100);
            this.Dado5.TabIndex = 11;
            this.Dado5.TabStop = false;
            // 
            // Dado4
            // 
            this.Dado4.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Dado4;
            this.Dado4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dado4.Location = new System.Drawing.Point(199, 538);
            this.Dado4.Name = "Dado4";
            this.Dado4.Size = new System.Drawing.Size(100, 100);
            this.Dado4.TabIndex = 10;
            this.Dado4.TabStop = false;
            // 
            // Dado3
            // 
            this.Dado3.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Dado3;
            this.Dado3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dado3.Location = new System.Drawing.Point(199, 538);
            this.Dado3.Name = "Dado3";
            this.Dado3.Size = new System.Drawing.Size(100, 100);
            this.Dado3.TabIndex = 9;
            this.Dado3.TabStop = false;
            // 
            // Dado2
            // 
            this.Dado2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Dado2;
            this.Dado2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dado2.Location = new System.Drawing.Point(199, 538);
            this.Dado2.Name = "Dado2";
            this.Dado2.Size = new System.Drawing.Size(100, 100);
            this.Dado2.TabIndex = 8;
            this.Dado2.TabStop = false;
            // 
            // Amarillo
            // 
            this.Amarillo.AutoSize = true;
            this.Amarillo.Location = new System.Drawing.Point(377, 779);
            this.Amarillo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Amarillo.Name = "Amarillo";
            this.Amarillo.Size = new System.Drawing.Size(70, 25);
            this.Amarillo.TabIndex = 6;
            this.Amarillo.Text = "label4";
            // 
            // Dado1
            // 
            this.Dado1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Dado1;
            this.Dado1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dado1.Location = new System.Drawing.Point(199, 538);
            this.Dado1.Margin = new System.Windows.Forms.Padding(4);
            this.Dado1.Name = "Dado1";
            this.Dado1.Size = new System.Drawing.Size(100, 100);
            this.Dado1.TabIndex = 2;
            this.Dado1.TabStop = false;
            this.Dado1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Tablero3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Rojo);
            this.panel1.Location = new System.Drawing.Point(668, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 1000);
            this.panel1.TabIndex = 13;
            // 
            // Abandonar
            // 
            this.Abandonar.Location = new System.Drawing.Point(1423, 13);
            this.Abandonar.Name = "Abandonar";
            this.Abandonar.Size = new System.Drawing.Size(245, 39);
            this.Abandonar.TabIndex = 14;
            this.Abandonar.Text = "Abandonar Partida";
            this.Abandonar.UseVisualStyleBackColor = true;
            this.Abandonar.Click += new System.EventHandler(this.Abandonar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // Tablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1721, 1122);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Abandonar);
            this.Controls.Add(this.Amarillo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Verde);
            this.Controls.Add(this.Azul);
            this.Controls.Add(this.Dado6);
            this.Controls.Add(this.Dado5);
            this.Controls.Add(this.Dado4);
            this.Controls.Add(this.Dado3);
            this.Controls.Add(this.Dado2);
            this.Controls.Add(this.Dado1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playersGridView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tablero";
            this.Text = "Tablero";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tablero_FormClosing);
            this.Load += new System.EventHandler(this.Tablero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dado1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playersGridView;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox Dado1;
        private System.Windows.Forms.Label Rojo;
        private System.Windows.Forms.Label Azul;
        private System.Windows.Forms.Label Verde;
        private System.Windows.Forms.Label Amarillo;
        private System.Windows.Forms.PictureBox Dado2;
        private System.Windows.Forms.PictureBox Dado3;
        private System.Windows.Forms.PictureBox Dado4;
        private System.Windows.Forms.PictureBox Dado5;
        private System.Windows.Forms.PictureBox Dado6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Abandonar;
        private System.Windows.Forms.Label label1;
    }
}