using AppWithDatabase.Data.Models;
using AppWithDatabase.Services.Abstractions;

namespace AppWithDatabase;

public class App
{
    private readonly IService<Pet> _petService;
    private readonly IService<Breed> _breedService;
    private readonly IService<Location> _locationService;
    private readonly IService<Category> _categoryService;


    public App(IService<Pet> petService, 
        IService<Category> categoryService, 
        IService<Location> locationService, 
        IService<Breed> breedService)
    {
        _petService = petService;
        _categoryService = categoryService;
        _locationService = locationService;
        _breedService = breedService;
    }

    public async Task Start()
    {
        await _categoryService.AddRange(new List<Category>
        {
            new Category
            {
                CategoryName = "Cat"
            },
            new Category
            {
                CategoryName = "Dog"
            }
        });
        
        await _locationService.AddRange(new List<Location>
        {
            new Location
            {
                LocationName = "Ukraine"
            },
            new Location
            {
                LocationName = "England"
            },
            new Location
            {
                LocationName = "Austria"
            }
        });
        
        await _breedService.AddRange(new List<Breed>
        {
            new Breed
            {
                BreedName = "Manul cat",
                CategoryId = 1
            },
            new Breed
            {
                BreedName = "Deutsch Dog",
                CategoryId = 2
            },
            new Breed
            {
                BreedName = "Siam cat",
                CategoryId = 1
            }
        });

        await _petService.AddRange(new List<Pet>
        {
            new Pet
            {
                Description = "Dangerous cat",
                ImageUrl = "https://www.pinterest.com/pin/702491241902628904/",
                Age = 3,
                LocationId = 1,
                BreedId = 3,
                CategoryId = 1,
                Name = "Vasyl",
            },
            new Pet
            {
                Description = "Pretty but dangerous cat",
                ImageUrl = "https://www.pinterest.com/pin/702491241902628904/",
                Age = 4,
                LocationId = 1,
                BreedId = 3,
                CategoryId = 1,
                Name = "Kitty",
            },
            new Pet
            {
                Description = "Pretty but aggressive cat",
                ImageUrl = "https://www.pinterest.com/pin/702491241902628904/",
                Age = 1,
                LocationId = 3,
                BreedId = 5,
                CategoryId = 1,
                Name = "Tomas",
            },
            new Pet
            {
                Description = "Big dog",
                ImageUrl = "https://www.pinterest.com/pin/702491241902628904/",
                Age = 6,
                LocationId = 2,
                BreedId = 4,
                CategoryId = 2,
                Name = "Dustin",
            }
        });
        {
            await _petService.Update(2, new Pet
            {
                Description = "",
                LocationId = 2,
                CategoryId = 1,
                BreedId = 3,
                Age = 1,
                Name = "Dmytro",
                ImageUrl = ""
            });

            await _petService.Delete(2);

            var pets = await _petService.GetAll();
            Console.WriteLine(pets.Where(p => p.Age > 3 && p.Location.LocationName == "Ukraine")
                .GroupBy(p => p.Category.CategoryName)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    UniqueBreedCount = g.Select(p => p.Breed.BreedName).Distinct().Count()
                }));
        }
    }
}