using DataClasses.DataLayerClasses;
using Dapper;
using Microsoft.Data.Sqlite;

namespace DataAccessLayer
{
    public class DatabaseManager
    {
        private string connectionString = "Data Source=myDatabase.db";
        
        public DatabaseManager() 
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                // Create tables if they don't exist
                var sql = @"
                    CREATE TABLE IF NOT EXISTS CodingSessions (
                        Id INTEGER PRIMARY KEY,
                        StartDate TEXT NOT NULL,
                        EndDate TEXT,
                        AllTime TEXT NOT NULL
                    );";
                
                connection.Execute(sql);
            }
        }

        public CodingSessionEntity ToCodingSessionEntity(DataClasses.BLLClasses.CodingSessionDto dto)
        {
            return new CodingSessionEntity
            {
                Id = dto.Id,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                AllTime = dto.AllTime
            };
        }
    }
}