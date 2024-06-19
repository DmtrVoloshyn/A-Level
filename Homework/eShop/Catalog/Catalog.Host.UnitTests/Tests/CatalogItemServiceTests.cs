using System.Data;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace UnitTests.Tests;

public class CatalogItemServiceTest
{
    private readonly ICatalogItemService _catalogService;
    private readonly Mock<ICatalogItemRepository> _catalogItemRepositoryMock;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;
    private readonly Fixture _fixture;
    private readonly Mock<IMapper> _mapper;

    public CatalogItemServiceTest()
    {
        _fixture = new();
        _catalogItemRepositoryMock = new Mock<ICatalogItemRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper
            .Setup(s => s.BeginTransactionAsync(CancellationToken.None))
            .ReturnsAsync(dbContextTransaction.Object);

        _catalogService = new CatalogItemService(
            _dbContextWrapper.Object,
            _logger.Object,
            _catalogItemRepositoryMock.Object,
            _mapper.Object);
    }

    [Fact]
    public async Task Add_ShouldReturnInt_WhenCreationSuccess()
    {
        // arrange
        var expected = 1;

        _catalogItemRepositoryMock
            .Setup(s => s.Create(It.IsAny<CatalogItem>())).ReturnsAsync(expected);

        // act
        var result = await _catalogService.Add(_fixture.Create<CreateItemRequest>());

        // assert
        result.Should().Be(expected);
    }

