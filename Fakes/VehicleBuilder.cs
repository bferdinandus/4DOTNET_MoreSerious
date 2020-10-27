using Bogus;
using Entities;

namespace Fakes
{
    class VehicleBuilder : Faker<Entities.Vehicle>
    {
        public VehicleBuilder()
        {
            StrictMode(true);
            // RuleFor(p => p.Id, f => f.IndexGlobal);
            RuleFor(r => r.VehicleIdentificationNumber, f => f.Vehicle.Vin() );
            RuleFor(r => r.Manufacturer, f => f.Vehicle.Manufacturer());
            RuleFor(r => r.Model, f => f.Vehicle.Model());
            RuleFor(r => r.Type, f => f.Vehicle.Type());
            RuleFor(r => r.Fuel, f => f.Vehicle.Fuel());
        }

    }
}
