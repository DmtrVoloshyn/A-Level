namespace ElectricalAppliances.Entities
{
    public class HomeDeviceEntity : ElectronicDeviceEntity
    {
        public bool HasRemoteControl { get; set; }
        public bool IsSmart { get; set; }
    }
}
