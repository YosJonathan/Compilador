// <copyright file="RespuestaSintactico.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using System.Text;
    using global::Compilador.Modelos;
    using Irony.Parsing;
    using MaterialSkin.Controls;

    /// <summary>
    /// Respuesta sintactico.
    /// </summary>
    public partial class RespuestaSintactico : MaterialForm
    {
        private ParseTreeNode respuesta;

        /// <summary>
        /// Initializes a new instance of the <see cref="RespuestaSintactico"/> class.
        /// </summary>
        /// <param name="nodo">nodo.</param>
        public RespuestaSintactico(ParseTreeNode nodo)
        {
            this.respuesta = nodo;
            this.InitializeComponent();
            MaterialUI.CargarMaterial(this);
        }

        /// <summary>
        /// Recorrer arbol.
        /// </summary>
        /// <param name="nodo">Nodo.</param>
        /// <param name="nivel">Nivel.</param>
        /// <returns>Texto.</returns>
        public string RecorrerArbol(ParseTreeNode nodo, int nivel = 0)
        {
            // Crear una cadena con la indentación según el nivel
            StringBuilder resultado = new StringBuilder();
            string indentacion = new string(' ', nivel * 2);

            indentacion += nivel > 0 ? "-" : string.Empty;

            // Mostrar el tipo del nodo, por ejemplo, 'programa' o el valor del terminal
            resultado.AppendLine(indentacion + nodo.Term.Name);

            // Si el nodo tiene hijos (nodos internos), recorrerlos
            if (nodo.ChildNodes != null && nodo.ChildNodes.Count > 0)
            {
                foreach (var hijo in nodo.ChildNodes)
                {
                    // Llamada recursiva para recorrer los hijos
                    resultado.Append(this.RecorrerArbol(hijo, nivel + 1));
                }
            }

            return resultado.ToString();
        }

        private void RespuestaSintactico_Load(object sender, EventArgs e)
        {
            this.txtCompilador.Text = this.RecorrerArbol(this.respuesta);
        }
    }
}
