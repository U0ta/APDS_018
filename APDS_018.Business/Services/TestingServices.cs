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
    }
}
