using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    public class TestingServices
    {
        private readonly APDSContextDb _context;

        public TestingServices(APDSContextDb context)
        {
            _context = context;
        }
        public void AddTesting(Testing testing)
        {
            _context.Testings.Add(testing);
            _context.SaveChanges();
        }
        public void DeleteTesting(long id)
        {
            var testing = _context.Testings.Find(id);
            if (testing != null)
            {
                _context.Testings.Remove(testing);
                _context.SaveChanges();
            }
        }

        public List<Testing> GetTestingsByTest(long testId)
        {
            return _context.Testings
                .Include(t => t.Respondent)
                .Where(t => t.TestId == testId)
                .ToList();
        }

        public List<Testing> GetTestingsByRespondent(long respondentId)
        {
            return _context.Testings
                .Include(t => t.Test)
                .Where(t => t.RespondentId == respondentId)
                .ToList();
        }
    }
}
