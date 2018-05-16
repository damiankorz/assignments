using System;
using System.Collections.Generic;
using DbConnection;

namespace simpleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReadDataBase();
            // CreateDataBaseEntry();
            // UpdateDataBaseEntry();
            // DeleteDataBaseEntry();
        }
        //Display all entries in database
        public static void ReadDataBase()
        {
            string query = "SELECT * FROM users;";
            var allUsers = DbConnector.Query(query);
            foreach (var user in allUsers)
            {
                Console.WriteLine($"ID: {user["id"]}, First Name: {user["first_name"]}, Last Name: {user["last_name"]}, Favorite Number {user["favorite_number"]}");
            }
        }
        //Create a new database entry and display all entries after creation
        public static void CreateDataBaseEntry()
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter favorite number:");
            string favNumAsString = Console.ReadLine();
            int favNum = int.Parse(favNumAsString);
            string query = $"INSERT INTO users (first_name, last_name, favorite_number, created_at, updated_at) VALUES ('{firstName}', '{lastName}', {favNum}, NOW(), NOW());";
            DbConnector.Execute(query);
            ReadDataBase();
        }
        //Update a database entry based on the user ID and display all entries after update
        public static void UpdateDataBaseEntry()
        {
            Console.WriteLine("Enter user ID to update entry:");
            string userIDAsString = Console.ReadLine();
            int userID = int.Parse(userIDAsString);
            Console.WriteLine("Update first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Update last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Update favorite number:");
            string favNumAsString = Console.ReadLine();
            int favNum = int.Parse(favNumAsString);
            string query = $"UPDATE users SET first_name = '{firstName}', last_name = '{lastName}', favorite_number = {favNum} WHERE id = {userID};";
            DbConnector.Execute(query);
            ReadDataBase();
        }
        //Delete a database entry based on the user ID and display all entries after delete
        public static void DeleteDataBaseEntry()
        {
            Console.WriteLine("Enter user ID to delete entry:");
            string userIDAsString = Console.ReadLine();
            int userID = int.Parse(userIDAsString);
            string query = $"DELETE FROM users WHERE id = {userID};";
            DbConnector.Execute(query);
            ReadDataBase();
        }
    }
}
