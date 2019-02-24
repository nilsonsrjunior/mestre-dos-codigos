using System;

namespace Exercicio.Seis.Dominio.Commands
{
    public abstract class Command : ICommand
    {
        public abstract bool IsValid();

        public virtual void RegisterLog()
        {
            Console.WriteLine($"Command executed at: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
        }
    }
}
