using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using MuRestful.Core;
using MuRestful.Core.Domains;

namespace MyRestful.Infrastructure
{
    public class MyContextSeed
    {
        public static async Task SeedAsync(MyContext myContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                if (!myContext.Countries.Any())
                {
                    myContext.AddRange(new List<Country>
                    {
                        new Country
                        {
                            EnglishName = "1",
                            ChineseName = "1",
                            Abbreviation = "1"
                        },
                        new Country
                        {
                            EnglishName = "2",
                            ChineseName = "2",
                            Abbreviation = "2"
                        },
                        new Country
                        {
                            EnglishName = "3",
                            ChineseName = "3",
                            Abbreviation = "3"
                        }
                    });
                    await myContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyContextSeed>();
                    logger.LogError(e.Message);
                    await SeedAsync(myContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
