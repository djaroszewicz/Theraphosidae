using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class ImageService : IImageService
    {
        private readonly TheraphosidaeContext _theraphosidaeContext;

        public ImageService (TheraphosidaeContext theraphosidaeContext)
        {
            _theraphosidaeContext = theraphosidaeContext;
        }

        public async Task<bool> Create(ImageModel spiderImage)
        {
            await _theraphosidaeContext.Images.AddAsync(spiderImage);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var spiderImage = await _theraphosidaeContext.Images.SingleOrDefaultAsync(i => i.Id == id);

            if(spiderImage == null)
            {
                return false;
            }

            _theraphosidaeContext.Images.Remove(spiderImage);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;

        }

        public async Task<ImageModel> Get(string id)
        {
            return await _theraphosidaeContext.Images.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<ImageModel>> GetAll()
        {
            return await _theraphosidaeContext.Images.ToListAsync();
        }

        public async Task<bool> Update(ImageModel spiderImage)
        {
            _theraphosidaeContext.Images.Update(spiderImage);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }





        public async Task<bool> CreateReportImage(ReportImageModel reportImage)
        {
            await _theraphosidaeContext.ReportImages.AddAsync(reportImage);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReportImage(string id)
        {
            var reportImage = await _theraphosidaeContext.ReportImages.SingleOrDefaultAsync(i => i.Id == id);

            if (reportImage == null)
            {
                return false;
            }

            _theraphosidaeContext.ReportImages.Remove(reportImage);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;

        }

        public async Task<ReportImageModel> GetReportImage(string id)
        {
            return await _theraphosidaeContext.ReportImages.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<ReportImageModel>> GetAllReportImages()
        {
            return await _theraphosidaeContext.ReportImages.ToListAsync();
        }

        public async Task<bool> Update(ReportImageModel reportImage)
        {
            _theraphosidaeContext.ReportImages.Update(reportImage);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }
    }
}
