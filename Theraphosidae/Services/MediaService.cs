using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Media;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class MediaService : IMediaService
    {
        private readonly TheraphosidaeContext _context;

        public MediaService(TheraphosidaeContext context)
        {
            _context = context;
        }

        public async Task<MediaModel> Get(string Id)
        {
            return await _context.Medias.Include(a => a.Article).SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<MediaModel>> GetAll()
        {
            return await _context.Medias.Include(a => a.Article).ToListAsync();
        }

        public async Task<double> GetFilesSize()
        {
            var size = await _context.Medias.SumAsync(x => x.Length);
            return Math.Ceiling(size / 2000);
        }

        public async Task<int> MediaCount()
        {
            var medias = await _context.Medias.ToListAsync();
            return medias.Count();
        }

        public async Task<bool> Update(MediaModel media)
        {
            _context.Medias.Update(media);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
