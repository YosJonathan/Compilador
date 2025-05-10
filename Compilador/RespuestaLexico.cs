// <copyright file="RespuestaLexico.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using System.Data;
    using global::Compilador.Modelos;
    using MaterialSkin.Controls;

    /// <summary>
    /// Respuesta lexico form.
    /// </summary>
    public partial class RespuestaLexico : MaterialForm
    {
        private RespuestaAnalisisLexico respuesta;

        /// <summary>
        /// Initializes a new instance of the <see cref="RespuestaLexico"/> class.
        /// </summary>
        /// <param name="respuestaD">respuesta de analisis.</param>
        public RespuestaLexico(RespuestaAnalisisLexico respuestaD)
        {
            this.InitializeComponent();
            this.respuesta = respuestaD;
            MaterialUI.CargarMaterial(this);
            this.LlenarDataGridView();
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
            dt.Columns.Add("Libreria");

            // Obtener la cantidad máxima de elementos en todas las listas
            int maxFilas = new List<int>
            {
                this.respuesta.PalabrasReservadas.Count, this.respuesta.Identificadores.Count, this.respuesta.Numeros.Count,
                this.respuesta.Operadores.Count, this.respuesta.Simbolos.Count, this.respuesta.CadenasTexto.Count,
                this.respuesta.DirectivasPreprocesador.Count, this.respuesta.Librerias.Count,
            }.Max();

            // Llenar las filas con los datos, dejando vacío cuando no haya más elementos en una lista
            for (int i = 0; i < maxFilas; i++)
            {
                dt.Rows.Add(
                    i < this.respuesta.PalabrasReservadas.Count ? this.respuesta.PalabrasReservadas[i] : string.Empty,
                    i < this.respuesta.Identificadores.Count ? this.respuesta.Identificadores[i] : string.Empty,
                    i < this.respuesta.Numeros.Count ? this.respuesta.Numeros[i] : string.Empty,
                    i < this.respuesta.Operadores.Count ? this.respuesta.Operadores[i] : string.Empty,
                    i < this.respuesta.Simbolos.Count ? this.respuesta.Simbolos[i] : string.Empty,
                    i < this.respuesta.CadenasTexto.Count ? this.respuesta.CadenasTexto[i] : string.Empty,
                    i < this.respuesta.DirectivasPreprocesador.Count ? this.respuesta.DirectivasPreprocesador[i] : string.Empty,
                    i < this.respuesta.Librerias.Count ? this.respuesta.Librerias[i] : string.Empty);
            }

            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar columnas al tamaño
        }

        private void RespuestaLexico_Load(object sender, EventArgs e)
        {
        }
    }
}
