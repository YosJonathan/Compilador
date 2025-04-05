// <copyright file="AnalizadorLexico.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.FrontEnd
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Modelos;

    /// <summary>
    /// Clase para almacenar la logica del analizador lexico.
    /// </summary>
    public class AnalizadorLexico
    {
        // Definir las palabras reservadas de C++
        private static readonly HashSet<string> PalabrasReservadas = new HashSet<string>
        {
            "int", "float", "double", "char", "void", "if", "else", "for", "while",
            "return", "switch", "case", "break", "continue", "default", "class",
            "public", "private", "protected", "new", "delete", "try", "catch", "throw",
            "namespace", "using", "bool", "true", "false", "struct", "union", "enum",
            "template", "typename", "virtual", "const", "static", "sizeof", "do", "goto",
        };

        private ManejadorErrores manejadorErrores = new ManejadorErrores();

        // Expresiones regulares para identificar los diferentes tokens
        private static readonly Regex RegexIdentificador = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");
        private static readonly Regex RegexNumero = new Regex(@"^\d+(\.\d+)?$");
        private static readonly Regex RegexOperador = new Regex(@"^[+\-*/%=<>!&|^~]+$");
        private static readonly Regex RegexSimbolo = new Regex(@"^[{}()\[\],;.]$");
        private static readonly Regex RegexCadenaTexto = new Regex("\"([^\"]*)\""); // Para cadenas de texto entre comillas dobles
        private static readonly Regex RegexDirectivaPreprocesador = new Regex(@"^#\w+$");
        private static readonly Regex RegexContenidoEntreMenores = new Regex(@"[\w.-]+\.h");

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalizadorLexico"/> class.
        /// </summary>
        public AnalizadorLexico()
        {
            this.manejadorErrores = new ManejadorErrores();
        }

        /// <summary>
        /// Función encargada de analizar el codigo c++ y separarlo por tokens.
        /// </summary>
        /// <param name="codigoFuente">Código fuenta.</param>
        /// <returns>Listado de tokens.</returns>
        public RespuestaAnalisisLexico Analizar(string codigoFuente)
        {
            RespuestaAnalisisLexico resultado = new RespuestaAnalisisLexico();
            string[] lineas = codigoFuente.Split('\n');

            for (int numLinea = 0; numLinea < lineas.Length; numLinea++)
            {
                string linea = lineas[numLinea];
                foreach (Match match in RegexCadenaTexto.Matches(linea))
                {
                    resultado.CadenasTexto.Add(match.Value);
                    linea = linea.Replace(match.Value, string.Empty);
                }

                string[] tokens = Regex.Split(linea, @"([\s+\-*/%=<>&|^~{}\[\](),;])")
                    .Where(t => !string.IsNullOrEmpty(t) && !char.IsWhiteSpace(t[0]))
                    .ToArray();

                for (int i = 0; i < tokens.Length; i++)
                {
                    string token = tokens[i];
                    if (PalabrasReservadas.Contains(token))
                    {
                        resultado.PalabrasReservadas.Add(token);
                    }
                    else if (RegexIdentificador.IsMatch(token))
                    {
                        resultado.Identificadores.Add(token);
                    }
                    else if (RegexNumero.IsMatch(token))
                    {
                        resultado.Numeros.Add(token);
                    }
                    else if (RegexOperador.IsMatch(token))
                    {
                        resultado.Operadores.Add(token);
                    }
                    else if (RegexSimbolo.IsMatch(token))
                    {
                        resultado.Simbolos.Add(token);
                    }
                    else if (RegexDirectivaPreprocesador.IsMatch(token))
                    {
                        resultado.DirectivasPreprocesador.Add(token);
                    }
                    else if (RegexContenidoEntreMenores.IsMatch(token))
                    {
                        resultado.Librerias.Add(token);
                    }
                    else
                    {
                        this.manejadorErrores.AgregarError(numLinea + 1, i + 1, $"Token inválido: '{token}'");
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Función para calcular si la función tiene Errores.
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
