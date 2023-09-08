using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Utils;
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

    public Task<CompanyResultDto> CreateAsync(CompanyCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long companyId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CompanyResultDto>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyResultDto> GetByIdAsync(long companyId)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyResultDto> UpdateAsync(CompanyUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
