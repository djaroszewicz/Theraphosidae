using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Areas.Dashboard.Models.View.Report
{
    public class ReportView
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime AddDate { get; set; }
        public int Views { get; set; }
        public string Title { get; set; }
        public string ReportCategory { get; set; }
        public string ImageUrl { get; set; }
        public User User { get; set; }
        public SpiderModel Spider { get; set; }
        public ReportImageModel ReportImage { get; set; }
    }
}
