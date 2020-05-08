using System.Collections.Generic;

using FullStackCourse1.Core.Models;

namespace FullStackCourse1.Core.IRepository
{
    public interface IAttendanceRepository
    {
        Attendence GetAttendance(int gigId, string userId);
        IEnumerable<Attendence> GetUserAttendances(string userId);

        void Add(Attendence attendance);

        void Remove(Attendence attendance);
    }
}