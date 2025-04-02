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
        // Definir las expresiones terminales (tokens)
        var number = new NumberLiteral("number");
        var identifier = new IdentifierTerminal("identifier");

        var keywordPrint = ToTerm("print");
        var keywordIf = ToTerm("if");
        var keywordElse = ToTerm("else");
        var keywordWhile = ToTerm("while");
        var keywordFor = ToTerm("for");

        // Definir los operadores y delimitadores
        var operatorAdd = ToTerm("+");
        var operatorSub = ToTerm("-");
        var operatorMul = ToTerm("*");
        var operatorDiv = ToTerm("/");

        var operatorGreaterThan = ToTerm(">");
        var operatorLessThan = ToTerm("<");
        var operatorEqual = ToTerm("==");
        var operatorNotEqual = ToTerm("!=");

        var operatorAssignAdd = ToTerm("+=");  // Operador de asignación compuesto
        var operatorAssignSub = ToTerm("-=");  // Operador de asignación compuesto
        var operatorAssignMul = ToTerm("*=");  // Operador de asignación compuesto
        var operatorAssignDiv = ToTerm("/=");  // Operador de asignación compuesto

        var leftParenthesis = ToTerm("(");
        var rightParenthesis = ToTerm(")");
        var colon = ToTerm(":");
        var comma = ToTerm(",");

        // Definir los comentarios de una sola línea
        var comment = new CommentTerminal("comment", "#", "\n");

        // Definir las literales de cadenas (string)
        var stringLiteral = new StringLiteral("string", "\"", StringOptions.AllowsAllEscapes);

        // Definir las listas (arrays) en Python
        var leftBracket = ToTerm("[");
        var rightBracket = ToTerm("]");

        // Reglas de la gramática
        var expr = new NonTerminal("expr");
        var stmt = new NonTerminal("stmt");
        var stmtList = new NonTerminal("stmtList");
        var assignment = new NonTerminal("assignment");
        var printExprList = new NonTerminal("printExprList");
        var condition = new NonTerminal("condition");
        var whileStmt = new NonTerminal("whileStmt");
        var forStmt = new NonTerminal("forStmt");
        var listExpr = new NonTerminal("listExpr");
        var listElements = new NonTerminal("listElements"); // Definir NonTerminal para los elementos de la lista

        // Ignorar los comentarios y espacios
        this.NonGrammarTerminals.Add(comment);  // Añadir comentarios como no-terminales

        // Reglas de la gramática
        expr.Rule = number | identifier | stringLiteral | expr + operatorAdd + expr | expr + operatorSub + expr | expr + operatorMul + expr | expr + operatorDiv + expr | listExpr;

        // Expresión para listas (arrays)
        listExpr.Rule = leftBracket + listElements + rightBracket;

        // Elementos dentro de la lista
        listElements.Rule = MakeStarRule(listElements, comma, expr);

        // Regla para las expresiones dentro del print
        printExprList.Rule = MakePlusRule(printExprList, comma, expr);

        // Operadores de comparación para las condiciones
        condition.Rule = expr + operatorGreaterThan + expr | expr + operatorLessThan + expr | expr + operatorEqual + expr | expr + operatorNotEqual + expr;

        // Asignación de variables (tanto simple como compuesta)
        assignment.Rule = identifier + "=" + expr |
                          identifier + operatorAssignAdd + expr |
                          identifier + operatorAssignSub + expr |
                          identifier + operatorAssignMul + expr |
                          identifier + operatorAssignDiv + expr;

        // Bucle while
        whileStmt.Rule = keywordWhile + condition + colon + stmtList;

        // Bucle for
        forStmt.Rule = keywordFor + identifier + "in" + expr + colon + stmtList;

        // Reglas para la sentencia
        stmt.Rule = keywordPrint + leftParenthesis + printExprList + rightParenthesis |
                    keywordIf + condition + colon + stmtList + keywordElse + colon + stmtList |
                    whileStmt |
                    forStmt |
                    assignment |
                    comment;

        // Lista de sentencias
        stmtList.Rule = MakePlusRule(stmtList, stmt); // Reglas recursivas para listas de sentencias

        // Establecer la regla de inicio de la gramática
        Root = stmtList;
    }
}
