using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.Models;

namespace AppWithDatabase.Converters;

public static class ModelConverter
{
    public static BreedEntity ToEntity(this Breed breed)
    {
        return new BreedEntity
        {
            Id = breed.Id,
            BreedName = breed.BreedName,
            CategoryId = breed.CategoryId,
        };
    }
    
    public static LocationEntity ToEntity(this Location location)
    {
        return new LocationEntity
        {
            Id = location.Id,
            LocationName = location.LocationName,
        };
    }
    
    public static CategoryEntity ToEntity(this Category category)
    {
        return new CategoryEntity
        {
            Id = category.Id,
            CategoryName = category.CategoryName,
        };
    }
    
    public static PetEntity ToEntity(this Pet pet)
    {
        return new PetEntity
        {
            Id = pet.Id,
            Description = pet.Description,
            CategoryId = pet.CategoryId,
            Age = pet.Age,
            Name = pet.Name,
            BreedId = pet.BreedId,
            ImageUrl = pet.ImageUrl,
            LocationId = pet.LocationId,
        };
    }
    
    public static Breed ToModel(this BreedEntity breedEntity)
    {
        return new Breed
        {
            Id = breedEntity.Id,
            BreedName = breedEntity.BreedName,
        };
    }
        
    public static Location ToModel(this LocationEntity locationEntity)
    {
        return new Location
        {
            Id = locationEntity.Id,
            LocationName = locationEntity.LocationName,
        };
    }
        
    public static Category ToModel(this CategoryEntity categoryEntity)
    {
        return new Category
        {
            Id = categoryEntity.Id,
            CategoryName = categoryEntity.CategoryName,
        };
    }
        
    public static Pet ToModel(this PetEntity petEntity)
    {
        return new Pet
        {
            CategoryId = petEntity.CategoryId,
            Description = petEntity.Description,
            Age = petEntity.Age,
            Name = petEntity.Name,
            BreedId = petEntity.BreedId,
            ImageUrl = petEntity.ImageUrl,
            LocationId = petEntity.LocationId,
            Category = petEntity.Category.ToModel(),
            Location = petEntity.Location.ToModel(),
            Breed = petEntity.Breed.ToModel(),
        };
    }
    
    public static List<Pet> ToModelList(this List<PetEntity> petEntities)
    {
        return  petEntities.Select(x => x.ToModel()).ToList();
    }
    
    public static List<PetEntity> ToEntityList(this List<Pet> pets)
    {
        return  pets.Select(x => x.ToEntity()).ToList();
    }
    
    public static List<Breed> ToModelList(this List<BreedEntity> breedEntities)
    {
        return breedEntities.Select(x => x.ToModel()).ToList();
    }

    public static List<Location> ToModelList(this List<LocationEntity> locationEntities)
    {
        return locationEntities.Select(x => x.ToModel()).ToList();
    }

    public static List<Category> ToModelList(this List<CategoryEntity> categoryEntities)
    {
        return categoryEntities.Select(x => x.ToModel()).ToList();
    }

    public static List<BreedEntity> ToEntityList(this List<Breed> breeds)
    {
        return breeds.Select(x => x.ToEntity()).ToList();
    }

    public static List<LocationEntity> ToEntityList(this List<Location> locations)
    {
        return locations.Select(x => x.ToEntity()).ToList();
    }

    public static List<CategoryEntity> ToEntityList(this List<Category> categories)
    {
        return categories.Select(x => x.ToEntity()).ToList();
    }

}