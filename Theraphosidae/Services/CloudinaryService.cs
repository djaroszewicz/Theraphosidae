using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Context;
using Theraphosidae.Infrastructure.Settings;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class CloudinaryService : ICloudinaryService
    {

        private readonly Cloudinary _cloudinary;
        private readonly TheraphosidaeContext _context;

        public CloudinaryService(IOptions<CloudinarySettings> config, TheraphosidaeContext context)
        {
            if (config.Value.CloudName != null && config.Value.ApiKey != null && config.Value.ApiKey != null)
            {
                var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
                _cloudinary = new Cloudinary(account);
            }

            _context = context;
        }

        private double ConvertBytesToMegabytes(double bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        private ImageUploadResult UploadToCloudinary(IFormFile file)
        {
            if(_cloudinary != null)
            {
                var uploadResult = new ImageUploadResult();

                if (file != null && file.Length > 0)
                {
                    using (var streamFile = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.FileName, streamFile)
                        };

                        if(file.ContentType.Contains("image"))
                        {
                            uploadParams.Transformation = new Transformation().Width(1000);
                        }

                        uploadResult = _cloudinary.Upload(uploadParams);
                    }

                    if (uploadResult.Error == null)
                    {
                        return uploadResult;
                    }
                }
            }

            return null;
        }

        private async Task<MediaModel> SaveToDatabase(ImageUploadResult uploadResult, string fileNameLong, ArticleModel article = null)
        {
            var fileName = Path.GetFileNameWithoutExtension(fileNameLong);

            var medium = new MediaModel
            {
                Id = uploadResult.PublicId,
                Url = uploadResult.SecureUri.AbsoluteUri,
                Name = fileName,
                Description = fileName,
                Type = uploadResult.Format,
                Article = article,
                Length = ConvertBytesToMegabytes(uploadResult.Length)
            };

            await _context.Medias.AddAsync(medium);
            await _context.SaveChangesAsync();

            return medium;
        }

        private async Task<ImageModel> SaveSpiderImage(ImageUploadResult uploadResult, string fileNameLong, int SpiderId)
        {
            var fileName = Path.GetFileNameWithoutExtension(fileNameLong);

            var image = new ImageModel
            {
                Id = uploadResult.PublicId,
                Url = uploadResult.SecureUri.AbsoluteUri,
                Name = fileName,
                Description = fileName,
                SpiderId = SpiderId
            };

            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();

            return image;
        }

        public async Task<MediaModel> AddFile(IFormFile file, ArticleModel article = null)
        {
            var uploadResult = UploadToCloudinary(file);
            if(uploadResult != null)
            {
                return await SaveToDatabase(uploadResult, file.FileName, article);
            }

            return null;
        }

        public async Task<bool> AddMultipleFiles(List<IFormFile> files)
        {
            bool status = true;
            foreach (var file in files)
            {
                var uploadResult = UploadToCloudinary(file);
                if (uploadResult != null)
                {
                    await SaveToDatabase(uploadResult, file.FileName);
                }
            }

            return status;
        }

        public async Task<bool> AddSpiderImage(List<IFormFile> files, int spiderId)
        {
            bool status = true;
            foreach (var file in files)
            {
                var uploadResult = UploadToCloudinary(file);
                if (uploadResult != null)
                {
                    await SaveSpiderImage(uploadResult, file.FileName, spiderId);
                }
            }

            return status;
        }

        public bool DeleteFile(string publicationId)
        {
            if(_cloudinary != null)
            {
                var deleteParams = new DeletionParams(publicationId);
                var result = _cloudinary.Destroy(deleteParams);

                if(result.Result == "ok")
                {
                    var toRemove = _context.Medias.Find(publicationId);
                    _context.Medias.Remove(toRemove);

                    return _context.SaveChanges() > 0;
                }
            }

            return false;
        }

        public bool DeleteSpiderImage(string publicationId)
        {
            if(_cloudinary != null)
            {
                var deleteParams = new DeletionParams(publicationId);
                var result = _cloudinary.Destroy(deleteParams);

                if(result.Result == "ok")
                {
                    var toRemove = _context.Images.Find(publicationId);
                    _context.Images.Remove(toRemove);

                    return _context.SaveChanges() > 0;
                }
            }

            return false;
        }
    }
}
