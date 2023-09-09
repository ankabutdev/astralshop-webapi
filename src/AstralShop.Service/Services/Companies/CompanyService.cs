using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Companies;
using AstralShop.Domain.Exceptions.Companies;
using AstralShop.Domain.Exceptions.Files;
using AstralShop.Domain.Exceptions.Products;
using AstralShop.Service.Common.Helpers;
using AstralShop.Service.DTOs.Companies;
using AstralShop.Service.Interfaces.Common;
using AstralShop.Service.Interfaces.Companies;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstralShop.Service.Services.Companies;

public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public CompanyService(IUnitOfWork unitOfWork,
        IMapper mapper, IFileService fileService)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync()
        => await _unitOfWork.CompanyRepository.SelectAll().CountAsync();

    public async Task<CompanyResultDto> CreateAsync(CompanyCreateDto dto)
    {
        var existingCompany = await _unitOfWork.CompanyRepository
            .SelectAsync(x => x.Name == dto.Name);
        if (existingCompany != null)
            throw new CompanyAlreadyExistsException();

        string imagePath = await _fileService.UploadImageAsync(dto.ImagePath);

        var company = _mapper.Map<Company>(dto);

        company.ImagePath = imagePath;
        company.CreatedAt = TimeHelper.GetDateTime();
        company.UpdatedAt = TimeHelper.GetDateTime();

        await _unitOfWork.CompanyRepository.AddAsync(company);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CompanyResultDto>(company);
    }

    public async Task<bool> DeleteAsync(long companyId)
    {
        var company = await _unitOfWork.CompanyRepository
            .SelectAsync(x => x.Id == companyId);
        if (company is null)
            throw new CompanyNotFoundException();

        var result = await _fileService.DeleteImageAsync(company.ImagePath);

        var dbResult = await _unitOfWork.CompanyRepository.DeleteAsync(x => x == company);
        await _unitOfWork.SaveAsync();
        return dbResult;
    }

    public async Task<IEnumerable<CompanyResultDto>> GetAllAsync(PaginationParams @params)
    {
        var companies = _unitOfWork.CompanyRepository.SelectAll();
        var paginationQuery = companies
            .Skip(@params
            .GetSkipCount())
            .Take(@params.PageSize);

        var resultDro = await paginationQuery.ToListAsync();

        return _mapper.Map<IEnumerable<CompanyResultDto>>(resultDro);
    }

    public async Task<CompanyResultDto> GetByIdAsync(long companyId)
    {
        var company = await _unitOfWork.CompanyRepository
            .SelectAsync(x => x.Id == companyId);
        if (company is null)
            throw new CompanyNotFoundException();

        return _mapper.Map<CompanyResultDto>(company);
    }

    public async Task<CompanyResultDto> UpdateAsync(CompanyUpdateDto dto)
    {
        var company = await _unitOfWork.CompanyRepository
            .SelectAsync(x => x.Id == dto.Id);
        if (company is null)
            throw new CompanyNotFoundException();

        var companyName = company.Name;
        var existingCompany = await _unitOfWork.CompanyRepository
            .SelectAsync(x => x.Name == dto.Name);

        if (companyName != dto.Name && existingCompany is not null)
            throw new ProductAlreadyExistsException();

        string newImagePath = company.ImagePath;

        if (dto.ImagePath is not null)
        {
            // Delete old image
            var deleteResult = await _fileService.DeleteImageAsync(company.ImagePath);

            if (!deleteResult)
                throw new ImageNotFoundException();

            // Upload new image
            newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);
        }
        // else company old image have to save

        _mapper.Map(dto, company);

        company.ImagePath = newImagePath;
        company.UpdatedAt = TimeHelper.GetDateTime();

        await _unitOfWork.CompanyRepository.UpdateAsync(company);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CompanyResultDto>(company);
    }
}
