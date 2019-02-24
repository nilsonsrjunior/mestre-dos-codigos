using Exercicio.Seis.Dominio.CommandHandlers;
using Exercicio.Seis.Dominio.Commands;
using System;

namespace Exercicio.Seis
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new VehicleCommandHandler();

            Console.WriteLine("Registering Vehicle... ");
            var registerCommand = new RegisterVehicleCommand("VW Gol", "Prata");
            handler.Handle(registerCommand);

            Console.WriteLine("......................");

            Console.WriteLine("Updating Vehicle... ");
            var updatingCommand = new UpdateVehicleCommand(Guid.Empty, "VW Gol", "Prata");
            handler.Handle(updatingCommand);

            Console.WriteLine(".....................");

            Console.WriteLine("Updating New Vehicle... ");
            updatingCommand = new UpdateVehicleCommand(Guid.NewGuid(), "VW Gol", "Prata");
            handler.Handle(updatingCommand);

            Console.ReadKey();
        }
    }
}
