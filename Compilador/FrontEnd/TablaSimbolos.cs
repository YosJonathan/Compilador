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
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1600 // Elements should be documented
        public Dictionary<string, Simbolo> Simbolos = new ();
#pragma warning disable IDE0079 // Quitar supresión innecesaria
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Agregar.
        /// </summary>
        /// <param name="name">nombre.</param>
        /// <param name="symbol">simbolo.</param>
        /// <exception cref="Exception">Excepción.</exception>
        public void Agregar(string name, Simbolo symbol)
#pragma warning restore IDE0079 // Quitar supresión innecesaria
        {
            if (this.Simbolos.ContainsKey(name))
            {
                throw new Exception($"Error: la variable '{name}' ya fue declarada.");
            }

            this.Simbolos[name] = symbol;
        }

        /// <summary>
        /// Obtener nombre.
        /// </summary>
        /// <param name="name">nombre.</param>
        /// <returns>Simbolo.</returns>
        /// <exception cref="Exception">Excepción.</exception>
        public Simbolo Obtener(string name)
        {
            if (!this.Simbolos.TryGetValue(name, out Simbolo? value))
            {
                throw new Exception($"Error: la variable '{name}' no está declarada.");
            }

            return value;
        }
    }
}
