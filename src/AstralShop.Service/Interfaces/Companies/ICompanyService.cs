using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Companies;

namespace AstralShop.Service.Interfaces.Companies;

public interface ICompanyService
{
    public Task<CompanyResultDto> CreateAsync(CompanyCreateDto dto);

    public Task<CompanyResultDto> UpdateAsync(CompanyUpdateDto dto);

    public Task<bool> DeleteAsync(long companyId);

    public Task<CompanyResultDto> GetByIdAsync(long companyId);

    public Task<IEnumerable<CompanyResultDto>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();
}