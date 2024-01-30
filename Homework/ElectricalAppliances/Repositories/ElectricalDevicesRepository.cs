using ElectricalAppliances.Entities;

namespace ElectricalAppliances.Repositories
{
	public class ElectricalDevicesRepository : MockRepository<ElectronicDeviceEntity>
    {
		public ElectricalDevicesRepository()
		{
            MockItems();
        }

        public override ElectronicDeviceEntity Get(Guid id)
        {
            try
            {
                foreach (var item in Items)
                {
                    if (id == item.Id)
                    {
                        return item;
                    }
                    throw new Exception($"Item:{id} not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public override List<ElectronicDeviceEntity> GetAll() => Items;
        

        public override void MockItems()
        {
            Items.Add(new DishwasherEntity
            {
                Id = Guid.NewGuid(),
                Brand = "Samsung",
                EnergyConsumption = 1200,
                IsPortable = false,
                IsConstantEnergyConsumption = false,
                DeviceName = "Dishwasher Samsung"
            });
            Items.Add(new FridgeEntity
            {
                Id = Guid.NewGuid(),
                Brand = "Samsung",
                EnergyConsumption = 600,
                IsPortable = false,
                IsConstantEnergyConsumption = true,
                DeviceName = "Fridge Samsung"
            });
            Items.Add(new VacuumEntity
            {
                Id = Guid.NewGuid(),
                Brand = "Xiaomi",
                EnergyConsumption = 200,
                IsPortable = true,
                HasRemoteControl = true,
                IsSmart = true,
                DeviceName = "Smart Vacuum Xiaomi"
            });
            Items.Add(new AirConditionerEntity
            {
                Id = Guid.NewGuid(),
                Brand = "TOSOT",
                EnergyConsumption = 700,
                IsPortable = false,
                HasRemoteControl = true,
                IsSmart = true,
                DeviceName = "Air conditioner TOSOT"
            });
        }
    }
}

