using System.Data;
using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository, 
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public Task<int?> Add(CreateItemRequest request)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Create(_mapper.Map<CatalogItem>(request)));
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

        return new PaginatedItems<CatalogItemDto>
        {
            TotalCount = items.TotalCount,
            Data = _mapper.Map<IEnumerable<CatalogItemDto>>(items.Data)
        };
    }

    public async Task<CatalogItemDto> Update(UpdateItemRequest request)
    {
        var item = await _catalogItemRepository.GetById(request.Id);
        
        if (item is not null)
        {
            var catalogItem = new CatalogItem()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            catalogItem = ExecuteSafeAsync(() => _catalogItemRepository.Update(catalogItem)).Result;
            return _mapper.Map<CatalogItemDto>(catalogItem);
        }

        throw new InvalidExpressionException($"Item with id {request.Id} not found");
    }

    public Task<bool> Remove(int id)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Delete(id));
    }
}