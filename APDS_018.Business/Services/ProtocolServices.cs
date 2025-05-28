using APDS_018.Data;
using APDS_018.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APDS_018.Business.Services
{
    public class ProtocolServices
    {
        private readonly APDSContextDb _context;

        public ProtocolServices(APDSContextDb context)
        {
            _context = context;
        }
        public void AddProtocol(Protocol protocol)
        {
            _context.Protocols.Add(protocol);
            _context.SaveChanges();
        }
        public void DeleteProtocol(long id)
        {
            var protocol = _context.Protocols.Find(id);
            if (protocol != null)
            {
                _context.Protocols.Remove(protocol);
                _context.SaveChanges();
            }
        }
    }
}