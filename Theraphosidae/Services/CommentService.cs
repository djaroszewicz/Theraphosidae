using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class CommentService : ICommentService
    {
        private readonly TheraphosidaeContext _theraphosidaeContext;

        public CommentService(TheraphosidaeContext theraphosidaeContext)
        {
            _theraphosidaeContext = theraphosidaeContext;
        }

        public async Task<int> Count()
        {
            var comments = await _theraphosidaeContext.Comments.ToListAsync();
            return comments.Count;
        }

        public async Task<bool> Create(CommentModel comment, int articleId)
        {
            comment.ArticleId = articleId;
            await _theraphosidaeContext.Comments.AddAsync(comment);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var comment = await _theraphosidaeContext.Comments.SingleOrDefaultAsync(b => b.Id == id);

            if (comment == null)
            {
                return false;
            }

            _theraphosidaeContext.Comments.Remove(comment);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<CommentModel> Get(int id)
        {
            return await _theraphosidaeContext.Comments.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<CommentModel>> GetAll()
        {
            var comments = await _theraphosidaeContext.Comments.ToListAsync();
            comments.Reverse();

            return comments;
        }

        public async Task<bool> Update(CommentModel comment)
        {
            _theraphosidaeContext.Comments.Update(comment);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }
    }
}
