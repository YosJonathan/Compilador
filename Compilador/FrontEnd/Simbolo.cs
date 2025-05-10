// <copyright file="Simbolo.cs" company="PlaceholderCompany">
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
    /// Simbolo.
    /// </summary>
    public class Simbolo
    {
        /// <summary>
        /// Gets or sets nombre.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets tipo.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets valor.
        /// </summary>
        public object? Value { get; set; }
    }
}
