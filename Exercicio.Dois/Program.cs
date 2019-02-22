using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Geral;

namespace Exercicio.Dois
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa1 = new Pessoa
            {
                Nome = "Ana",
                Sobrenome = "Ruas",
                Idade = 23,
                Telefones = new List<Telefone>
                {
                    new Telefone { Numero = "999146926" },
                    new Telefone {Numero = "30267633" }
                }
            };

            var pessoa2 = new Pessoa
            {
                Nome = "Nilson",
                Sobrenome = "Ruas",
                Idade = 22,
                Telefones = new List<Telefone>
                {
                    new Telefone {Numero = "988519872" },
                    new Telefone {Numero = "30336985" },
                    new Telefone {Numero = "34721597" }
                }
            };

            PrintarDiferencasEntreObjetos(pessoa1, pessoa2);

            Console.ReadLine();
        }

        private static void PrintarDiferencasEntreObjetos(object primeiroObjeto, object segundoObjeto)
        {
            var tipoPrimeiroObjeto = primeiroObjeto.GetType();
            var tipoSegundoObjeto = segundoObjeto.GetType();

            if (tipoPrimeiroObjeto != tipoSegundoObjeto)
            {
                Console.WriteLine("Os objetos não são do mesmo tipo");
                return;
            }

            var propriedadesPrimeiroObjeto = tipoPrimeiroObjeto.GetProperties();
            var propriedadesSegundoObjeto = tipoSegundoObjeto.GetProperties();

            foreach (var propriedadePrimeiroObjeto in propriedadesPrimeiroObjeto)
            {
                var nomePropriedadePrimeiroObjeto = propriedadePrimeiroObjeto.Name;
                var valorPropriedadePrimeiroObjeto = propriedadePrimeiroObjeto.GetValue(primeiroObjeto);

                var propriedadeSegundoObjeto =
                    propriedadesSegundoObjeto.FirstOrDefault(x => x.Name == nomePropriedadePrimeiroObjeto &&
                                                                  x.GetValue(segundoObjeto) != valorPropriedadePrimeiroObjeto);

                if (propriedadeSegundoObjeto != null)
                {
                    var mensagem = $"A propriedade: {nomePropriedadePrimeiroObjeto}, do primeiro objeto, possui";
                    var valorPropriedadeSegundoObjeto = propriedadeSegundoObjeto.GetValue(segundoObjeto);

                    if (valorPropriedadePrimeiroObjeto.GetType().IsEnumerable())
                    {
                        var qtdItensPrimeiroObjeto = (valorPropriedadePrimeiroObjeto as ICollection).Count;
                        var qtdItensSegundoObjeto = (valorPropriedadeSegundoObjeto as ICollection).Count;

                        if (qtdItensPrimeiroObjeto != qtdItensSegundoObjeto)
                        {
                            mensagem += $" {qtdItensPrimeiroObjeto} itens, já o segundo objeto possui {qtdItensSegundoObjeto} itens";
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        mensagem += $@" o valor: {valorPropriedadePrimeiroObjeto}, já o segundo objeto possui o valor {valorPropriedadeSegundoObjeto}";
                    }

                    mensagem.PrintarNoConsole();
                }
            }
        }
    }
}
