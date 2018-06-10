using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Data;
using TrailTracker.Models;
using Dapper;

namespace TrailTracker.Factories
{
    public class TrailFactory
    {
        string Server = "localhost";
        string Port = "3306";
        string Database = "trailDB";
        string UserID = "root";
        string Password = "root";

        internal IDbConnection Connection 
        {
            get
            {
                return new MySqlConnection($"server={Server}; userid={UserID}; password={Password}; port={Port}; database={Database}; SslMode=None");
            }
        }
        // Get All Trails
        public List<Trail> GetAllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM trails;";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
        
        // Get Single Trail
        public List<Trail> GetSingleTrail(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = $"SELECT * FROM trails WHERE id = {id};";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
        // Create Trail
        public void AddTrail(Trail trail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails (name, description, length, elevation, longitude, latitude, created_at, updated_at) VALUES(@Name, @Description, @Length, @Elevation, @Longitude, @Latitude, NOW(), NOW());";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
    }
}