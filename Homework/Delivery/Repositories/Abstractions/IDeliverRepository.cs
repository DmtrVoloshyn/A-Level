using System;
using Delivery.Entities;

namespace Delivery.Repositories.Abstractions
{
	public interface IDeliverRepository
	{
        DeliverEntity[] GetDeliver();
    }
}

