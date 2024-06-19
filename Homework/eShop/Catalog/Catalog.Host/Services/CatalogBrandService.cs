using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ILogger<CatalogBrandService> _logger;
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        ICatalogBrandRepository catalogBrandRepository, 
        ILogger<CatalogBrandService> logger, 
        IMapper mapper,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper) 
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CatalogBrandDto>> Get()
    {
        var result = await ExecuteSafeAsync(() => _catalogBrandRepository.GetAll());
        
        return  _mapper.Map<IEnumerable<CatalogBrandDto>>(result);
    }

    public async Task<CatalogBrandDto> GetById(int id)
    {
        var result = await _catalogBrandRepository.GetById(id);

        return _mapper.Map<CatalogBrandDto>(result);
    }

    public Task<int?> Add(string brand)
    {
        return _catalogBrandRepository.Create(new CatalogBrand {Brand = brand});
    }


    public Task<CatalogBrandDto> Update(CatalogBrandDto brand)
    {
        var result = ExecuteSafeAsync(() => _catalogBrandRepository
            .Update(_mapper.Map<CatalogBrand>(brand)))
            .Result;
        return Task.Run(() => _mapper.Map<CatalogBrandDto>(result));
    }

    public Task<bool> Remove(int id)
    {
        return _catalogBrandRepository.Delete(id);
    }
}