using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio.Quatro.ClassesDeApoio
{
    public static class MatriculaService
    {
        public static void MatricularAluno(Aluno a)
        {
            //C# 6 - Interpolação de strings é a nova maneira de concatenar textos e variáveis
            Console.WriteLine($"Matriculando o aluno: {a.Nome}....");
            Thread.Sleep(2000);
            //C# 6 - Interpolação de strings é a nova maneira de concatenar textos e variáveis
            //C# 6 - Operador nameof pode ser usado para obtermos o valor referente ao nome de uma classe
            Console.WriteLine($"{nameof(Aluno)} matrículado com sucesso!!!!!");
            Console.WriteLine();
        }

        public static void EnviarNotificacaoDeBemVindo(Aluno a)
        {
            Console.WriteLine("Seja muito bem vindo !!!");
        }
    }
}
