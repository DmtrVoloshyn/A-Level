using AppWithDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace AppWithDatabase;

public class App
{
    private readonly AppDbContext _dbContext;

    public App(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Start()
    {
        var data = await _dbContext.Categories.ToListAsync();
    }
}