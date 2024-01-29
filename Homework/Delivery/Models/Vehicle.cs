using System.Drawing;
using Delivery.Enums;

namespace Delivery.Models
{
	public class Vehicle
	{
		public Guid Id { get; set; }
		public Color Color { get; set; }
		public VehicleType Type { get; set; }
	}
}

