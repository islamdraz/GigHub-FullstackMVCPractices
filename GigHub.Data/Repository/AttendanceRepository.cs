using System.Collections.Generic;
using System.Linq;
using GigHub.Model.Models;
using GigHub.Shared.IRepository;

namespace GigHub.Data.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        IApplicationDbContext _context;
        public AttendanceRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Attendence attendance)
        {
            _context.Attendences.Add(attendance);
        }

        public Attendence GetAttendance(int gigId,string userId)
        {
            return _context.Attendences.SingleOrDefault(p =>p.GigId==gigId&& p.AttendeeId == userId);
        }

        public IEnumerable<Attendence> GetUserAttendances(string userId)
        {
            return _context.Attendences
                .Where(p => p.AttendeeId == userId)
                .ToList();
        }

        public void Remove(Attendence attendance)
        {
            _context.Attendences.Remove(attendance);
        }
    }
}