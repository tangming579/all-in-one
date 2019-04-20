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
            using (var client = prcm.GetClient())
            {
                return client.Set(key, t);
            }
        }

        public static bool Set<T>(string key, T t, TimeSpan timeSpan)
        {
            using (var client = prcm.GetClient())
            {
                return client.Set(key, t, timeSpan);
            }
        }

        public static bool Set<T>(string key, T t, DateTime dateTime)
        {
            using (var client = prcm.GetClient())
            {
                return client.Set(key, t, dateTime);
            }
        }

        public static bool Remove(string key)
        {
            using (var client = prcm.GetClient())
            {
                return client.Remove(key);
            }
        }

        public static void FlushAll(string key)
        {
            using (var client = prcm.GetClient())
            {
                client.FlushAll();
            }
        }

        public static void AddList<T>(string key, T t)
        {
            using (var client = prcm.GetClient())
            {
                var clientTypedClient = client.As<T>();
                clientTypedClient.AddItemToList(clientTypedClient.Lists[key], t);
            }
        }

        public static bool RemoveList<T>(string key, T t)
        {
            using (var client = prcm.GetClient())
            {
                var clientTypedClient = client.As<T>();
                return clientTypedClient.RemoveItemFromList(clientTypedClient.Lists[key], t) > 0;
            }
        }

        public static void RemoveListAll<T>(string key, T t)
        {
            using (var client = prcm.GetClient())
            {
                var clientTypedClient = client.As<T>();
                clientTypedClient.Lists[key].RemoveAll();
            }
        }

        public static void SetExpireList(string key, DateTime dateTime)
        {
            using (var client = prcm.GetClient())
            {
                client.ExpireEntryAt(key, dateTime);
            }
        }

        public static void AddSet<T>(string key, T t)
        {
            using (var client = prcm.GetClient())
            {
                var clientTypedClient = client.As<T>();
                clientTypedClient.Sets[key].Add(t);
            }
        }
        public static bool ContainsSet<T>(string key, T t)
        {
            using (var client = prcm.GetClient())
            {
                var clientTypedClient = client.As<T>();
                return clientTypedClient.Sets[key].Contains(t);
            }
        }
        public static bool RemoveSet<T>(string key, T t)
        {
            using (var client = prcm.GetClient())
            {
                var clientTypedClient = client.As<T>();
                return clientTypedClient.Sets[key].Remove(t);
            }
        }

        public static bool ExistHash<T>(string hashId, string key)
        {
            using (var client = prcm.GetClient())
            {
                return client.HashContainsEntry(hashId, key);
            }
        }

        public static bool SetHash<T>(string hashId,string key ,T t)
        {
            using (var client = prcm.GetClient())
            {
                var value = ServiceStack.Text.JsonSerializer.SerializeToString<T>(t);
                return client.SetEntryInHash(hashId, key, value);
            }
        }
    }
}
