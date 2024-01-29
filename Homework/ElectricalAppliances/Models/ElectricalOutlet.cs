namespace ElectricalAppliances.Models
{
    public class ElectricalOutlet
    {
        private List<ElectronicDevice> ConnectedDevices { get; } = new List<ElectronicDevice>();

        public bool IsPluggedIn { get; private set; }

        public void PlugInDevices(ElectronicDevice device)
        {
            if (!IsPluggedIn)
            {
                IsPluggedIn = true;
                Console.WriteLine($"Device {device.Brand} {device.Model} plugged in.");
                ConnectedDevices.Add(device);
            }
        }


        public double CalculatePowerConsumption()
        {
            double totalPowerConsumption = 0;

            foreach (var device in ConnectedDevices)
            {
                totalPowerConsumption += device.EnergyConsumption;
            }

            Console.WriteLine($"Total power consumption: {totalPowerConsumption} watts");
            return totalPowerConsumption;
        }
    }
}