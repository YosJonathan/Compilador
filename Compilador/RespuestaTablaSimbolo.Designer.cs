namespace Compilador
{
    partial class RespuestaTablaSimbolo
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
            dataGridViewSimbolos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSimbolos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSimbolos
            // 
            dataGridViewSimbolos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSimbolos.Location = new Point(0, 64);
            dataGridViewSimbolos.Name = "dataGridViewSimbolos";
            dataGridViewSimbolos.RowHeadersWidth = 51;
            dataGridViewSimbolos.Size = new Size(798, 386);
            dataGridViewSimbolos.TabIndex = 0;
            // 
            // RespuestaTablaSimbolo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewSimbolos);
            Name = "RespuestaTablaSimbolo";
            Text = "RespuestaTablaSimbolo";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSimbolos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSimbolos;
    }
}