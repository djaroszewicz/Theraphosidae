using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theraphosidae.Areas.Dashboard.Models.Db.Report
{
    public class ReportImageModel
    {
        [Key]
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int ReportId { get; set; }
        public ReportModel Report { get; set; }
    }
}

