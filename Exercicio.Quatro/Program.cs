using Exercicio.Quatro.ClassesDeApoio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//C# 6 - using estático
using static Exercicio.Quatro.ClassesDeApoio.MatriculaService;
//C# 6 - using estático
using static System.Console;

namespace Exercicio.Quatro
{
    class Program
    {
        static void Main(string[] args)
        {
            var aluno = new Aluno
            {
                Nome = "Nilson",
                JaEstudouNaInstituicao = false,
                Matricula = new Matricula
                {
                    Curso = new Curso
                    {
                        Segmento = new TI(),
                        Nome = "Análise de Sistemas"
                    }
                }
            };

            //C# 6 - Através do uso de using estático não é necessário repetir a mesma classe estática (MatriculaService) para a chamada dos métodos
            MatricularAluno(aluno);
            EnviarNotificacaoDeBemVindo(aluno);

            //C# 6 - using estático. Neste código existem vários WriteLines, não coloquei o comentário em todos para evitar repetição, mas todos usam o recurso.
            WriteLine();

            aluno.MostrarInformacoes();

            WriteLine();

            WriteLine("Atualizando cadastro do aluno Nilson...");
            Thread.Sleep(1000);
            aluno.Telefone = new Telefone { DDD = "43", Numero = "999146924" };
            WriteLine();

            aluno.MostrarInformacoes();

            WriteLine();

            WriteLine("Deseja gerar a próxima data de pagamento da mensalidade ? S - SIM | N - NÃO");
            var resposta = ReadLine();

            if (resposta.ToUpper() == "S")
            {
                var retornoPagamento = GerarPagamento(aluno);
                WriteLine();
                WriteLine($"O pagamento foi gerado para dia {retornoPagamento.dataPagamento.ToShortDateString()}.");
                WriteLine();
                if (retornoPagamento.debitoPendente)
                {
                    WriteLine("Atenção!!! Aluno com débito pendente!");
                }
            }

            WriteLine();

            WriteLine("Gostaria de verificar um possível desconto para as próximas mensalidades ? S - SIM | N - NÃO");
            resposta = ReadLine();

            if (resposta.ToUpper() == "S")
            {
                AplicarDesconto(aluno);
            }

            ReadLine();
        }

        //C# 7 - Pattern Matching usando expressões com IS para comparação e switch case condicional
        private static void AplicarDesconto(Aluno aluno)
        {
            switch (aluno.Matricula.Curso.Segmento)
            {
                case Segmento s when (s is Humanas):
                    WriteLine("Infelizmente não é possível aplicar desconto para cursos de humanas!!");
                    break;
                case Segmento s when (s is TI):
                    if (aluno.Matricula.Curso.Nome is "Análise de Sistemas")
                    {
                        var desconto = "5";

                        //C# 7 - Utilização de Out variables sendo criadas na mesma linha
                        if (int.TryParse(desconto, out var percentualDeDesconto))
                        {
                            WriteLine();
                            WriteLine($"Desconto de {percentualDeDesconto}% aplicado com sucesso!!");
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }

        //C# 7 - Utilização de tuplas no retorno dos métodos
        private static (bool debitoPendente, DateTime dataPagamento) GerarPagamento(Aluno aluno)
        {
            WriteLine($"Gerando pagamento para o Aluno: {aluno.Nome}...");
            Thread.Sleep(1500);
            return (AlunoTemDebitoPendente(aluno), DateTime.Now.AddDays(10));

            //C# 7 - Local functions
            //C# 6 - Expression-bodied methods para facilitar retornos de métodos simples
            bool AlunoTemDebitoPendente(Aluno a) => (a.Nome.Length % 2 == 0);
        }
    }
}
