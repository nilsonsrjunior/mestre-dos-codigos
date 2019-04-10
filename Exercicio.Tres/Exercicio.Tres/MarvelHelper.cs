using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Exercicio.Tres
{
    public static class MarvelHelper
    {
        public static Personagem FindOutAboutMarvelHero(IConfiguration configuration, string hero)
        {
            Personagem personagem = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var ts = DateTime.Now.Ticks.ToString();
                var publicKey = configuration.GetSection("MarvelComicsAPI:PublicKey").Value;
                var hash = GerarHash(ts, publicKey,
                    configuration.GetSection("MarvelComicsAPI:PrivateKey").Value);

                Console.WriteLine("Looking for hero's info at Marvel's API");
                Console.WriteLine();

                var response = client.GetAsync(
                    configuration.GetSection("MarvelComicsAPI:BaseURL").Value +
                    $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                    $"name={Uri.EscapeUriString(hero)}").Result;

                response.EnsureSuccessStatusCode();
                var conteudo = response.Content.ReadAsStringAsync().Result;

                dynamic resultado = JsonConvert.DeserializeObject(conteudo);

                try
                {
                    personagem = new Personagem
                    {
                        Nome = resultado.data.results[0].name,
                        Descricao = resultado.data.results[0].description,
                        UrlImagem = resultado.data.results[0].thumbnail.path + "." + resultado.data.results[0].thumbnail.extension,
                        UrlWiki = resultado.data.results[0].urls[1].url
                    };

                    Console.WriteLine($"Hero Info: {JsonConvert.SerializeObject(personagem)}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Hero does not exist");
                }
            }

            return personagem;
        }

        private static string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            var bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = System.Security.Cryptography.MD5.Create();
            var bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }
    }
}
