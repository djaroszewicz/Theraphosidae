using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;
using Theraphosidae.Areas.Dashboard.Models.View.Report;

namespace Theraphosidae.Infrastructure.Helpers
{
    public static class ReportHelpers
    {

        public static ReportModel ConvertToModel(ReportView report, User user)
        {
            var reportModel = new ReportModel
            {
                Content = report.Content,
                AddDate = DateTime.Now,
                Title = report.Title,
                ReportCategory = report.ReportCategory,
                SpiderId = report.SpiderId,
                User = user
            };

            return reportModel;
        }

        public static ReportView ConvertToView(ReportModel report)
        {
            var reportView = new ReportView
            {
                Id = report.Id,
                Content = report.Content,
                Title = report.Title,
                ReportCategory = report.ReportCategory,
                User = report.User,
                Spider = report.Spider,
                AddDate = report.AddDate
                
                
            };

            if(report.ReportImage == null)
            {
                reportView.ImageUrl = "/images/img-plcaeholder.png";
            }
            else
            {
                reportView.ImageUrl = report.ReportImage.Url;
            }

            return reportView;
        }

        public static ReportModel MergeViewWithModel(ReportModel model, ReportView view)
        {
            model.Content = view.Content;
            model.Title = view.Title;
            model.ReportCategory = view.ReportCategory;

            return model;
        }

    }
}
