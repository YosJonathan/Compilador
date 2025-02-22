// <copyright file="ManejadorErrores.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase para manejar los errores léxicos detectados durante el análisis.
    /// </summary>
    public class ManejadorErrores
    {
        /// <summary>
        /// Gets lista de errores detectados durante el análisis léxico.
        /// </summary>
        public List<string> Errores { get; private set; } = new List<string>();

        /// <summary>
        /// Agrega un nuevo error léxico a la lista.
        /// </summary>
        /// <param name="linea">Número de línea donde ocurrió el error.</param>
        /// <param name="columna">Número de columna donde ocurrió el error.</param>
        /// <param name="mensaje">Descripción del error.</param>
        public void AgregarError(int linea, int columna, string mensaje)
        {
            this.Errores.Add($"Línea {linea}, Columna {columna}: {mensaje}");
        }

        /// <summary>
        /// Devuelve todos los errores registrados.
        /// </summary>
        /// <returns>Lista de errores en formato de texto.</returns>
        public List<string> ObtenerErrores()
        {
            return this.Errores;
        }

        /// <summary>
        /// Indica si hay errores registrados.
        /// </summary>
        /// <returns>True si hay errores, false de lo contrario.</returns>
        public bool TieneErrores()
        {
            return this.Errores.Count > 0;
        }
    }
}
