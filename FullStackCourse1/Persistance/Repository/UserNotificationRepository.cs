﻿using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.Repository
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        IApplicationDbContext _context;
        public UserNotificationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetUserNotification(string userId)
        {
            return _context.UserNotifications.Where(p => p.UserId == userId).ToList();
        }
    }
}