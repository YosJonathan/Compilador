using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Compilador.Modelos
{
    public class RespuestaAnalisisLexico
    {
        public List<string> PalabrasReservadas { get; set; } = new List<string>();
        public List<string> Identificadores { get; set; } = new List<string>();
        public List<string> Numeros { get; set; } = new List<string>();
        public List<string> Operadores { get; set; } = new List<string>();
        public List<string> Simbolos { get; set; } = new List<string>();
        public List<string> CadenasTexto { get; set; } = new List<string>();

        public List<string> DirectivasPreprocesador { get; set; } = new List<string>();

        public string ConvertirAJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
