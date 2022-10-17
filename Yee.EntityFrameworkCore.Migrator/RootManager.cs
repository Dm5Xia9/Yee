using Newtonsoft.Json.Linq;
using Yee.Abstractions;
using Yee.EntityFrameworkCore.Npgsql;

namespace Yee.EntityFrameworkCore.Migrator
{
    public class RootManager : IRootOptions
    {
        public T? Get<T>(string key) where T : class
        {
            return (T)Get(typeof(T), key);

        }

        public object Get(Type type, string key)
        {
            if (type == typeof(NpgsqlOptions))
            {
                return new NpgsqlOptions
                {
                    ConnectionString = "Host=49.12.227.30;Port=5432;Database=yee;Username=postgres;Password=btxg5mcpZhxchcqg;Pooling=true;",
                    Timeout = 600
                };
            }
            throw new NotImplementedException();

        }

        public IEnumerable<RootOption<JObject>> GetAll()
        {
            throw new NotImplementedException();
        }

        public RootOption<T> GetDetail<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
