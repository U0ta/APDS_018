using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    public class RespondentServices
    {
        private readonly APDSContextDb _context;

        public RespondentServices(APDSContextDb context)
        {
            _context = context;
        }

        public void AddRespondent(Respondent respondent)
        {
            _context.Respondents.Add(respondent);
            _context.SaveChanges();
        }
        public void DeleteRespondent(long id)
        {
            var respondent = _context.Respondents.Find(id);
            if (respondent != null)
            {
                _context.Respondents.Remove(respondent);
                _context.SaveChanges();
            }
        }
        public void UpdateRespondent(Respondent respondent)
        {
            var existingRespondent = _context.Respondents.Find(respondent.Id);
            if (existingRespondent != null)
            {
                _context.Entry(existingRespondent).CurrentValues.SetValues(respondent);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Respondent not found");
            }
        }

    }
}
