using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Areas.Dashboard.Models.Db.Report;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Theraphosidae.Services
{
    public class ReportService : IReportService
    {

        private readonly TheraphosidaeContext _theraphosidaeContext;
        public ReportService(TheraphosidaeContext theraphosidaeContext)
        {
            _theraphosidaeContext = theraphosidaeContext;
        }

        public async Task<bool> Create(ReportModel report)
        {
            await _theraphosidaeContext.Reports.AddAsync(report);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var report = await _theraphosidaeContext.Reports.SingleOrDefaultAsync(i => i.Id == id);
            if(report == null)
            { 
                return false;
            }
            _theraphosidaeContext.Reports.Remove(report);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;

        }

        public async Task<ReportModel> Get(int id)
        {
            return await _theraphosidaeContext.Reports.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<ReportModel>> GetAll()
        {
            var reportsList = await _theraphosidaeContext.Reports.ToListAsync();

            return reportsList;
        }

        public Task<bool> IncrementReportViews(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ReportModel report)
        {
            _theraphosidaeContext.Reports.Update(report);
            return await _theraphosidaeContext.SaveChangesAsync() > 0;
        }
    }
}
