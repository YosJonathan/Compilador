// <copyright file="AnalisisSemantico.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.FrontEnd
{
    using global::Compilador.Modelos;
    using Irony.Parsing;
    using System.Xml.Linq;

    /// <summary>
    /// Analizador semantico.
    /// </summary>
    public class AnalisisSemantico
    {
        /// <summary>
        /// manejador de errores.
        /// </summary>
        private readonly ManejadorErrores manejadorErrores = new();

        /// <summary>
        /// tabla de simbolos.
        /// </summary>
        private readonly TablaSimbolos tablaSimbolos = new();

        /// <summary>
        /// Analizar nodo.
        /// </summary>
        /// <param name="node">Nodo.</param>
        /// <exception cref="Exception">Excepción.</exception>
        public void AnalizarNodo(ParseTreeNode node)
        {
            switch (node.Term.Name)
            {
                case "Declaracion":
                    var tipo = node.ChildNodes[0].Token.Text;
                    var nombre = node.ChildNodes[1].Token.Text;
                    if (node.ChildNodes.Count == 3)
                    {
                        var valorDeclaracion = node.ChildNodes[2];
                        var tipoValorDeclaracion = this.EvaluarTipo(valorDeclaracion);

                        if (tipo != tipoValorDeclaracion)
                        {
                            this.manejadorErrores.AgregarError(0, 0, $"tipo incompatible en asignación a '{nombre}'");
                        }
                    }

                    if (this.tablaSimbolos.ExisteId(nombre))
                    {
                        this.manejadorErrores.AgregarError(0, 0, $"'{nombre}' ya fue declarada.");
                    }


                    this.tablaSimbolos.Agregar(nombre, new Simbolo { Name = nombre, Type = tipo });
                    break;

                case "Asignacion":
                    var id = node.ChildNodes[0].Token.Text;
                    var valor = node.ChildNodes[2];
                    var simbolo = this.tablaSimbolos.Obtener(id);
                    var tipoValor = this.EvaluarTipo(valor);
                    if (!simbolo.Item2)
                    {
                        this.manejadorErrores.AgregarError(0, 0, $"la variable '{id}' no está declarada.");
                        break;
                    }

                    if (simbolo.Item1.Type != tipoValor)
                    {
                        this.manejadorErrores.AgregarError(0, 0, $"tipo incompatible en asignación a '{id}'");
                    }

                    break;

                    // Repetí con más tipos de nodos
            }

            // Recorremos los hijos
            foreach (var child in node.ChildNodes)
            {
                this.AnalizarNodo(child);
            }
        }

        /// <summary>
        /// Evaluar el tipo de dato.
        /// </summary>
        /// <param name="node">Nodo.</param>
        /// <returns>Cadena de respuesta.</returns>
        /// <exception cref="Exception">Excepción.</exception>
        private string EvaluarTipo(ParseTreeNode node)
        {
            switch (node.Term.Name)
            {
                case "numeroEntero":
                    return "int";
                case "string":
                    return "string";
                case "identificador":

                    var simbolo = this.tablaSimbolos.Obtener(name: node.Token.Text);

                    if (!simbolo.Item2)
                    {
                        this.manejadorErrores.AgregarError(0, 0, $"la variable '{node.Token.Text}' no está declarada.");
                        return string.Empty;
                    }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
                    return simbolo.Item1.Type;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
                case "+":
                case "-":
                    var tipoIzq = this.EvaluarTipo(node.ChildNodes[0]);
                    var tipoDer = this.EvaluarTipo(node.ChildNodes[2]);
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
