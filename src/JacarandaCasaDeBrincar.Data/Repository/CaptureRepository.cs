using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class CaptureRepository : Repository<Capture>, ICaptureRepository
    {
        private readonly JacarandaDbContext _context;

        public CaptureRepository(JacarandaDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Capture>> GetAllWithAllIncluds(PaginationFilter paginationFilter, DateTime data)
        {
            return await _context.Captures
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .Where(c => DateTime.Compare(c.DateOfCapture.Date, data) <= 0)
                .Include(c => c.Campaign)
                .Include(c => c.FrequencyPackage)
                .Include(c => c.FrequencyPackage)
                .Include(c => c.HowDidYouknow)
                .Include(c => c.InitialContact)
                .Include(c => c.NextContact)
                .Include(c => c.InitialContact.ContactType)
                .Include(c => c.InitialContact.ResponsibleEmployee)
                .Include(c => c.NextContact.ContactType)
                .Include(c => c.NextContact.ResponsibleEmployee)
                .ToListAsync();
        }
    }
}
