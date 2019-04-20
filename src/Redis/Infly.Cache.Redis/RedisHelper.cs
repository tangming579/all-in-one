using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infly.Cache.Redis
{
    public class RedisHelper
    {
        private static PooledRedisClientManager prcm;

        static RedisHelper()
        {

        }

        private static void Init()
        {
            string[] writeServerList = new string[] { };
            string[] readServerList = new string[] { };
            prcm = new PooledRedisClientManager(readServerList, writeServerList,
                new RedisClientManagerConfig
                {
                    MaxWritePoolSize = 1000,
                    MaxReadPoolSize = 1000,
                    AutoStart = true
                });
        }

        public static bool Set<T>(string key, T t)
        {
            using (var redis = prcm.GetClient())
            {
                return redis.Set(key, t);
            }
        }

        public static bool Set<T>(string key, T t, TimeSpan timeSpan)
        {
            using (var redis = prcm.GetClient())
            {
                return redis.Set(key, t, timeSpan);
            }
        }
    }
}
