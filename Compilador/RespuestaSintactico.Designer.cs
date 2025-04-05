namespace Compilador
{
    partial class RespuestaSintactico
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RespuestaSintactico));
            txtCompilador = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)txtCompilador).BeginInit();
            SuspendLayout();
            // 
            // txtCompilador
            // 
            txtCompilador.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            txtCompilador.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            txtCompilador.AutoScrollMinSize = new Size(31, 18);
            txtCompilador.BackBrush = null;
            txtCompilador.CharHeight = 18;
            txtCompilador.CharWidth = 10;
            txtCompilador.DefaultMarkerSize = 8;
            txtCompilador.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            txtCompilador.IsReplaceMode = false;
            txtCompilador.Location = new Point(0, 50);
            txtCompilador.Name = "txtCompilador";
            txtCompilador.Paddings = new Padding(0);
            txtCompilador.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            txtCompilador.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("txtCompilador.ServiceColors");
            txtCompilador.Size = new Size(800, 394);
            txtCompilador.TabIndex = 1;
            txtCompilador.Zoom = 100;
            // 
            // RespuestaSintactico
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCompilador);
            Name = "RespuestaSintactico";
            Text = "RespuestaSintactico";
            Load += RespuestaSintactico_Load;
            ((System.ComponentModel.ISupportInitialize)txtCompilador).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txtCompilador;
    }
}