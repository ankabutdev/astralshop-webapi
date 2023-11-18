using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Users;
using AstralShop.Service.DTOs.Users;

namespace AstralShop.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> CreateAsync(UserCreateDto dto);

    public Task<bool> UpdateAsync(UserUpdateDto dto);

    public Task<bool> DeleteAsync(long userd);

    public Task<User> GetByIdAsync(long userId);

    public Task<IEnumerable<User>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    public Task<bool> UpdateImageAsync(long userId, string imagePath);

    public Task<User> GetByPhoneNumberAsync(string number);
}
