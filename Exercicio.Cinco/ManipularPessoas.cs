using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Cinco
{
    public static class ManipularPessoas
    {
        public static void Mostrar(IEnumerable<Pessoa> pessoas)
        {
            //Ao utilizar o ToList() eu estou indexando a minha lista e desabilitando o deffered execution
            //Com isso eu tenho a desvantagem de ter que carregar todos os itens na coleção imediatamente, porém,
            //Eu tenho a facilidade de buscar e remover elementos por seus índices, por exemplo, além de é claro, poder manipular
            //A lista como for necessário
            var listaDePessoas = pessoas.ToList();

            listaDePessoas.Add(new Pessoa { Nome = "Ainda posso adicionar uma pessoa pois transformei este IEnumerable num List!!" });

            foreach (var item in listaDePessoas)
            {
                Console.WriteLine($"Printei uma pessoa: {item.Nome}");
                Console.WriteLine();

                Console.WriteLine($"Esta pessoa tem as seguintes restrições:");

                if(item.Restricoes != null)
                {
                    foreach (var restricao in item.Restricoes)
                    {
                        Console.WriteLine($"- {restricao}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Infelizmente não consigo alterar a lista de restrições pois ela é um IEnumerable");
                Console.WriteLine();

                Console.WriteLine($"- A pessoa possui {item.Telefones?.Count} telefones");

                Console.WriteLine();
                Console.WriteLine("Só foi possível mostrar a quantidade de telefones pois estava utilizando um ICollection que possui a propriedade Count");
                Console.WriteLine();

                Console.WriteLine("E por último, esta pessoa possui os seguintes familiares:");

                if(item.Familiares != null)
                {
                    foreach (var familiar in item.Familiares)
                    {
                        Console.WriteLine($"- O indice do familiar: {familiar}, é: {item.Familiares.IndexOf(familiar)}");
                    }
                }

                Console.WriteLine("O indice ferente a cada elemento da coleção foi printado em seguida do seu valor. Isto só foi possível pois estou usando um IList e ela é indexada.");

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
