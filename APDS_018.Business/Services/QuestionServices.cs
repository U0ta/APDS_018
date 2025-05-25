using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    public class QuestionServices
    {
        private readonly APDSContextDb _context;

        public QuestionServices(APDSContextDb context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
        public void DeleteQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}
