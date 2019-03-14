using System;

namespace Exercicio.Nove
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recebendo imagem base64....");

            var base64String = "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";
            var imageBytes = base64String.ToBytes();

            var file = new File(imageBytes);
            file.Save();
                
            Console.WriteLine("Arquivo salvo com sucesso!!!!");
            Console.ReadKey();
        }
    }
}
