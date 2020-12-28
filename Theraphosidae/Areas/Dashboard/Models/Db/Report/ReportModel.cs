using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Account;
using Theraphosidae.Areas.Dashboard.Models.Db.Spider;

namespace Theraphosidae.Areas.Dashboard.Models.Db.Report
{
    public class ReportModel
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DataType AddDate { get; set; }
        public int Views { get; set; }
        public string Title { get; set; }
        public string ReportCategory { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int SpiderId { get; set; }
        public SpiderModel Spider { get; set; }
        public ReportImageModel ReportImage { get; set; }

    }
}
