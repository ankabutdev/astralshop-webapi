using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Products;
using AstralShop.Domain.Exceptions.Files;
using AstralShop.Domain.Exceptions.Products;
using AstralShop.Service.Common.Helpers;
using AstralShop.Service.DTOs.Products;
using AstralShop.Service.Interfaces.Common;
using AstralShop.Service.Interfaces.Products;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstralShop.Service.Services.Products;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public ProductService(IUnitOfWork unitOfWork,
        IMapper mapper, IFileService fileService)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync()
        => await _unitOfWork.ProductRepository.SelectAll().CountAsync();

    public async Task<bool> CreateAsync(ProductCreateDto dto)
    {
        var existingProduct = await _unitOfWork.ProductRepository
            .SelectAsync(x => x.Name == dto.Name);
        if (existingProduct != null)
            throw new ProductAlreadyExistsException();

        string imagePath = await _fileService.UploadImageAsync(dto.ImagePath);

        var product = _mapper.Map<Product>(dto);

        product.ImagePath = imagePath;
        product.CreatedAt = TimeHelper.GetDateTime();
        product.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.SaveAsync();

        // ternary if
        return result is null ? false : true;
    }

    public async Task<bool> DeleteAsync(long productId)
    {
        var product = await _unitOfWork.ProductRepository.
            SelectAsync(x => x.Id == productId);
        if (product is null)
            throw new ProductNotFoundException();

        var result = await _fileService.DeleteImageAsync(product.ImagePath);

        var dbResult = await _unitOfWork.ProductRepository.DeleteAsync(x => x == product);
        await _unitOfWork.SaveAsync();
        return dbResult;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params)
    {
        var products = _unitOfWork.ProductRepository.SelectAll();
        var paginationQuery = products
            .Skip(@params
            .GetSkipCount())
            .Take(@params.PageSize);

        var resultDto = await paginationQuery.ToListAsync();

        return resultDto;
    }

    public async Task<Product> GetByIdAsync(long productId)
    {
        var product = await _unitOfWork.ProductRepository
            .SelectAsync(x => x.Id == productId);

        if (product is null)
            throw new ProductNotFoundException();

        return product;
    }

    public async Task<bool> UpdateAsync(long productId, ProductUpdateDto dto)
    {
        var product = await _unitOfWork.ProductRepository
            .SelectAsync(x => x.Id == productId);

        if (product is null)
            throw new ProductNotFoundException();

        var productName = product.Name;
        var existingProduct = await _unitOfWork.ProductRepository
            .SelectAsync(x => x.Name == dto.Name);

        if (productName != dto.Name && existingProduct is not null)
            throw new ProductAlreadyExistsException();

        string newImagePath = product.ImagePath;

        if (dto.ImagePath is not null)
        {
            // Delete old image
            var deleteResult = await _fileService.DeleteImageAsync(product.ImagePath);

            if (!deleteResult)
                throw new ImageNotFoundException();

            // Upload new image
            newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);
        }
        // else product old image have to save

        _mapper.Map(dto, product);

        product.UpdatedAt = TimeHelper.GetDateTime();
        product.ImagePath = newImagePath;

        var result = await _unitOfWork.ProductRepository.UpdateAsync(product);
        await _unitOfWork.SaveAsync();

        return result is null ? false : true;
    }

    public async Task<bool> UpdateImageAsync(long productId, string imagePath)
    {
        var product = await _unitOfWork.ProductRepository
            .SelectAsync(x => x.Id == productId);
        if (product is null)
            throw new ProductNotFoundException();

        product.ImagePath = imagePath;
        await _unitOfWork.ProductRepository.UpdateAsync(product);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
