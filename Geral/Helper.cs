using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geral
{
    public static class Helper
    {
        public static void PrintarNoConsole(this string texto)
        {
            Console.WriteLine(texto);
        }

        public static void Printar(string texto)
        {
            texto.PrintarNoConsole();
        }
    }
}
