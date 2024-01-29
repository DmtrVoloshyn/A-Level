using System;
using Delivery.Entities;
using Delivery.Repositories.Abstractions;

namespace Delivery.Repositories
{
	public class VehicleRepository : IVehicleRepository
	{
		public VehicleRepository()
		{
		}

        public VehicleEntity[] GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}

