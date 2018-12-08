using System;
using System.Collections.Generic;
using DbConnection;

namespace simpleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Create();
            Update();
            Delete();
            Read();
        }
        //Read database and return a list of dictionaries 
        public static List<Dictionary<string, object>> Read()
        {
            var results = DbConnector.Query
            (
                @"SELECT 
                     first_name 
                    ,last_name 
                    ,favorite_number
                    ,created_at
                    ,id
                FROM
                    users
                ORDER BY last_name DESC"
            );
            return results;
        }
        //Create a new database entry 
        public static void Create()
        {
            DbConnector.Execute
            (
                @"INSERT INTO users
                (
                     first_name
                    ,last_name
                    ,favorite_number
                    ,created_at
                    ,updated_at
                )
                VALUES
                (
                     'Luke'
                    ,'Skywalker'
                    ,'11'
                    ,now()
                    ,now()
                    
                );"
            );
        }
        //Update a database entry 
        public static void Update()
        {
            DbConnector.Execute(
                @"UPDATE users
                SET favorite_number = 100
                WHERE id = 2;"
            );
        }
        //Delete a database entry 
        public static void Delete()
        {
           DbConnector.Execute(
               @"DELETE FROM users
               WHERE id = 2;"
           );
        }
    }
}
