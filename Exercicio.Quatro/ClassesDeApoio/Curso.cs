namespace Exercicio.Quatro.ClassesDeApoio
{
    public class Curso
    {
        public string Nome { get; set; }

        public Segmento Segmento { get; set; }

        //C# 7 - Digit Separators.
        public int QuantidadeHoras { get; set; } = 1_024;

        //C# 7 - Usando binary literals, ou seja, estou representando em binário o número 2
        public int QtdAlunos { get; set; } = 0b10;
    }
}