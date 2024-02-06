using ElectricalAppliances.Models;

namespace ElectricalAppliances.Extensions
{
	public static class Extensions
	{
        public static List<ElectronicDevice> FindByEnergyConsumption(this List<ElectronicDevice> electronicDevices, int energyСonsumption)
        {
            return electronicDevices.FindAll(d => d.EnergyConsumption <= energyСonsumption);
        }

        public static List<ElectronicDevice> FindByIsPortableProperty(this List<ElectronicDevice> electronicDevices)
        {
            return electronicDevices.FindAll(d => d.IsPortable);
        }

        public static List<ElectronicDevice> FindByBrand(this List<ElectronicDevice> electronicDevices, string brand)
        {
            return electronicDevices.FindAll(d => d.Brand == brand);
        }
    }
}

