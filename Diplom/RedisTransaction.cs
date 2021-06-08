using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diplom
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            try
            {
                LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost"));
            }
            catch(RedisConnectionException)
            {
                MessageBox.Show("Не удалось подключиться к серверу для выполнения запроса", "ОШИБКА");
            }
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
