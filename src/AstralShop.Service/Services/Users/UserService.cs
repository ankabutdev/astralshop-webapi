using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Users;
using AstralShop.Domain.Exceptions.Users;
using AstralShop.Service.Common.Helpers;
using AstralShop.Service.DTOs.Users;
using AstralShop.Service.Interfaces.Common;
using AstralShop.Service.Interfaces.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstralShop.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork,
        IFileService fileService,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async Task<long> CountAsync()
        => await _unitOfWork.UserRepository.SelectAll().CountAsync();

    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        // checked user exists
        var existsUser = await _unitOfWork.UserRepository
            .SelectAsync(x => x.PhoneNumber == dto.PhoneNumber);

        // if user exists return exception
        if (existsUser is not null)
            throw new UserAlreadyExistsException();

        string imagePath;

        // if image is null, the default image is loaded
        // else dto image loaded
        if (dto.Image is null)
        {
            imagePath = await _fileService.UploadDefaultImage();
        }
        else
        {
            imagePath = await _fileService.UploadImageAsync(dto.Image);
        }

        var user = _mapper.Map<User>(dto);

        user.ImagePath = imagePath;
        user.CreatedAt = TimeHelper.GetDateTime();
        user.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveAsync();

        // ternary if
        return result is null ? false : true;
    }

    public Task<bool> DeleteAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync(PaginationParams @params)
    {
        var users = _unitOfWork.UserRepository.SelectAll();
        var paginationQuery = users
            .Skip(@params
            .GetSkipCount())
            .Take(@params.PageSize);

        var result = await paginationQuery.ToListAsync();

        return result;
    }

    public Task<User> GetByIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByPhoneNumberAsync(string number)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateImageAsync(long userId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
