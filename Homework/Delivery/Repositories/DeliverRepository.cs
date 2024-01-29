using System.Xml.Linq;
using Delivery.Entities;
using Delivery.Models;
using Delivery.Repositories.Abstractions;

namespace Delivery.Repositories
{
	public class DeliverRepository : IDeliverRepository
	{
        private List<DeliverEntity> _delivers;
        private readonly IVehicleRepository _vehicleRepository;



        public DeliverRepository(IVehicleRepository vehicleRepository)
		{
            _vehicleRepository = vehicleRepository;
        }

        public DeliverEntity[] GetDeliver()
        {
            
        }

        private List<DeliverEntity> ConstructDeliver()
        {
            return _delivers = new List<DeliverEntity>()
            {
                new DeliverEntity()
                {
                    Id = new Guid.NewGuid(),
                    Name = "ABS",
                    Vehicle =
                    VehicleId = Vehicle
                }
            }
        }
    }
}