    [Fact]
    public async Task Add_ShouldReturnNull_WhenCreationFails()
    {
        // arrange
        int? expected = null;

        _catalogItemRepositoryMock
            .Setup(s => s.Create(It.IsAny<CatalogItem>())).ReturnsAsync(expected);

        // act
        var result = await _catalogService.Add(_fixture.Create<CreateItemRequest>());

        // assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(null, null)]
    [InlineData(null, "T-shirt")]
    [InlineData(".NET", null)]
    [InlineData(".NET", "T-shirt")]
    public async Task GetByPage_ShouldReturnPaginatedListAndNotBeNull_WhenSuccess(string? brand, string? type)
    {
        // arrange
        var totalCount = 10;
        var allCatalogItems = _fixture.CreateMany<CatalogItem>(totalCount).ToList();
        var filteredCatalogItems = allCatalogItems.AsQueryable();
    
        if (brand != null)
        {
            filteredCatalogItems = filteredCatalogItems.Where(i => i.CatalogBrand.Brand == brand);
        }
        if (type != null)
        {
            filteredCatalogItems = filteredCatalogItems.Where(i => i.CatalogType.Type == type);
        }
    
        var resultItems = filteredCatalogItems.ToList();
        var catalogResult = new PaginatedItems<CatalogItem>
        {
            TotalCount = resultItems.Count,
            Data = resultItems
        };
    
        var catalogItemDtos = _fixture.CreateMany<CatalogItemDto>(resultItems.Count).ToList();
        var expected = new PaginatedItems<CatalogItemDto>
        {
            TotalCount = catalogResult.TotalCount,
            Data = catalogItemDtos
        };
    
        _catalogItemRepositoryMock
            .Setup(s => s
                .GetByPage(
                    It.Is<string?>(x => x == brand),
                    It.Is<string?>(x => x == type),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
            .ReturnsAsync(catalogResult);
    
        _mapper.Setup(m => m.Map<IEnumerable<CatalogItemDto>>(catalogResult.Data)).Returns(catalogItemDtos);
    
        // act
        var actual = await _catalogService.Get(
            _fixture.Create<int>(),
            _fixture.Create<int>(),
            brand,
            type);
    
        // assert
        actual.Should().NotBeNull();
        actual.Should()
            .BeEquivalentTo(expected,
                o => o.ComparingByMembers<PaginatedItems<CatalogItemDto>>()); 
    }

    [Fact]
    public async Task GetById_ShouldReturnCatalogItem_WhenSuccess()
    {
        // arrange
        var catalogRequest = 1;

        var catalogResult = _fixture.Build<CatalogItem>().With(x => x.Id, catalogRequest).Create();
        var expected = _fixture.Build<CatalogItemDto>().With(x => x.Id, catalogRequest).Create();
    
        _catalogItemRepositoryMock
        .Setup(s => s.GetById(catalogRequest))
        .ReturnsAsync(catalogResult);
        
        _mapper.Setup(m => m.Map<CatalogItemDto>(catalogResult)).Returns(expected);
    
        // act
        var actual = await _catalogService.GetById(catalogRequest);

        // assert
        actual.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<CatalogItemDto>());
        _mapper.Verify(m => m.Map<CatalogItemDto>(catalogResult), Times.Once);
    }   
    
    [Fact]
    public async Task GetById_ShouldReturnNull_WhenFails()
    {
        // arrange
        var catalogRequest = 1;

        CatalogItem catalogResult = null!;
    
        _catalogItemRepositoryMock
            .Setup(s => s.GetById(catalogRequest))
            .ReturnsAsync(catalogResult);
        
        // act
        var actual = await _catalogService.GetById(catalogRequest);

        // assert
        actual.Should().BeNull();
        _mapper.Verify(m => m.Map<CatalogItemDto>(catalogResult), Times.Once);
    }

    [Fact]
    public async Task Add_ShouldReturnId_WhenSuccess()
    {
        // arrange
        var catalogRequest = _fixture.Create<CreateItemRequest>();
        var expected = _fixture.Build<CatalogItem>()
            .With(x => x.Id, _fixture.Create<int>())
            .With(x => x.Name, catalogRequest.Name)
            .With(x => x.Description, catalogRequest.Description)
            .With(x => x.CatalogTypeId, catalogRequest.CatalogTypeId)
            .With(x => x.CatalogBrandId, catalogRequest.CatalogBrandId)
            .With(x => x.PictureFileName, catalogRequest.PictureFileName)
            .With(x => x.Price, catalogRequest.Price)
            .Create();
            
        _catalogItemRepositoryMock
            .Setup(s => s
                .Create(It.IsAny<CatalogItem>()))
            .ReturnsAsync(expected.Id);
        
        // act
        var actual = await _catalogService.Add(catalogRequest);

        // assert
        actual.Should().NotBeNull();
        actual.Should().Be(expected.Id);
    }
    
    [Fact]
    public async Task Add_ShouldReturnNull_WhenFails()
    {
        // arrange
        var catalogRequest = _fixture.Build<CreateItemRequest>()
            .Without(x => x.Name).Create();

        int? expected = null;
    
        _catalogItemRepositoryMock
            .Setup(s => s.Create(It.IsAny<CatalogItem>()))
            .ReturnsAsync(expected);

        // act
        var actual = await _catalogService.Add(catalogRequest);

        // assert
        actual.Should().BeNull();
    }
    
    [Fact]
    public async Task Update_ShouldReturnCatalogItemDto_WhenSuccess()
    {
        // arrange
        var updateItemRequest = _fixture.Create<UpdateItemRequest>();
        var catalogResponse = _fixture.Build<CatalogItem>()
            .With(x => x.Id, updateItemRequest.Id)
            .With(x => x.Name, updateItemRequest.Name)
            .With(x => x.Description, updateItemRequest.Description)
            .With(x => x.Price, updateItemRequest.Price)
            .Create();
        
        var expected = _fixture.Build<CatalogItemDto>()
            .With(x => x.Id, updateItemRequest.Id)
            .With(x => x.Name, updateItemRequest.Name)
            .With(x => x.Description, updateItemRequest.Description)
            .With(x => x.Price, updateItemRequest.Price)
            .Create();
        
        _catalogItemRepositoryMock
            .Setup(s => s.GetById(updateItemRequest.Id))
            .ReturnsAsync(catalogResponse);
            
        _catalogItemRepositoryMock
            .Setup(s => s
                .Update(It.IsAny<CatalogItem>()))
            .ReturnsAsync(catalogResponse);

        _mapper.Setup(m => m.Map<CatalogItemDto>(catalogResponse)).Returns(expected);
        
        // act
        var actual = await _catalogService.Update(updateItemRequest);

        // assert
        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected, options => options.ComparingByMembers<CatalogItemDto>());
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenItemNotFound()
    {
        // arrange
        var updateItemRequest = _fixture.Create<UpdateItemRequest>();
        CatalogItem? catalogItem = null; 
        
        _catalogItemRepositoryMock
            .Setup(s => s.GetById(updateItemRequest.Id))
            .ReturnsAsync(catalogItem);
        
        // act & assert
        await Assert.ThrowsAsync<InvalidExpressionException>(async () => await _catalogService.Update(updateItemRequest));
    }
    
    [Fact]
    public async Task Remove_ShouldReturnTrue_WhenItemDeletedSuccessfully()
    {
        // arrange
        var itemIdToDelete = 123; 

        _catalogItemRepositoryMock
            .Setup(s => s.Delete(itemIdToDelete))
            .ReturnsAsync(true); 
    
        // act
        var result = await _catalogService.Remove(itemIdToDelete);

        // assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task Remove_ShouldReturnFalse_WhenItemNotDeleted()
    {
        // arrange
        var itemIdToDelete = 123;

        _catalogItemRepositoryMock
            .Setup(s => s.Delete(itemIdToDelete))
            .ReturnsAsync(false);
    
        // act
        var result = await _catalogService.Remove(itemIdToDelete);

        // assert
        result.Should().BeFalse();
    }
}