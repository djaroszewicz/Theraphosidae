using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theraphosidae.Context;
using Theraphosidae.Services.interfaces;

namespace Theraphosidae.Services
{
    public class HomeService : IHomeService
    {
        private readonly TheraphosidaeContext _context;

        public HomeService(TheraphosidaeContext context)
        {
            _context = context;
        }
    }
}
