using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;

namespace Theraphosidae.Services.interfaces
{
    public interface IMediaService
    {
        Task<MediaModel> Get(string Id);
        Task<List<MediaModel>> GetAll();
        Task<bool> Update(MediaModel media);
        Task<int> MediaCount();
        Task<double> GetFilesSize();
    }
}
