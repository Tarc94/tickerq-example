using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scheduler.Services.Users.Interfaces;
using TickerQ.Utilities.Base;

namespace Scheduler.Jobs
{
    public class UserOneOffImport
    {
        public const string JobName = "One off user import";
        private readonly IUserService _userService;

        public UserOneOffImport(IUserService userService)
        {
            _userService = userService;
        }

        [TickerFunction(functionName: JobName)]
        public async Task OneOffUserImportAsync()
        {
            Dictionary<string, string> entries = [];

            for (int i = 1; i <= 50; i++)
            {
                entries.Add($"User{i}", $"user{i}@test.com");
            }

            await _userService.BulkCreateUsersAsync(entries);
        }
    }
}
