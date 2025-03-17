// <copyright file="Compilador.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using global::Compilador.FrontEnd;
    using global::Compilador.Modelos;
    using global::MaterialSkin.Controls;

    /// <summary>
    /// Clase de compilador.
    /// </summary>
    public partial class Compilador : MaterialForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Compilador"/> class.
        /// </summary>
        public Compilador()
        {
            this.InitializeComponent();
            MaterialUI.cargarMaterial(this);
        }

        private void Compilador_Load(object sender, EventArgs e)
        {
            this.txtCompilador.Text = string.Empty;
        }

        /// <summary>
        /// Abrir archivo txt opción del menu.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">e.</param>
        private void AbrirArchivotxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear y configurar el cuadro de diálogo
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar un archivo de texto",
            };

            // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Leer el contenido del archivo seleccionado
                string contenido = File.ReadAllText(openFileDialog.FileName);

                // Mostrar el contenido en el TextBox
                this.txtCompilador.Text = contenido;
            }
        }

        private void AnalizadorLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadenaaAnalizar = this.txtCompilador.Text;

            AnalizadorLexico analizadorLexico = new AnalizadorLexico();
            RespuestaAnalisisLexico respuesta = analizadorLexico.Analizar(cadenaaAnalizar);

            // Abre el nuevo formulario y le pasa los datos
            if (!analizadorLexico.TieneErrores())
            {
                RespuestaLexico formGraficos = new RespuestaLexico(respuesta);
                formGraficos.Show();
            }
            else
            {
                List<string> errores = analizadorLexico.ObtenerErrores();
                foreach (string error in errores)
                {
                    MessageBox.Show(error);
                }
            }
        }

        private async void TablaDeSimbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadenaaAnalizar = this.txtCompilador.Text;

            TablaSimbolos analizador = new TablaSimbolos();
            await analizador.AnalizarCodigoAsync(cadenaaAnalizar);

            if (analizador.TieneErrores())
            {
                List<string> errores = analizador.ObtenerErrores();
                foreach (string error in errores)
                {
                    MessageBox.Show(error);
                }

                return;
            }

            Dictionary<string, Simbolo> resultado = analizador.MostrarTabla();

            RespuestaTablaSimbolo formGraficos = new RespuestaTablaSimbolo(resultado);
            formGraficos.Show();
        }
    }
}
