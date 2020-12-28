using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;

namespace Theraphosidae.Services.interfaces
{
    public interface IReportService
    {

        Task<bool> Create(ReportModel report);
        Task<ReportModel> Get(int id);
        Task<List<ReportModel>> GetAll();
        Task<bool> Update(ReportModel report);
        Task<bool> Delete(int id);
        Task<bool> IncrementReportViews(int id);
    }
}
