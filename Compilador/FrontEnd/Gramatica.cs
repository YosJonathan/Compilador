// <copyright file="Gramatica.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Compilador;
using Compilador.Herramientas;
using Irony.Parsing;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        // Definición de los terminales
        var include = new KeyTerm("#include", "#include");
        var identificador = new IdentifierTerminal("identificador");
        var tipoInt = new KeyTerm("int", "int");
        var tipoFloat = new KeyTerm("float", "float");
        var tipoChar = new KeyTerm("char", "char");
        var tipoVoid = new KeyTerm("void", "void");
        var operadorAsignacion = new KeyTerm("=", "=");
        var operadorSuma = new KeyTerm("+", "+");
        var operadorScanf = new KeyTerm("scanf", "scanf");
        var operadorPrintf = new KeyTerm("printf", "printf");
        var puntoYComa = new KeyTerm(";", "puntoYComa");
        var parentesisAbrir = new KeyTerm("(", "(");
        var parentesisCerrar = new KeyTerm(")", ")");
        var coma = new KeyTerm(",", "coma");
        var ampersand = new KeyTerm("&", "&");

        // Crear un Terminal que maneje la cadena entre < y > para #include
        var archivoInclude = new RegexBasedTerminal("archivoInclude", "<[a-zA-Z0-9_\\.]+>");

        // Definir el número entero como un literal de número
        var numeroEntero = new NumberLiteral("numeroEntero");

        // Definir las comillas dobles para cadenas de texto
        var comillas = new KeyTerm("\"", "\"");
        var cadena = new StringLiteral("cadena", "\"");

        // Regla para la directiva #include
        var includeDirectiva = new NonTerminal("includeDirectiva");
        includeDirectiva.Rule = include + archivoInclude + puntoYComa;

        // Reglas
        var declaracionVariable = new NonTerminal("declaracionVariable");
        declaracionVariable.Rule = tipoInt + identificador + coma + identificador + coma + identificador + puntoYComa
                                  | tipoFloat + identificador + coma + identificador + coma + identificador + puntoYComa
                                  | tipoChar + identificador + coma + identificador + coma + identificador + puntoYComa
                                  | tipoInt + identificador + puntoYComa
                                  | tipoFloat + identificador + puntoYComa
                                  | tipoChar + identificador + puntoYComa;

        var expresion = new NonTerminal("expresion");
        expresion.Rule = identificador + operadorAsignacion + identificador
                        | identificador + operadorAsignacion + numeroEntero
                        | identificador + operadorSuma + identificador;

        var funcion = new NonTerminal("funcion");
        funcion.Rule = operadorPrintf + parentesisAbrir + cadena + parentesisCerrar + puntoYComa
                      | operadorScanf + parentesisAbrir + cadena + coma + ampersand + identificador + parentesisCerrar + puntoYComa;

        var bloque = new NonTerminal("bloque");
        bloque.Rule = declaracionVariable + expresion + funcion;

        var funcionPrincipal = new NonTerminal("funcionPrincipal");
        funcionPrincipal.Rule = tipoInt + "main" + parentesisAbrir + parentesisCerrar + bloque;

        // Definir la raíz de la gramática
        Root = new NonTerminal("Root");
        Root.Rule = includeDirectiva + funcionPrincipal;

        // Definir qué hacer con los espacios en blanco
        this.LanguageFlags = LanguageFlags.CreateAst;
    }
}
