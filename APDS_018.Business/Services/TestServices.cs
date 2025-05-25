using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    public class TestServices
    {
        private readonly APDSContextDb _context;

        public TestServices(APDSContextDb context)
        {
            _context = context; 
        }


        public List<Test> GetAllTests()
        {
            return _context.Tests
                .Include(t => t.Questions) 
                .ToList();                 
        }

        public Test? GetTestById(int id)
        {
            return _context.Tests
                .Include(t => t.Questions)
                .FirstOrDefault(t => t.Id == id);
        }

        public void AddTest(Test test)
        {
            _context.Tests.Add(test); 
            _context.SaveChanges();  
        }

        public void DeleteTest(int id)
        {
            var test = _context.Tests.Find(id);
            if (test != null)
            {
                _context.Tests.Remove(test);    
                _context.SaveChanges();
            }
        }

    }
}
