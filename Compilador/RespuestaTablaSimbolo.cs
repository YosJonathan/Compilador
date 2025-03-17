// <copyright file="RespuestaTablaSimbolo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using global::Compilador.Modelos;
    using MaterialSkin.Controls;

    /// <summary>
    /// Respuesta de tabla de simbolo.
    /// </summary>
    public partial class RespuestaTablaSimbolo : MaterialForm
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RespuestaTablaSimbolo"/> class.
        /// </summary>
        /// <param name="respuesta">respuesta.</param>
        public RespuestaTablaSimbolo(Dictionary<string, Simbolo> respuesta)
        {
            this.InitializeComponent();
            MaterialUI.cargarMaterial(this);
            this.respuesta = respuesta;
            this.LlenarDataGridView();
        }

        private void LlenarDataGridView()
        {
            this.dataGridViewSimbolos.Rows.Clear();
            this.dataGridViewSimbolos.Columns.Clear();

            // Agregar columnas
            this.dataGridViewSimbolos.Columns.Add("Nombre", "Nombre");
            this.dataGridViewSimbolos.Columns.Add("Tipo", "Tipo");
            this.dataGridViewSimbolos.Columns.Add("Ámbito", "Ámbito");
            this.dataGridViewSimbolos.Columns.Add("ValorInicial", "Valor Inicial");

            // Agregar filas con los datos de la tabla de símbolos
            foreach (var simbolo in this.respuesta.Values)
            {
                this.dataGridViewSimbolos.Rows.Add(simbolo.Nombre, simbolo.Tipo, simbolo.Ambito, simbolo.ValorInicial);
            }
        }

        private readonly Dictionary<string, Simbolo> respuesta;
    }
}
