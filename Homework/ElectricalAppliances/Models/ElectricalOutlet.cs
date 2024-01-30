namespace ElectricalAppliances.Models
{
    public class ElectricalOutlet
    {
        public bool IsPluggedIn { get; private set; }
        public double PowerConsumption { get; private set; }


        public void PlugInDevices(ElectronicDevice device)
        {
            if (!IsPluggedIn)
            {
                IsPluggedIn = true;
                Console.WriteLine($"Device {device.Brand} {device.Model} plugged in.");
                PowerConsumption = device.EnergyConsumption;
            }
        }

        public double GetPowerConsumption()
        {
            return IsPluggedIn ? PowerConsumption : 0.0;
        }
    }
}