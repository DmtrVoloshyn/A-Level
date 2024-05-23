using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository, IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string? pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Create(name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
    }

    public async Task<CatalogItemDto> GetById(int id)
    {
        var item = await ExecuteSafeAsync(() => _catalogItemRepository.GetById(id));

        return _mapper.Map<CatalogItemDto>(item);
    }

    public async Task<PaginatedItems<CatalogItemDto>> Get(int pageSize, int pageIndex, string? brandTitle, string? typeTitle)
    {
        var items = await ExecuteSafeAsync(() =>
            _catalogItemRepository.GetByPage(brandTitle, typeTitle, pageIndex, pageSize));
        var itemDtos = _mapper.Map<IEnumerable<CatalogItemDto>>(items.Data);

        return new PaginatedItems<CatalogItemDto>
        {
            TotalCount = items.TotalCount,
            Data = itemDtos
        };
    }

    public Task<int> UpdateItem(
        int id, 
        string name, 
        string description, 
        decimal price, 
        int availableStock, 
        int catalogBrandId,
        int catalogTypeId, 
        string? pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Update(
            id, 
            name, 
            description, 
            price, 
            availableStock, 
            catalogBrandId, 
            catalogTypeId, 
            pictureFileName));
    }

    public Task<bool> DeleteItem(int id)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Delete(id));
    }
}