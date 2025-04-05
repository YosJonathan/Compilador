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
        // Terminales
        var include = ToTerm("#include");
        var tipoInt = ToTerm("int");
        var tipoFloat = ToTerm("float");
        var tipoChar = ToTerm("char");
        var tipoVoid = ToTerm("void");
        var operadorAsignacion = ToTerm("=");
        var operadorSuma = ToTerm("+");
        var operadorScanf = ToTerm("scanf");
        var operadorPrintf = ToTerm("printf");
        var puntoYComa = ToTerm(";");
        var parentesisAbrir = ToTerm("(");
        var parentesisCerrar = ToTerm(")");
        var coma = ToTerm(",");
        var ampersand = ToTerm("&");
        var llaveAbrir = ToTerm("{");
        var llaveCerrar = ToTerm("}");

        var identificador = new IdentifierTerminal("identificador");
        var archivoInclude = new RegexBasedTerminal("archivoInclude", "<[a-zA-Z0-9_\\.]+>");
        var numeroEntero = new NumberLiteral("numeroEntero");
        var cadena = new StringLiteral("cadena", "\"");

        // No terminales
        var includeDirectiva = new NonTerminal("includeDirectiva");
        var declaracionVariable = new NonTerminal("declaracionVariable");
        var expresion = new NonTerminal("expresion");
        var funcion = new NonTerminal("funcion");
        var declaracionesEnBloque = new NonTerminal("declaracionesEnBloque");
        var bloque = new NonTerminal("bloque");
        var funcionMain = new NonTerminal("funcionMain");
        var programa = new NonTerminal("programa");
        var listaIncludes = new NonTerminal("listaIncludes");
        var listaParametrosPrintf = new NonTerminal("listaParametrosPrintf");
        var parametroScanf = new NonTerminal("parametroScanf");
        var listaParametrosScanf = new NonTerminal("listaParametrosScanf");

        parametroScanf.Rule = ampersand + identificador;
        listaParametrosScanf.Rule = MakePlusRule(listaParametrosScanf, coma, parametroScanf);


        // Reglas
        listaParametrosPrintf.Rule = MakePlusRule(listaParametrosPrintf, coma, identificador);

        listaIncludes.Rule = MakeStarRule(listaIncludes, includeDirectiva);
        programa.Rule = listaIncludes + funcionMain;

        funcionMain.Rule = tipoInt + ToTerm("main") + parentesisAbrir + parentesisCerrar + bloque | includeDirectiva;

        bloque.Rule = llaveAbrir + declaracionesEnBloque + llaveCerrar;


        includeDirectiva.Rule = include + archivoInclude;

        declaracionVariable.Rule = (tipoInt | tipoFloat | tipoChar) + identificador + puntoYComa;

        expresion.Rule = identificador + operadorAsignacion + numeroEntero + puntoYComa
                       | identificador + operadorAsignacion + identificador + puntoYComa
                       | identificador + operadorSuma + identificador + puntoYComa;

        funcion.Rule = operadorPrintf + parentesisAbrir + cadena + parentesisCerrar + puntoYComa
             | operadorPrintf + parentesisAbrir + cadena + coma + listaParametrosPrintf + parentesisCerrar + puntoYComa
             | operadorScanf + parentesisAbrir + cadena + coma + ampersand + listaParametrosScanf + parentesisCerrar + puntoYComa;


        declaracionesEnBloque.Rule = MakeStarRule(declaracionesEnBloque,funcion | declaracionVariable | expresion);

        // Establecer el punto de entrada
        this.Root = programa;

        // Marcar símbolos de puntuación para que no aparezcan en el árbol
        MarkPunctuation(";", "(", ")", ",", "&", "{", "}", "#include");

        // Marcar palabras reservadas
        MarkReservedWords("int", "float", "char", "void", "printf", "scanf");
    }

}
