using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.DTOs.Images;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Service.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment env;
        private readonly string wwwroot;
        private const string imgFolder = "images";
        private const string articleImagesFolder = "article-images";
        private const string usersImagesFolder = "user-images";
        public ImageHelper(IWebHostEnvironment env) 
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                .Replace("ı", "i")
                .Replace("Ğ", "G")
                .Replace("ğ", "g")
                .Replace("Ü", "U")
                .Replace("ü", "u")
                .Replace("ş", "s")
                .Replace("Ş", "S")
                .Replace("Ö", "O")
                .Replace("ö", "o")
                .Replace("Ç", "C")
                .Replace("ç", "c")
                .Replace("é", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace("*", "")
                .Replace("æ", "")
                .Replace("ß", "")
                .Replace("@", "")
                .Replace("€", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("½", "")
                .Replace("{", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("}", "")
                .Replace(@"\", "")
                .Replace("|", "")
                .Replace("~", "")
                .Replace("¨", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace("`", "")
                .Replace(".", "")
                .Replace(":", "")
                .Replace(" ", "");
        }

        public async Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)//?
        {
            folderName ??= imageType == ImageType.User ? usersImagesFolder : articleImagesFolder;

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}")) //sorgula 
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}"); //yoksa oluştur

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);
            name = ReplaceInvalidChars(name);

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";

            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string message = imageType == ImageType.User
                ? $"{newFileName} isimli kullanıcı resmi başarılı bir şekilde eklenmiştir"
                : $"{newFileName} isimli makale resmi başarılı bir şekilde eklenmiştir.";

            return new ImageUploadedDTO()
            {
                Fullname = $"{folderName}/{newFileName}"
            };
        }
        public void Delete(string imageName)
        {
            var fileTodelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileTodelete))
                File.Delete(fileTodelete);
        }
    }
}
