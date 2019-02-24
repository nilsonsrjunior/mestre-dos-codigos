using Exercicio.Seis.Dominio.Commands;

namespace Exercicio.Seis.CommandHandlers
{
    internal interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
