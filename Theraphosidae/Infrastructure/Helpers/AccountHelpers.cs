using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.View.Account;

namespace Theraphosidae.Infrastructure.Helpers
{
    public class AccountHelpers
    {
        public static User ConvertToModel(UserView result)
        {
            var userModel = new User
            {
                Id = result.Id,
                UserName = result.UserName,
                Email = result.Email
            };

            return userModel;
        }

        public static UserView ConvertToView(User result)
        {
            var userView = new UserView
            {
                Id = result.Id,
                UserName = result.UserName,
                Email = result.Email
            };
            return userView;
        }

        public static User MergeViewWithModel(User model, UserView view)
        {
            model.UserName = view.UserName;
            model.Email = view.Email;

            return model;
        }
    }
}
