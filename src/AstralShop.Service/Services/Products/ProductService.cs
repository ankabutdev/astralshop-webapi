﻿using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Products;
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

    public async Task<ProductResultDto> CreateAsync(ProductCreateDto dto)
    {
        var existingProduct = await _unitOfWork.ProductRepository
            .SelectAsync(x => x.Name == dto.Name);
        if (existingProduct != null)
            throw new ProductNotFoundException();

        string imagePath = await _fileService.UploadImageAsync(dto.ImagePath);

        var product = _mapper.Map<Product>(dto);

        product.ImagePath = imagePath;
        product.CreatedAt = TimeHelper.GetDateTime();

        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ProductResultDto>(product);
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

    public Task<IEnumerable<ProductResultDto>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResultDto> GetByIdAsync(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResultDto> UpdateAsync(ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateImageAsync(long productId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
