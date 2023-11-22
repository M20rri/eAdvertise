using eAdvertise.Application.Interfaces;
using System;

namespace eAdvertise.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}