// <copyright file="Simbolo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.Modelos
{
    /// <summary>
    /// Modelo de simbolo.
    /// </summary>
    public class Simbolo
    {
        /// <summary>
        /// Gets or sets nombre del simbolo.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets tipo de simbolo.
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Gets or sets ambito de simbolo.
        /// </summary>
        public string Ambito { get; set; }

        /// <summary>
        /// Gets or sets valor inicial.
        /// </summary>
        public string ValorInicial { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Simbolo"/> class.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        /// <param name="tipo">Tipo.</param>
        /// <param name="ambito">Ambito.</param>
        /// <param name="valorInicial">Valor Inicial.</param>
        public Simbolo(string nombre, string tipo, string ambito, string valorInicial)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Ambito = ambito;
            this.ValorInicial = valorInicial;
        }

        /// <summary>
        /// metodo para mostrar información en string.
        /// </summary>
        /// <returns>Información del simbolo.</returns>
        public override string ToString()
        {
            return $"Nombre: {this.Nombre}, Tipo: {this.Tipo}, Ámbito: {this.Ambito}, Valor Inicial: {this.ValorInicial}";
        }
    }
}
