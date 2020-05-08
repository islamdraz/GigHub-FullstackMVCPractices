using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
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