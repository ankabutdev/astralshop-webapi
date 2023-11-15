using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Users;
using AstralShop.Service.DTOs.Users;

namespace AstralShop.Service.Interfaces.Users;

public interface IUserService
{
    public Task<UserUpdateDto> CreateAsync(UserCreateDto dto);

    public Task<UserUpdateDto> UpdateAsync(UserUpdateDto dto);

    public Task<bool> DeleteAsync(long userd);

    public Task<UserUpdateDto> GetByIdAsync(long userId);

    public Task<IEnumerable<User>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    public Task<bool> UpdateImageAsync(long userId, string imagePath);

    public Task<User> GetByPhoneNumberAsync(string number);
}
