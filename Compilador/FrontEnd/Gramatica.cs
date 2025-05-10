// <copyright file="Gramatica.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Compilador.FrontEnd
{
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
            // Terminales
            var include = this.ToTerm("#include");
            var tipoInt = this.ToTerm("int");
            var tipoFloat = this.ToTerm("float");
            var tipoChar = this.ToTerm("char");
            var operadorAsignacion = this.ToTerm("=");
            var operadorSuma = this.ToTerm("+");
            var operadorScanf = this.ToTerm("scanf");
            var operadorPrintf = this.ToTerm("printf");
            var puntoYComa = this.ToTerm(";");
            var parentesisAbrir = this.ToTerm("(");
            var parentesisCerrar = this.ToTerm(")");
            var coma = this.ToTerm(",");
            var ampersand = this.ToTerm("&");
            var llaveAbrir = this.ToTerm("{");
            var llaveCerrar = this.ToTerm("}");
            var operadorReturn = this.ToTerm("return");

            var identificador = new IdentifierTerminal("identificador");
            var archivoInclude = new RegexBasedTerminal("archivoInclude", "<[a-zA-Z0-9_\\.]+>");
            var numeroEntero = new NumberLiteral("numeroEntero");
            var cadena = new StringLiteral("cadena", "\"");

            // No terminales
            var includeDirectiva = new NonTerminal("includeDirectiva");
            var declaracionVariable = new NonTerminal("Declaracion");
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
            var expresionBinaria = new NonTerminal("expresionBinaria");
            var listaExpresionesPrintf = new NonTerminal("listaExpresionesPrintf");

            var instruccionReturn = new NonTerminal("instruccionReturn");

            var tipoVariable = new NonTerminal("tipoVariable");

            var instruccionCodigo = new NonTerminal("instruccionCodigo");

            listaExpresionesPrintf.Rule = this.MakePlusRule(listaExpresionesPrintf, coma, expresionBinaria);

            expresionBinaria.Rule = identificador
                          | numeroEntero
                          | identificador + operadorSuma + identificador
                          | identificador + operadorAsignacion + identificador
                          | identificador + operadorAsignacion + numeroEntero;

            parametroScanf.Rule = ampersand + identificador;
            listaParametrosScanf.Rule = this.MakePlusRule(listaParametrosScanf, coma, parametroScanf);

            // Reglas
            listaParametrosPrintf.Rule = this.MakePlusRule(listaParametrosPrintf, coma, identificador);

            listaIncludes.Rule = this.MakeStarRule(listaIncludes, includeDirectiva);
            programa.Rule = listaIncludes + funcionMain;

            funcionMain.Rule = tipoInt + this.ToTerm("main") + parentesisAbrir + parentesisCerrar + bloque | includeDirectiva;

            bloque.Rule = llaveAbrir + declaracionesEnBloque + llaveCerrar;

            includeDirectiva.Rule = include + archivoInclude;

            tipoVariable.Rule = tipoInt | tipoFloat | tipoChar;

            declaracionVariable.Rule = tipoVariable + identificador + puntoYComa;

            expresion.Rule = identificador + operadorAsignacion + numeroEntero + puntoYComa
                           | identificador + operadorAsignacion + identificador + puntoYComa
                           | identificador + operadorSuma + identificador + puntoYComa;

            funcion.Rule = operadorPrintf + parentesisAbrir + cadena + parentesisCerrar + puntoYComa
                  | operadorPrintf + parentesisAbrir + cadena + coma + listaExpresionesPrintf + parentesisCerrar + puntoYComa
                  | operadorScanf + parentesisAbrir + cadena + coma + listaParametrosScanf + parentesisCerrar + puntoYComa;

            instruccionCodigo.Rule = funcion | declaracionVariable | expresion | instruccionReturn;

            declaracionesEnBloque.Rule = this.MakeStarRule(declaracionesEnBloque, instruccionCodigo);

            // Instrucción return
            instruccionReturn.Rule = operadorReturn + numeroEntero + puntoYComa;  // Acepta `return 0;`

            // Establecer el punto de entrada
            this.Root = programa;

            // Marcar símbolos de puntuación para que no aparezcan en el árbol
            this.MarkPunctuation(";", "(", ")", ",", "&", "{", "}", "#include");

            // Marcar palabras reservadas
            this.MarkReservedWords("int", "float", "char", "void", "printf", "scanf");
        }
    }
}