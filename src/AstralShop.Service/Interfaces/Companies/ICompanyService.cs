using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Companies;
using AstralShop.Service.DTOs.Companies;

namespace AstralShop.Service.Interfaces.Companies;

public interface ICompanyService
{
    public Task<bool> CreateAsync(CompanyCreateDto dto);

    public Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto);

    public Task<bool> DeleteAsync(long companyId);

    public Task<Company> GetByIdAsync(long companyId);

    public Task<IEnumerable<Company>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();
}