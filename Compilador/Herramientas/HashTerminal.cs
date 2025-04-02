// <copyright file="HashTerminal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.Herramientas
{
    using Irony.Parsing;

    /// <summary>
    /// Clase personalizada para el hash #.
    /// </summary>
    public class HashTerminal : Terminal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HashTerminal"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        public HashTerminal(string name)
            : base(name, TokenCategory.Content)
        {
        }
    }
}
