// <copyright file="AnalisisSemantico.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.FrontEnd
{
    using Irony.Parsing;

    /// <summary>
    /// Analizador semantico.
    /// </summary>
    public class AnalisisSemantico
    {
        /// <summary>
        /// manejador de errores.
        /// </summary>
        private readonly ManejadorErrores manejadorErrores = new ();

        /// <summary>
        /// Analizar nodo.
        /// </summary>
        /// <param name="node">Nodo.</param>
        /// <param name="tabla">Tabla.</param>
        /// <exception cref="Exception">Excepción.</exception>
        public void AnalizarNodo(ParseTreeNode node, TablaSimbolos tabla)
        {
            switch (node.Term.Name)
            {
                case "Declaracion":
                    var tipo = node.ChildNodes[0].Token.Text;
                    var nombre = node.ChildNodes[1].Token.Text;
                    tabla.Agregar(nombre, new Simbolo { Name = nombre, Type = tipo });
                    break;

                case "Asignacion":
                    var id = node.ChildNodes[0].Token.Text;
                    var valor = node.ChildNodes[2];
                    var simbolo = tabla.Obtener(id);
                    var tipoValor = this.EvaluarTipo(valor, tabla);
                    if (simbolo.Type != tipoValor)
                    {
                        this.manejadorErrores.AgregarError(0, 0, $"Error: tipo incompatible en asignación a '{id}'");
                    }

                    break;

                    // Repetí con más tipos de nodos
            }

            // Recorremos los hijos
            foreach (var child in node.ChildNodes)
            {
                this.AnalizarNodo(child, tabla);
            }
        }

        /// <summary>
        /// Evaluar el tipo de dato.
        /// </summary>
        /// <param name="node">Nodo.</param>
        /// <param name="tabla">Tabla.</param>
        /// <returns>Cadena de respuesta.</returns>
        /// <exception cref="Exception">Excepción.</exception>
        private string EvaluarTipo(ParseTreeNode node, TablaSimbolos tabla)
        {
            switch (node.Term.Name)
            {
                case "int":
                    return "int";
                case "string":
                    return "string";
                case "identificador":
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                    return tabla.Obtener(name: node.Token.Text).Type;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
                case "+":
                case "-":
                    var tipoIzq = this.EvaluarTipo(node.ChildNodes[0], tabla);
                    var tipoDer = this.EvaluarTipo(node.ChildNodes[2], tabla);
                    if (tipoIzq != tipoDer)
                    {
                        this.manejadorErrores.AgregarError(0, 0, "Error: suma entre tipos distintos");
                    }

                    return tipoIzq;
            }

            return "desconocido";
        }

        /// <summary>
        /// Gets a value indicating whether función para calcular si la función tiene Errores.
        /// </summary>
        /// <returns>Tiene errores.</returns>
        public bool TieneErrores()
        {
            return this.manejadorErrores.TieneErrores();
        }

        /// <summary>
        /// Función para obtener errores del listado.
        /// </summary>
        /// <returns>Listado de errores.</returns>
        public List<string> ObtenerErrores()
        {
           return this.manejadorErrores.ObtenerErrores();
        }
    }
}
