using Newtonsoft.Json;
using System;

namespace Exercicio.Seis.Dominio.Commands
{
    public sealed class UpdateVehicleCommand : VehicleCommand
    {
        public Guid Id { get; private set; }

        public UpdateVehicleCommand(Guid id, string name, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
        }

        public override bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Color) ||
                this.Id == Guid.Empty)
                valid = false;

            return valid;
        }

        public override void RegisterLog()
        {
            Console.WriteLine($"UpdateVehicleCommand object: {JsonConvert.SerializeObject(this)}");
            base.RegisterLog();
        }
    }
}
