using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Article;
using Theraphosidae.Context;

namespace Theraphosidae.Services.interfaces
{
    public interface ICommentService
    {
        Task<bool> Create(CommentModel comment, int articleId);
        Task<CommentModel> Get(int id);
        Task<List<CommentModel>> GetAll();
        Task<bool> Update(CommentModel comment);
        Task<int> Count();
        Task<bool> Delete(int id);

    }
}
