// <copyright file="Compilador.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using System.Windows.Forms;
    using global::Compilador.FrontEnd;
    using global::Compilador.Modelos;
    using global::MaterialSkin.Controls;
    using Irony.Parsing;

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

            // Leer el contenido del archivo seleccionado
            string contenido = File.ReadAllText("C:\\Users\\YOS\\Documents\\sdfsdfsdf.txt");

            // Mostrar el contenido en el TextBox
            this.txtCompilador.Text = contenido;
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
                    this.lstErrores.Items.Add(error);
                }

                MessageBox.Show($"❌ Error en el código.");
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

        /// <summary>
        /// Acción de boton de analizador sintactico.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void AnalizadorSintacticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lstErrores.Items.Clear();

            string input = this.txtCompilador.Text;

            // Dividir el código en líneas para obtener la línea exacta con error
            string[] lineas = input.Split('\n');

            // Crear el parser con la gramática
            var grammar = new Gramatica();
            var parser = new Parser(grammar);
            var tree = parser.Parse(input);

            // Verificar si el código es válido
            if (tree.Root != null)
            {
                RespuestaSintactico formGraficos = new RespuestaSintactico(tree.Root);
                formGraficos.Show();
            }
            else
            {
                foreach (var err in tree.ParserMessages)
                {
                    string lineaError = (err.Location.Line > 0 && err.Location.Line <= lineas.Length)
                        ? lineas[err.Location.Line - 1] // Obtener la línea exacta del error
                        : "No disponible";

                    this.lstErrores.Items.Add($"Error: {err.Message} " +
                        $"Línea {err.Location.Line}, Columna {err.Location.Column}. " +
                        $"Estado: {err.ParserState.Name}. " +
                        $"Código: {lineaError.Trim()}"); // Mostrar la línea de código con error
                }

                MessageBox.Show($"❌ Error en el código.");
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando el usuario hace doble clic en un ítem de la lista de errores.
        /// Si hay un ítem seleccionado, copia su texto al portapapeles.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void LstErrores_DoubleClick(object sender, EventArgs e)
        {
            // Verifica que haya un ítem seleccionado
            if (this.lstErrores.SelectedItem != null)
            {
                // Copia el texto del ítem seleccionado al portapapeles
#pragma warning disable CS8604 // Posible argumento de referencia nulo
                Clipboard.SetText(this.lstErrores.SelectedItem.ToString());
#pragma warning restore CS8604 // Posible argumento de referencia nulo
            }
        }
    }
}
