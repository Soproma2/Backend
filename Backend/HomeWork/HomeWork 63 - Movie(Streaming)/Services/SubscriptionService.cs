using HomeWork_63___Movie_Streaming_.Data;
using HomeWork_63___Movie_Streaming_.Enums;
using HomeWork_63___Movie_Streaming_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Services
{
    internal class SubscriptionService
    {
        private readonly StreamingDbContext _context;

        public SubscriptionService(StreamingDbContext context) => _context = context;

        public async Task<Subscription> CreateSubscriptionAsync(
            SubscriptionPlan name, decimal monthlyPrice, int maxScreens, bool has4K)
        {
            var sub = new Subscription
            {
                Name = name,
                MonthlyPrice = monthlyPrice,
                MaxScreens = maxScreens,
                Has4K = has4K
            };
            _context.Subscriptions.Add(sub);
            await _context.SaveChangesAsync();
            return sub;
        }

        public async Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }
    }
}
