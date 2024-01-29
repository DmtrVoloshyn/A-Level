using System;
using Delivery.Entities;

namespace Delivery.Repositories.Abstractions
{
	public interface IVehicleRepository
	{
        VehicleEntity[] GetVehicles();
    }
}

