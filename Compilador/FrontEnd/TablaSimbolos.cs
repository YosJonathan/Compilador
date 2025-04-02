// <copyright file="TablaSimbolos.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.FrontEnd
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Modelos;

    /// <summary>
    /// Generando tabla de simbolos.
    /// </summary>
    public class TablaSimbolos
    {
        private Dictionary<string, Simbolo> tablaSimbolos = new Dictionary<string, Simbolo>();
        private ManejadorErrores manejadorErrores = new ManejadorErrores();

        /// <summary>
        /// Analizar codigo asincrono.
        /// </summary>
        /// <param name="codigo">Codigo a analizar.</param>
        /// <returns>Respuesta del codigo.</returns>
        public async Task AnalizarCodigoAsync(string codigo)
        {
            await Task.Run(() =>
            {
                this.tablaSimbolos.Clear();
                this.manejadorErrores = new ManejadorErrores(); // Reiniciar errores
                string[] lineas = codigo.Split('\n');
                string ambitoActual = "global";
                Stack<bool> bloquesAbiertos = new Stack<bool>(); // Para manejar el estado de apertura y cierre de bloques

                for (int i = 0; i < lineas.Length; i++)
                {
                    string lineaTrim = lineas[i].Trim();

                    // Expresión regular para detectar comentarios de una sola línea (//) y de múltiples líneas (/* */)
                    string patronComentarios = @"(//.*?$)|(/\*.*?\*/)";

                    // Reemplazar los comentarios con una cadena vacía
                    lineaTrim = Regex.Replace(lineaTrim, patronComentarios, string.Empty, RegexOptions.Singleline);

                    if (string.IsNullOrEmpty(lineaTrim))
                    {
                        // si esta vacia ignorar
                        continue;
                    }

                    // Dentro del loop que analiza las líneas de código
                    if (lineaTrim.StartsWith("using namespace std;"))
                    {
                        // Ignorar esta línea, ya que solo es una directiva de espacio de nombres
                        continue;
                    }

                    // Dentro del loop que analiza las líneas de código
                    if (lineaTrim.StartsWith("return"))
                    {
                        // Ignorar la instrucción return
                        continue;
                    }

                    // Detectar funciones (declaraciones)
                    Match matchFuncion = Regex.Match(lineaTrim, @"\b(\w+)\s+(\w+)\s*\((.*?)\)\s*{");
                    if (matchFuncion.Success)
                    {
                        string tipo = matchFuncion.Groups[1].Value;
                        string nombre = matchFuncion.Groups[2].Value;

                        if (this.tablaSimbolos.ContainsKey(nombre))
                        {
                            this.manejadorErrores.AgregarError(i + 1, 0, $"La función '{nombre}' ya fue declarada anteriormente.");
                        }
                        else
                        {
                            this.tablaSimbolos[nombre] = new Simbolo(nombre, tipo, "global", "N/A");
                            ambitoActual = nombre;
                        }

                        bloquesAbiertos.Push(true); // Inicia un bloque de función
                        continue;
                    }

                    // Detectar declaraciones de variables dentro de las funciones
                    Match matchVariable = Regex.Match(lineaTrim, @"\b(\w+)\s+(\w+)\s*(=\s*.*)");
                    if (matchVariable.Success)
                    {
                        string tipoVariable = matchVariable.Groups[1].Value;
                        string nombreVariable = matchVariable.Groups[2].Value;
                        string valorInicial = matchVariable.Groups[3].Value.Replace("=", string.Empty).Trim();

                        // Agregar la variable a la tabla de símbolos si no está ya registrada
                        if (!this.tablaSimbolos.ContainsKey(nombreVariable))
                        {
                            this.tablaSimbolos[nombreVariable] = new Simbolo(nombreVariable, tipoVariable, ambitoActual, valorInicial);
                        }
                        else
                        {
                            this.manejadorErrores.AgregarError(i + 1, 0, $"La variable '{nombreVariable}' ya fue declarada anteriormente.");
                        }

                        continue;
                    }

                    // Validación de llaves de apertura y cierre
                    if (lineaTrim.Contains("{"))
                    {
                        bloquesAbiertos.Push(true); // Inicia un nuevo bloque
                    }

                    if (lineaTrim.Contains("}"))
                    {
                        if (bloquesAbiertos.Count > 0)
                        {
                            bloquesAbiertos.Pop(); // Cierra un bloque
                        }
                        else
                        {
                            // Error: Llave de cierre '}' sin apertura correspondiente
                            this.manejadorErrores.AgregarError(i + 1, lineaTrim.Length, "Error: Llave de cierre '}' sin apertura correspondiente.");
                        }
                    }
                }

                // Al final, si hay llaves abiertas sin cerrar, reportar error
                if (bloquesAbiertos.Count > 0)
                {
                    this.manejadorErrores.AgregarError(lineas.Length + 1, 0, "Error: Falta cerrar algunas llaves '}'.");
                }
            });
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

        /// <summary>
        /// Mostrar o retornar la tabla de simbolos.
        /// </summary>
        /// <returns>tabla de simbolos.</returns>
        public Dictionary<string, Simbolo> MostrarTabla()
        {
            return this.tablaSimbolos;
        }
    }
}
