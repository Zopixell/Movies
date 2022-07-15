namespace Server
{
    partial class ServerForma
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPronadji = new System.Windows.Forms.Button();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.checkNaziv = new System.Windows.Forms.CheckBox();
            this.checkDatum = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pretraga filma:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum projekcije (dd.MM.yyyy HH:mm):";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(700, 268);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnPronadji
            // 
            this.btnPronadji.Location = new System.Drawing.Point(531, 121);
            this.btnPronadji.Name = "btnPronadji";
            this.btnPronadji.Size = new System.Drawing.Size(143, 23);
            this.btnPronadji.TabIndex = 3;
            this.btnPronadji.Text = "Pronadji";
            this.btnPronadji.UseVisualStyleBackColor = true;
            this.btnPronadji.Click += new System.EventHandler(this.btnPronadji_Click);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(300, 28);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(374, 22);
            this.txtPretraga.TabIndex = 4;
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(300, 76);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(374, 22);
            this.txtDatum.TabIndex = 5;
            // 
            // checkNaziv
            // 
            this.checkNaziv.AutoSize = true;
            this.checkNaziv.Location = new System.Drawing.Point(13, 35);
            this.checkNaziv.Name = "checkNaziv";
            this.checkNaziv.Size = new System.Drawing.Size(18, 17);
            this.checkNaziv.TabIndex = 6;
            this.checkNaziv.UseVisualStyleBackColor = true;
            // 
            // checkDatum
            // 
            this.checkDatum.AutoSize = true;
            this.checkDatum.Location = new System.Drawing.Point(13, 82);
            this.checkDatum.Name = "checkDatum";
            this.checkDatum.Size = new System.Drawing.Size(18, 17);
            this.checkDatum.TabIndex = 7;
            this.checkDatum.UseVisualStyleBackColor = true;
            // 
            // ServerForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkDatum);
            this.Controls.Add(this.checkNaziv);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.btnPronadji);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ServerForma";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForma_FormClosed);
            this.Load += new System.EventHandler(this.ServerForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPronadji;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.CheckBox checkNaziv;
        private System.Windows.Forms.CheckBox checkDatum;
    }
}

