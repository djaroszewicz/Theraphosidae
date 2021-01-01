using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;

namespace Theraphosidae.Services.interfaces
{
    public interface ICloudinaryService
    {
        Task<MediaModel> AddFile(IFormFile file, ArticleModel article = null);
        Task<bool> AddMultipleFiles(List<IFormFile> files);
        bool DeleteFile(string publicationId);

        Task<bool> AddSpiderImage(IFormFile files, int spiderId);
        bool DeleteSpiderImage(string publicationId);

        Task<bool> AddReportImage(IFormFile files, int reportId);
        bool DeleteReportImage(string reportId);
    }
}
