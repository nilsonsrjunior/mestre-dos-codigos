    using System;
using Exercicio.Seis.CommandHandlers;
using Exercicio.Seis.Dominio.Commands;

namespace Exercicio.Seis.Dominio.CommandHandlers
{
    public class VehicleCommandHandler :
        ICommandHandler<RegisterVehicleCommand>,
        ICommandHandler<UpdateVehicleCommand>
    {
        public void Handle(RegisterVehicleCommand command)
        {
            if (!command.IsValid())
            {
                Console.WriteLine($"{nameof(RegisterVehicleCommand)} is not valid");
                return;
            }

            Save();
            command.RegisterLog();
            Console.WriteLine("Vehicle Registered!");
        }

        public void Handle(UpdateVehicleCommand command)
        {
            if (!command.IsValid())
            {
                Console.WriteLine($"{nameof(UpdateVehicleCommand)} is not valid");
                return;
            }

            Save();
            command.RegisterLog();
            Console.WriteLine("Vehicle Updated!");
        }

        private void Save()
        {
            //Save vehicle in DB
        }
    }
}
