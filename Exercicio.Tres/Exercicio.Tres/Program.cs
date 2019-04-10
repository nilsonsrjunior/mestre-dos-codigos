using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Exercicio.Tres
{
    public class Program
    {
        private const string _hero = "Hulk";

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            Console.WriteLine($"Selected Hero: {_hero}");
            Console.WriteLine(Environment.NewLine);

            MarvelHelper.FindOutAboutMarvelHero(configuration, _hero);

            Console.Read();
        }
    }
}

