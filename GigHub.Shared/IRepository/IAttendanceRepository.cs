using System.Collections.Generic;
using GigHub.Model.Models;

namespace GigHub.Shared.IRepository
{
    public interface IAttendanceRepository
    {
        Attendence GetAttendance(int gigId, string userId);
        IEnumerable<Attendence> GetUserAttendances(string userId);

        void Add(Attendence attendance);

        void Remove(Attendence attendance);
    }
}