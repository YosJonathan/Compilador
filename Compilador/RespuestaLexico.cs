using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compilador.Modelos;

namespace Compilador
{
    public partial class RespuestaLexico : MaterialForm
    {
        RespuestaAnalisisLexico respuesta;

        public RespuestaLexico(RespuestaAnalisisLexico respuestaD)
        {
            InitializeComponent();
            this.respuesta = respuestaD;
            MaterialUI.cargarMaterial(this);
            LlenarDataGridView();
        }



        private void LlenarDataGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Palabras Reservadas");
            dt.Columns.Add("Identificadores");
            dt.Columns.Add("Números");
            dt.Columns.Add("Operadores");
            dt.Columns.Add("Símbolos");
            dt.Columns.Add("Cadenas de Texto");
            dt.Columns.Add("Directivas Preprocesador");

            // Obtener la cantidad máxima de elementos en todas las listas
            int maxFilas = new List<int> {
                respuesta.PalabrasReservadas.Count, respuesta.Identificadores.Count, respuesta.Numeros.Count,
                respuesta.Operadores.Count, respuesta.Simbolos.Count, respuesta.CadenasTexto.Count,
                respuesta.DirectivasPreprocesador.Count,
            }.Max();

            // Llenar las filas con los datos, dejando vacío cuando no haya más elementos en una lista
            for (int i = 0; i < maxFilas; i++)
            {
                dt.Rows.Add(
                    i < respuesta.PalabrasReservadas.Count ? respuesta.PalabrasReservadas[i] : "",
                    i < respuesta.Identificadores.Count ? respuesta.Identificadores[i] : "",
                    i < respuesta.Numeros.Count ? respuesta.Numeros[i] : "",
                    i < respuesta.Operadores.Count ? respuesta.Operadores[i] : "",
                    i < respuesta.Simbolos.Count ? respuesta.Simbolos[i] : "",
                    i < respuesta.CadenasTexto.Count ? respuesta.CadenasTexto[i] : "",
                    i < respuesta.DirectivasPreprocesador.Count ? respuesta.DirectivasPreprocesador[i] : ""
                );
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar columnas al tamaño
        }

        private void RespuestaLexico_Load(object sender, EventArgs e)
        {

        }
    }
}
