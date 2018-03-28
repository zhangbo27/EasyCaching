﻿namespace EasyCaching.Demo.Interceptor.AspectCore.Services
{
    using EasyCaching.Core.Internal;
    using System.Threading.Tasks;
    
    public interface IDateTimeService : EasyCaching.Core.Internal.IEasyCaching
    {
        [EasyCachingAble(Expiration = 10)]
        string GetCurrentUtcTime();

        [EasyCachingPut(CacheKeyPrefix = "AspectCore")]
        string PutSomething(string str);

        [EasyCachingEvict(IsBefore = true)]
        void DeleteSomething(int id);

        [EasyCachingAble(Expiration = 10)]
        Task<string> GetUtcTimeAsync();
    }

    public class DateTimeService : IDateTimeService
    {
        public void DeleteSomething(int id)
        {
            System.Console.WriteLine("Handle delete something..");
        }

        public string GetCurrentUtcTime()
        {
            return System.DateTime.UtcNow.ToString();
        }

        public async Task<string> GetUtcTimeAsync()
        {
            return await Task.FromResult<string>(System.DateTimeOffset.UtcNow.ToString());
        }

        public string PutSomething(string str)
        {
            return str;
        }
    }
}
