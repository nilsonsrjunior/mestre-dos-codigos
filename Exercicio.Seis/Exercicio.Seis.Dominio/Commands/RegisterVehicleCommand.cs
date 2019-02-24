namespace Exercicio.Seis.Dominio.Commands
{
    public sealed class RegisterVehicleCommand : VehicleCommand
    {
        public RegisterVehicleCommand(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public override bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Color))
                valid = false;

            return valid;
        }
    }
}
