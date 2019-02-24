namespace Exercicio.Seis.Dominio.Commands
{
    internal interface ICommand : ILog
    {
        bool IsValid();
    }
}
