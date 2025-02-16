using Compilador.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compilador
{
    public class AnalizadorLexico
    {
        // Definir las palabras reservadas de C++
        private static readonly HashSet<string> PalabrasReservadas = new HashSet<string>
        {
            "int", "float", "double", "char", "void", "if", "else", "for", "while",
            "return", "switch", "case", "break", "continue", "default", "class",
            "public", "private", "protected", "new", "delete", "try", "catch", "throw",
            "namespace", "using", "bool", "true", "false", "struct", "union", "enum",
            "template", "typename", "virtual", "const", "static", "sizeof", "do", "goto"
        };

        // Expresiones regulares para identificar los diferentes tokens
        private static readonly Regex RegexIdentificador = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");
        private static readonly Regex RegexNumero = new Regex(@"^\d+(\.\d+)?$");
        private static readonly Regex RegexOperador = new Regex(@"^[+\-*/%=<>!&|^~]+$");
        private static readonly Regex RegexSimbolo = new Regex(@"^[{}()\[\],;.]$");
        private static readonly Regex RegexCadenaTexto = new Regex("\"([^\"]*)\""); // Para cadenas de texto entre comillas dobles

        public RespuestaAnalisisLexico Analizar(string codigoFuente)
        {
            RespuestaAnalisisLexico resultado = new RespuestaAnalisisLexico();

            // Extraer y almacenar cadenas de texto antes de eliminar las comillas
            foreach (Match match in RegexCadenaTexto.Matches(codigoFuente))
            {
                resultado.CadenasTexto.Add(match.Value);
                codigoFuente = codigoFuente.Replace(match.Value, ""); // Remover las cadenas del código temporalmente
            }

            // Separar por espacios, tabulaciones y saltos de línea
            string[] tokens = Regex.Split(codigoFuente, @"([\s\+\-\*/%=<>&|^~{}\[\]\(\),;])")
                        .Where(t => !string.IsNullOrEmpty(t) && !char.IsWhiteSpace(t[0]))
                        .ToArray();

            foreach (string token in tokens)
            {
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
            }

            return resultado;
        }
    }
}
