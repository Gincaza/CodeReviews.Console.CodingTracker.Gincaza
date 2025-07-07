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
                    );
                    
                    CREATE TABLE IF NOT EXISTS Projects (
                        Id INTEGER PRIMARY KEY,
                        Name TEXT NOT NULL,
                        Description TEXT,
                        CreatedDate TEXT NOT NULL
                    );
                    
                    CREATE TABLE IF NOT EXISTS CodeEntries (
                        Id INTEGER PRIMARY KEY,
                        CodingSessionId INTEGER NOT NULL,
                        ProjectId INTEGER,
                        Timestamp TEXT NOT NULL,
                        CharactersAdded INTEGER NOT NULL,
                        CharactersDeleted INTEGER NOT NULL,
                        FOREIGN KEY (CodingSessionId) REFERENCES CodingSessions(Id),
                        FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
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