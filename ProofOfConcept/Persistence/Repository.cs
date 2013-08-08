using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;
using Newtonsoft.Json; 

namespace Persistence
{
    public class Repository
    {
        private static string _connectionString = "Server=(local);Database=NsbDemo;Min Pool Size=5;Pooling=True;Trusted_Connection=True"; 
         
        private static IDbConnection GetDb()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var exists =
                connection.Query("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'WipItems'").Any();

            if (!exists)
            {
                connection.Execute(
                    "CREATE TABLE WipItems(Id uniqueidentifier PRIMARY KEY, IsComplete bit NOT NULL DEFAULT(0), Station nvarchar(50));");
            }

            return connection;
        }

        public static void Save(Guid id, WipItem obj) 
        {
            using (var connection = GetDb())
            {
                var exists = connection.Query("SELECT Id FROM WipItems WHERE Id = @id", new {id}).Any();
                if (exists)
                {
                    connection.Execute("UPDATE WipItems SET IsComplete = @IsComplete, Station = @Station", obj);
                }
                else
                {
                    connection.Execute(
                        "INSERT INTO WipItems(Id, IsComplete, Station) VALUES(@Id, @IsComplete, @Station)", obj);
                }
            }  
        }

        public static WipItem Get(Guid id) 
        {
            using (var connection = GetDb())
            {
                return connection.Query<WipItem>("SELECT Id FROM WipItems WHERE Id = @id", new { id }).SingleOrDefault(); 
            }  
        }

        public static IEnumerable<WipItem> GetAll() 
        {
            using (var connection = GetDb())
            {
                return connection.Query<WipItem>("SELECT Id FROM WipItems").ToList();
            }  
        } 
    }
}
