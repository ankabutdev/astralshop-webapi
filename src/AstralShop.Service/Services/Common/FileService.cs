using AstralShop.Service.Common.Helpers;
using AstralShop.Service.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AstralShop.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string AVATAR = "avatar";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }

    public Task<bool> DeleteAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newImageName = MediaHelper.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }
}
