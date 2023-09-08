using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Companies;
using AstralShop.Service.Interfaces.Companies;

namespace AstralShop.Service.Services.Companies;

public class CompanyService : ICompanyService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

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

    public Task<bool> UpdateImageAsync(long companyId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
