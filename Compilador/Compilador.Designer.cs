namespace Compilador
{
    partial class Compilador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compilador));
            txtCompilador = new FastColoredTextBoxNS.FastColoredTextBox();
            materialMenuStrip1 = new MaterialSkin.Controls.MaterialMenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrirArchivotxtToolStripMenuItem = new ToolStripMenuItem();
            analizadorToolStripMenuItem = new ToolStripMenuItem();
            realizarAnalisisToolStripMenuItem = new ToolStripMenuItem();
            lstErrores = new ListBox();
            ((System.ComponentModel.ISupportInitialize)txtCompilador).BeginInit();
            materialMenuStrip1.SuspendLayout();
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
            txtCompilador.Font = new Font("Courier New", 9.75F);
            txtCompilador.IsReplaceMode = false;
            txtCompilador.Location = new Point(0, 66);
            txtCompilador.Name = "txtCompilador";
            txtCompilador.Paddings = new Padding(0);
            txtCompilador.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            txtCompilador.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("txtCompilador.ServiceColors");
            txtCompilador.Size = new Size(800, 351);
            txtCompilador.TabIndex = 0;
            txtCompilador.Zoom = 100;
            // 
            // materialMenuStrip1
            // 
            materialMenuStrip1.BackColor = Color.FromArgb(55, 71, 79);
            materialMenuStrip1.Depth = 0;
            materialMenuStrip1.Dock = DockStyle.Bottom;
            materialMenuStrip1.Font = new Font("Roboto", 10F);
            materialMenuStrip1.ImageScalingSize = new Size(20, 20);
            materialMenuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            materialMenuStrip1.Location = new Point(0, 541);
            materialMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            materialMenuStrip1.Name = "materialMenuStrip1";
            materialMenuStrip1.RenderMode = ToolStripRenderMode.System;
            materialMenuStrip1.Size = new Size(804, 30);
            materialMenuStrip1.TabIndex = 1;
            materialMenuStrip1.Text = "materialMenuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, analizadorToolStripMenuItem });
            menuToolStripMenuItem.ForeColor = Color.White;
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(66, 26);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirArchivotxtToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(224, 26);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirArchivotxtToolStripMenuItem
            // 
            abrirArchivotxtToolStripMenuItem.Name = "abrirArchivotxtToolStripMenuItem";
            abrirArchivotxtToolStripMenuItem.Size = new Size(218, 26);
            abrirArchivotxtToolStripMenuItem.Text = "Abrir archivo .txt";
            abrirArchivotxtToolStripMenuItem.Click += AbrirArchivotxtToolStripMenuItem_Click;
            // 
            // analizadorToolStripMenuItem
            // 
            analizadorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { realizarAnalisisToolStripMenuItem });
            analizadorToolStripMenuItem.Name = "analizadorToolStripMenuItem";
            analizadorToolStripMenuItem.Size = new Size(224, 26);
            analizadorToolStripMenuItem.Text = "Analizador";
            // 
            // realizarAnalisisToolStripMenuItem
            // 
            realizarAnalisisToolStripMenuItem.Name = "realizarAnalisisToolStripMenuItem";
            realizarAnalisisToolStripMenuItem.Size = new Size(224, 26);
            realizarAnalisisToolStripMenuItem.Text = "Realizar Analisis";
            realizarAnalisisToolStripMenuItem.Click += RealizarAnalisisToolStripMenuItem_Click;
            // 
            // lstErrores
            // 
            lstErrores.FormattingEnabled = true;
            lstErrores.Location = new Point(-1, 417);
            lstErrores.Name = "lstErrores";
            lstErrores.Size = new Size(805, 124);
            lstErrores.TabIndex = 2;
            lstErrores.DoubleClick += LstErrores_DoubleClick;
            // 
            // Compilador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 571);
            Controls.Add(lstErrores);
            Controls.Add(txtCompilador);
            Controls.Add(materialMenuStrip1);
            MainMenuStrip = materialMenuStrip1;
            Name = "Compilador";
            Text = "Compilador";
            Load += Compilador_Load;
            ((System.ComponentModel.ISupportInitialize)txtCompilador).EndInit();
            materialMenuStrip1.ResumeLayout(false);
            materialMenuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txtCompilador;
        private MaterialSkin.Controls.MaterialMenuStrip materialMenuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem abrirArchivotxtToolStripMenuItem;
        private ToolStripMenuItem analizadorToolStripMenuItem;
        private ListBox lstErrores;
        private ToolStripMenuItem realizarAnalisisToolStripMenuItem;
    }
}
