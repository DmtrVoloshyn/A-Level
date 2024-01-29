using Delivery.Enums;

namespace Delivery.Entities
{
	public class DrugEntity : ItemEntity
	{

        public DrugEntity()
        {
            Item = ItemType.Drug;
        }

        public bool IsUrgent { get; set; }
        public bool IsReceiptRequired { get; set; }
    }
}

