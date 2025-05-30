using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    public class ResultServices
    {
        private readonly APDSContextDb _context;

        public ResultServices(APDSContextDb context)
        {
            _context = context;
        }
        public void AddResult(Result result)
        {
            _context.Results.Add(result);
            _context.SaveChanges();
        }
        public void DeleteResult(long id)
        {
            var result = _context.Results.Find(id);
            if (result != null)
            {
                _context.Results.Remove(result);
                _context.SaveChanges();
            }
        }
        public List<Result> GetResultsByTesting(long testingId)
        {
            return _context.Results
                .Include(r => r.ParamResult)
                .Where(r => r.TestingId == testingId)
                .ToList();
        }

    }
}
