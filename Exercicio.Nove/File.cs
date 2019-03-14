using System;

namespace Exercicio.Nove
{
    public class File
    {
        static File()
        {
            LastUploadDateTime = DateTime.Now;
        }

        public File(byte[] image)
        {
            this.Image = image;
        }

        public static DateTime LastUploadDateTime { get; private set; }
        public byte[] Image { get; private set; }

        internal void Save()
        {
            Console.WriteLine($"Última data de upload de arquivo em: {LastUploadDateTime.ToString("dd/MM/yyyy hh:mm:ss")}");
        }
    }
}
