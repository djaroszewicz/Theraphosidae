using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;
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

        public Task<MediaModel> AddFile(IFormFile file, ArticleModel article = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddMultipleFiles(List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddSpiderImage(List<IFormFile> files, int spiderId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFile(string publicationId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSpiderImage(string publicationId)
        {
            throw new NotImplementedException();
        }
    }
}
