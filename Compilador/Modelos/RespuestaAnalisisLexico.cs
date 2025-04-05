// <copyright file="RespuestaAnalisisLexico.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.Modelos
{
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Representa el resultado de un análisis léxico de un código fuente,
    /// donde se clasifican las diferentes entidades encontradas en listas específicas.
    /// </summary>
    public class RespuestaAnalisisLexico
    {
        /// <summary>
        /// Gets or sets obtiene o establece la lista de palabras reservadas encontradas en el código fuente.
        /// </summary>
        public List<string> PalabrasReservadas { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de identificadores (nombres de variables, funciones, etc.) encontrados en el código fuente.
        /// </summary>
        public List<string> Identificadores { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de números encontrados en el código fuente.
        /// </summary>
        public List<string> Numeros { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de operadores encontrados en el código fuente.
        /// </summary>
        public List<string> Operadores { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de símbolos (como paréntesis, llaves, etc.) encontrados en el código fuente.
        /// </summary>
        public List<string> Simbolos { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de cadenas de texto encontradas en el código fuente.
        /// </summary>
        public List<string> CadenasTexto { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de directivas de preprocesador (como #define, #include, etc.) encontradas en el código fuente.
        /// </summary>
        public List<string> DirectivasPreprocesador { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets obtiene o establece la lista de directivas de preprocesador (como #define, #include, etc.) encontradas en el código fuente.
        /// </summary>
        public List<string> Librerias { get; set; } = new List<string>();

        /// <summary>
        /// Convierte la instancia actual de la clase en una cadena JSON.
        /// </summary>
        /// <returns>Una representación en formato JSON del objeto actual.</returns>
        public string ConvertirAJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
