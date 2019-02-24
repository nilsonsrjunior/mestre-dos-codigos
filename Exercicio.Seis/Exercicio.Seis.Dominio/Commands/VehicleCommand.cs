namespace Exercicio.Seis.Dominio.Commands
{
    public abstract class VehicleCommand : Command
    {
        protected string Name { get; set; }
        protected string Color { get; set; }
    }
}
