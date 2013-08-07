using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Persistence
{
    public class Repository
    {
        private static string rootPath = @"C:\demo\";  

        private static string GetDbPath<T>()
        {
            return Path.Combine(rootPath, string.Format("{0}.json", typeof (T).Name));
        }

        private static IDictionary<string, T> GetDb<T>()
            where T : class
        {
            var path = GetDbPath<T>();

            if (!File.Exists(path))
            {
                return new Dictionary<string, T>();
            }

            var db = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IDictionary<string, T>>(db);
        }

        private static void UpdateDb<T>(IDictionary<string, T> database)
            where T : class
        {
            var path = GetDbPath<T>();
            var db = JsonConvert.SerializeObject(database);
            File.WriteAllText(path, db);
        }

        public static void Save<T>(object id, T obj)
            where T : class
        {
            var db = GetDb<T>();

            if (db.ContainsKey(id.ToString()))
            {
                db[id.ToString()] = obj;
            }
            else
            {
                db.Add(id.ToString(), obj);
            }

            UpdateDb(db);
        }

        public static T Get<T>(object id)
            where T : class
        {
            var db = GetDb<T>();

            return db.ContainsKey(id.ToString()) ? db[id.ToString()] : null;
        }

        public static IEnumerable<T> GetAll<T>()
            where T : class
        {
            var db = GetDb<T>();
            return db.Values;
        }

        public static void Delete<T>(object id)
            where T : class
        {
            var db = GetDb<T>();

            if (db.ContainsKey(id.ToString()))
            {
                db.Remove(id.ToString());
                UpdateDb(db);
            }
        }
    }
}
