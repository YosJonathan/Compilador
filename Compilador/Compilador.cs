using Compilador.Modelos;
using MaterialSkin.Controls;

namespace Compilador
{
    public partial class Compilador : MaterialForm
    {
        public Compilador()
        {
            InitializeComponent();
            MaterialUI.cargarMaterial(this);
        }

        private void Compilador_Load(object sender, EventArgs e)
        {
            txtCompilador.Text = string.Empty;
        }

        private void abrirArchivotxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear y configurar el cuadro de diálogo
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar un archivo de texto"
            };

            // Mostrar el cuadro de diálogo y verificar si el usuario seleccionó un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Leer el contenido del archivo seleccionado
                string contenido = File.ReadAllText(openFileDialog.FileName);

                // Mostrar el contenido en el TextBox
                txtCompilador.Text = contenido;
            }
        }

        private void analizadorLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadenaaAnalizar = txtCompilador.Text;

            RespuestaAnalisisLexico respuesta = new AnalizadorLexico().Analizar(cadenaaAnalizar);

            // Abre el nuevo formulario y le pasa los datos
            RespuestaLexico formGraficos = new RespuestaLexico(respuesta);
            formGraficos.Show();
        }
    }
}
