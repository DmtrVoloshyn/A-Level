using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ILogger<CatalogTypeService> _logger;
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;
        
    public CatalogTypeService(
        ILogger<CatalogTypeService> logger, 
        ICatalogTypeRepository catalogTypeRepository, 
        IMapper mapper,
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper) 
        : base(dbContextWrapper, logger)
    {
        _logger = logger;
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CatalogTypeDto>> Get()
    {
        var result = await ExecuteSafeAsync(() => _catalogTypeRepository.GetAll());
        
        return  _mapper.Map<IEnumerable<CatalogTypeDto>>(result);    
    }

    public async Task<CatalogTypeDto> GetById(int id)
    {
        var result = await _catalogTypeRepository.GetById(id);

        return _mapper.Map<CatalogTypeDto>(result);
    }

    public Task<int?> Add(string type)
    {
        return _catalogTypeRepository.Create(new CatalogType {Type = type});    
    }

    public Task<CatalogTypeDto> Update(CatalogTypeDto type)
    {
        var result = ExecuteSafeAsync(() => _catalogTypeRepository
            .Update(_mapper.Map<CatalogType>(type)))
            .Result;
        
        return Task.Run(() => _mapper.Map<CatalogTypeDto>(result));
    }

    public Task<bool> Remove(int id)
    {
        return _catalogTypeRepository.Delete(id);
    }
}