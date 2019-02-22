using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Cinco
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoas = RetornaPessoas();

            foreach (var item in pessoas)
            {
                Console.WriteLine($"Printei uma pessoa: {item.Nome}");

                if (item.Nome.Contains("3"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Oba, não preciso executar mais, já achei o que eu queria");
                    break;
                }
            }

            Console.WriteLine("Deseja prosseguir para o próximo exemplo ? S - SIM | N - NÃO");

            var resposta = Console.ReadLine();

            if(resposta?.ToUpper() == "S")
            {
                ManipularPessoas.Mostrar(pessoas);
            }

            Console.ReadLine();
        }


        /// <summary>
        /// Utilização de yield return.
        /// O yield return nos permite adicionar através de deffered execution um item à uma coleção a medida
        /// que o seu valor é solicitado. Neste exemplo a cada vez que o foreach do método Main solicita um 
        /// valor da coleção para printar, o yield do RetornaPessoas é executado e adiciona mais um item à coleção (este que será mostrado)
        /// portanto isto pode resultar em uma melhora grande de performance. Um exemplo seria um cenário onde o desenvolvedor
        /// não precise iterar todos os itens da lista para interromper a execução. Portanto ao iterar a lista e encontrar
        /// o valor que precisa ele pode interromper a execução da iteração sem ter que adicionar todos os itens na coleção.
        /// Este exemplo foi demonstrado no método Main
        /// </summary>
        private static IEnumerable<Pessoa> RetornaPessoas()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Incrementei um item na lista");
                yield return new Pessoa
                {
                    Nome = $"Pessoa_{i}",
                    Restricoes = new string[] { "Serasa", "SPC" },
                    Telefones = new string[] { "999146925", "11111111" },
                    Familiares = new string[] { "José", "Ana" }
                };
            };
        }
    }

    public struct Pessoa
    {
        public string Nome { get; set; }

        // Um fator interessante a ressaltar sobre todas as interfaces utilizadas nos exemplos
        // É cada nível utilizado representa basicamente um nível de especificidade e detalhamento maior
        // Com relação à interface de cima, o que é representado pela assinatura das listas a seguir:
        // IEnumerable<out T> : IEnumerable
        // ICollection<T> : IEnumerable<T>, IEnumerable
        // IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
        #region Listas

        #endregion
        //O IEnumerable é uma coleção de valores que só pode ser iterada. 
        //Ele atende à casos onde iremos atribuir um valor e este valor é imutável.
        //Apesar de existirem alternativas para extender a funcionalidade desta interface o seu funcionamento
        //É bastante simples. Quem a implementar deve implementar o método GetEnumerator() que irá "ensinar" ao c#
        //Como avançar na coleção para o próximo elemento. Ele não possui indexação nativamente e é utilizado em casos mais simples.
        public IEnumerable<string> Restricoes { get; set; }

        /// A interface ICollection apesar de também não ser indexada, nos da a possibilidade de manipular 
        /// a coleção através dos métodos Add, Clear, Remove fornecendo também a propriedade Count para indicar
        /// a quantidade de elementos na coleção. Esta interface é indicada para coleções que poderão sofrer
        /// uma manipulação mas não necessitam de ordenação e nem se preocupar com a ordem do 
        /// posicionamento dos elementos na coleção
        public ICollection<string> Telefones { get; set; }

        // Já a interface IList oferece a indexeção dos elementos da lista.
        // Além dos métodos contidos na interface ICollection, ela ainda nos trás alguns outros
        // como: RemoveAt, IndexOf, Insert. Por ser uma lista indexada é possível acessá-la através de "[]"
        // Por ser a mais completa ela é também a mais "pesada" portanto seu uso deve ser analisado com ressalvas.
        // O uso da interface IList é indicado para cenários onde a coleção será manipulada (inserindo, removendo) 
        // E também reordenada. Deve ser usada também em casos onde a ordem dos elementos dentro da coleção importa
        public IList<string> Familiares { get; set; }
    }
}