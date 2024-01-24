using CandyGift.Entities;
using CandyGift.Entities.Candies;
using CandyGift.Entities.Cookies;
using CandyGift.Models;
using CandyGift.Models.Candies;
using CandyGift.Models.Cookies;

namespace CandyGift.Сonverters
{
	public static class ModelConverter
	{

		public static KokoshaEntity ToEntity(this Kokosha kokosha)
		{
			return new KokoshaEntity
			{
                Name = kokosha.Name,
                Id = Guid.NewGuid(),
				Weight = kokosha.Weight,
				OatmealAmount = kokosha.OatmealAmount,
				Manufacturer = kokosha.Manufacturer,
				HasChocolateChips = kokosha.HasChocolateChips,
				HasNuts = kokosha.HasNuts,
				IsVegan = kokosha.IsVegan
			};
		}

        public static KontikEntity ToEntity(this Kontik kontik)
        {
            return new KontikEntity
            {
                Name = kontik.Name,
                Id = Guid.NewGuid(),
                Weight = kontik.Weight,
                Manufacturer = kontik.Manufacturer,
                HasChocolateChips = kontik.HasChocolateChips,
                IsVegan = kontik.IsVegan,
				ChocolateType = kontik.ChocolateType,
				ChocolateWeight = kontik.ChocolateWeight
            };
        }

        public static ChupaChupsEntity ToEntity(this ChupaChups chupaChups)
        {
            return new ChupaChupsEntity
            {
                Name = chupaChups.Name,
                Id = Guid.NewGuid(),
                Weight = chupaChups.Weight,
                Manufacturer = chupaChups.Manufacturer,
                IsSoftCaramel = chupaChups.IsSoftCaramel,
                IsFruitTaste = chupaChups.IsFruitTaste,
                IsHandMade = chupaChups.IsHandMade,
                IsWithFilling = chupaChups.IsWithFilling
            };
        }

        public static MilkyWayEntity ToEntity(this MilkyWay milkyWay)
        {
            return new MilkyWayEntity
            {
                Name = milkyWay.Name,
                Id = Guid.NewGuid(),
                Weight = milkyWay.Weight,
                Manufacturer = milkyWay.Manufacturer,
                IsFruitTaste = milkyWay.IsFruitTaste,
                ChocolateType = milkyWay.ChocolateType,
                IsHandMade = milkyWay.IsHandMade,
                IsWithFilling = milkyWay.IsWithFilling
            };
        }

        public static MilkyWay ToModel(this MilkyWayEntity milkyWayEntity)
        {
            return new MilkyWay
            {
                Name = milkyWayEntity.Name,
                Weight = milkyWayEntity.Weight,
                Manufacturer = milkyWayEntity.Manufacturer,
                IsFruitTaste = milkyWayEntity.IsFruitTaste,
                ChocolateType = milkyWayEntity.ChocolateType,
                IsHandMade = milkyWayEntity.IsHandMade,
                IsWithFilling = milkyWayEntity.IsWithFilling
            };
        }

        public static ChupaChups ToModel(this ChupaChupsEntity chupaChupsEntity)
        {
            return new ChupaChups
            {
                Name = chupaChupsEntity.Name,
                Weight = chupaChupsEntity.Weight,
                Manufacturer = chupaChupsEntity.Manufacturer,
                IsFruitTaste = chupaChupsEntity.IsFruitTaste,
                IsHandMade = chupaChupsEntity.IsHandMade,
                IsSoftCaramel = chupaChupsEntity.IsSoftCaramel,
                IsWithFilling = chupaChupsEntity.IsWithFilling
            };
        }

        public static Kontik ToModel(this KontikEntity kontikEntity)
        {
            return new Kontik
            {
                Name = kontikEntity.Name,
                Weight = kontikEntity.Weight,
                Manufacturer = kontikEntity.Manufacturer,
                HasChocolateChips = kontikEntity.HasChocolateChips,
                IsVegan = kontikEntity.IsVegan,
                ChocolateType = kontikEntity.ChocolateType,
                ChocolateWeight = kontikEntity.ChocolateWeight
            };
        }

        public static Kokosha ToModel(this KokoshaEntity kokoshaEntity)
        {
            return new Kokosha
            {
                Name = kokoshaEntity.Name,
                Weight = kokoshaEntity.Weight,
                OatmealAmount = kokoshaEntity.OatmealAmount,
                Manufacturer = kokoshaEntity.Manufacturer,
                HasChocolateChips = kokoshaEntity.HasChocolateChips,
                HasNuts = kokoshaEntity.HasNuts,
                IsVegan = kokoshaEntity.IsVegan
            };
        }
    }
}

