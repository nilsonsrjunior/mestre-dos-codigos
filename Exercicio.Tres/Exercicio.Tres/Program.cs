using Flurl.Http;
using Newtonsoft.Json;

namespace Exercicio.Tres
{
    class Program
    {
        private static string _url = "https://financialmodelingprep.com/api/stock/gainers";

        static void Main(string[] args)
        {
            var mostGainerStockCompanies = _url.GetStringAsync().Result;
            var a = JsonConvert.DeserializeObject(mostGainerStockCompanies.Replace("<pre>", "").Replace("</pre>", ""));

            var type = a.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                var b = prop;
            }
        }
    }
}

