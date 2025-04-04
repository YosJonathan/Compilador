// <copyright file="Gramatica.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Compilador;
using Compilador.Herramientas;
using Irony.Parsing;
using System.Linq.Expressions;

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
        // Definir terminales para palabras clave
        var select = new KeyTerm("SELECT", "SELECT");
        var from = new KeyTerm("FROM", "FROM");
        var where = new KeyTerm("WHERE", "WHERE");
        var and = new KeyTerm("AND", "AND");
        var or = new KeyTerm("OR", "OR");
        var equals = new KeyTerm("=", "=");
        var comma = new KeyTerm(",", ",");
        var asterisk = new KeyTerm("*", "*");
        var identifier = new IdentifierTerminal("identifier");

        // Definir literales para cadenas
        var stringLiteral = new StringLiteral("string", "\"");

        // Definir terminal para números (enteros y flotantes)
        var number = new NumberLiteral("number");

        // Definir las expresiones
        var expression = new NonTerminal("expression");
        expression.Rule = identifier | number | stringLiteral;

        // Definir una lista de columnas en SELECT
        var columns = new NonTerminal("columns");
        columns.Rule = MakePlusRule(columns, comma, expression); // Una o más columnas separadas por coma

        // Definir una condición en WHERE
        var condition = new NonTerminal("condition");
        condition.Rule = expression + equals + expression |
                         expression + and + condition |
                         expression + or + condition;

        // Definir la consulta SQL con punto y coma como alternativa opcional
        var selectStatement = new NonTerminal("selectStatement");
        selectStatement.Rule = select + columns + from + identifier +
                               (where + condition) + ";" |
                               select + columns + from + identifier + ";";  // Alternativa sin WHERE

        // La raíz de la gramática es la consulta SQL
        this.Root = selectStatement;

        // Marcar puntuaciones comunes, incluyendo el punto y coma
        this.MarkPunctuation(",", ";", "(", ")");
    }
}
