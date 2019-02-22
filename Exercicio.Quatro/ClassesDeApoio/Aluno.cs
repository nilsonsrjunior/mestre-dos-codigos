using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Quatro.ClassesDeApoio
{
    public class Aluno
    {
        public string Nome { get; set; }
        public Matricula Matricula { get; set; }
        public Telefone Telefone { get; set; }

        //C# 6 - Esta propriedade usa a melhoria do recurso auto-properties para propriedades somente leitura, usando get"
        public DateTime DataCadastro { get; }

        //C# 6 - Inicializador de propriedade com valor default
        public bool JaEstudouNaInstituicao { get; set; } = true;

        //C# 6 - Expression-bodied methods para facilitar implementação de 'gets' simples        
        public bool PossuiDesconto => JaEstudouNaInstituicao; //Se o aluno já estudou, ele possui desconto

        public Aluno()
        {
            //C# 6 - Setado direto no atributo readonly por trás dos panos
            this.DataCadastro = DateTime.Now;
        }

        //C# 6 - Interpolação de strings é a nova maneira de concatenar textos e variáveis
        //C# 6 - Expression-bodied methods para facilitar retornos de métodos simples
        public override string ToString() => $"Aluno: {Nome}";

        //C# 6 - Utilização do operador condicionado para nulos '?'
        public void MostrarInformacoes()
            => Console.WriteLine($"Aluno: {Nome}, Telefone: {Telefone?.DDD + Telefone?.Numero}");
    }
}
