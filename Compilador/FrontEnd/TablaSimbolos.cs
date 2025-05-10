// <copyright file="TablaSimbolos.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.FrontEnd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Tabla de simbolos.
    /// </summary>
    public class TablaSimbolos
    {
        /// <summary>
        /// Simbolos.
        /// </summary>
        private readonly Dictionary<string, Simbolo> simbolos = new Dictionary<string, Simbolo>();

        /// <summary>
        /// Agregar.
        /// </summary>
        /// <param name="name">nombre.</param>
        /// <param name="symbol">simbolo.</param>
        /// <exception cref="Exception">Excepción.</exception>
        public void Agregar(string name, Simbolo symbol)
#pragma warning restore IDE0079 // Quitar supresión innecesaria
        {
            if (this.simbolos.ContainsKey(name))
            {
                throw new Exception($"Error: la variable '{name}' ya fue declarada.");
            }

            this.simbolos[name] = symbol;
        }

        /// <summary>
        /// Obtener nombre.
        /// </summary>
        /// <param name="name">nombre.</param>
        /// <returns>Simbolo.</returns>
        /// <exception cref="Exception">Excepción.</exception>
        public Simbolo Obtener(string name)
        {
            if (!this.simbolos.TryGetValue(name, out Simbolo? value))
            {
                throw new Exception($"Error: la variable '{name}' no está declarada.");
            }

            return value;
        }
    }
}
