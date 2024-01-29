using Delivery.Enums;
using System.Drawing;

namespace Delivery.Entities
{
	public class VehicleEntity
	{
        public Guid Id { get; set; }
        public Color Color { get; set; }
        public VehicleType Type { get; set; }
    }
}

