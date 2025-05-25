using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    internal class RespondentServices
    {
        private readonly APDSContextDb _context;

        public RespondentServices(APDSContextDb context)
        {
            _context = context;
        }



    }
}
