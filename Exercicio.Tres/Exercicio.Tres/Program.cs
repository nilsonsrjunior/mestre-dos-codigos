using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio.Tres
{
    class Program
    {
        private static string _url = "https://cat-fact.herokuapp.com/facts";
        private static List<CatFact> _facts = new List<CatFact>();

        static void Main(string[] args)
        {
            var catFacts = _url.GetJsonAsync<CatFactResult>().Result;

            if (catFacts != null && catFacts.All != null)
            {
                _facts = catFacts.All;
            }

            Console.WriteLine("Pressione uma tecla sempre que quiser saber uma curiosidade sobre gatos");
            Console.WriteLine();
            Console.ReadLine();
            StartPrintingCatCuriosity();
        }

        private static void StartPrintingCatCuriosity()
        {
            if (_facts.Count == 0)
            { 
                Console.WriteLine("Não existem mais curiosidades sobre gatos, disponível");
                Console.ReadLine();
            }
            else
            {
                var fact = _facts.FirstOrDefault();
                Console.WriteLine(fact.Text);
                _facts.Remove(fact);
                Console.ReadLine();
                StartPrintingCatCuriosity();
            }
        }
    }
}

