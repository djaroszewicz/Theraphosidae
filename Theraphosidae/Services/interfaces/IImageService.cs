using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Services.interfaces
{
    public interface IImageService 
    {
        Task<bool> Create(ImageModel spiderImage);
        Task<ImageModel> Get(string id);
        Task<List<ImageModel>> GetAll();
        Task<bool> Update(ImageModel spiderImage);
        Task<bool> Delete(string id);
    }
}
