// <copyright file="Gramatica.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Compilador;
using Compilador.Herramientas;
using Irony.Parsing;

/// <summary>
/// Clase que contiene la gramatica.
/// </summary>
public class Gramatica : Grammar
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Gramatica"/> class.
    /// </summary>
    public Gramatica()
    {
        // Definir el terminal para los comentarios (líneas que empiezan con //)
        var comentario = new CommentTerminal("comentario", "//", "\n");

        // Definir los terminales para los tipos de datos con KeyTerm
        var tipoDato = new KeyTerm("int", "int") | new KeyTerm("float", "float") |
                       new KeyTerm("char", "char") | new KeyTerm("double", "double") |
                       new KeyTerm("long", "long") | new KeyTerm("short", "short");

        // Definir el terminal para los identificadores (nombres de variables)
        var identificador = new IdentifierTerminal("identificador");

        // Definir la regla para las declaraciones (tipo + identificador + ;)
        var declaracion = new NonTerminal("declaracion");
        declaracion.Rule = tipoDato + identificador + ";";

        // Raíz: una lista de declaraciones o comentarios
        var lista = new NonTerminal("lista");
        lista.Rule = MakeStarRule(lista, comentario | declaracion);

        // La raíz es ahora "lista", que puede contener múltiples declaraciones o comentarios
        this.Root = lista;

        // Marcar puntuaciones comunes en C como paréntesis, llaves y punto y coma
        this.MarkPunctuation("(", ")", "{", "}", ";");
    }
}
