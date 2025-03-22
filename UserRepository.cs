using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}



public class UserRepository
{
    public void CreateUser(string username, string password)
    {
        using var connection = DbConnectionHelper.GetConnection();
        string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
        connection.Execute(query, new { Username = username, Password = password });

    }

    public User GetUserById(int id)
    {
        using var connection = DbConnectionHelper.GetConnection();
        string query = "SELECT * FROM Users WHERE Id = @Id";
        return connection.QueryFirstOrDefault<User>(query, new { Id = id });

    }

    public List<User> GetAllUsers()
    {
        using var connection = DbConnectionHelper.GetConnection();
        string query = "SELECT * FROM Users";
        return connection.Query<User>(query).ToList();
    }

    public void UpdateUser(int id, string newUsername)
    {
        using var connection = DbConnectionHelper.GetConnection();
        string query = "UPDATE Users SET Username = @NewUsername WHERE Id = @Id";
        connection.Execute(query, new { Id = id, NewUsername = newUsername });

    }

    public void DeleteUser(int id)
    {

        using var connection = DbConnectionHelper.GetConnection();
        string query = "DELETE FROM Users WHERE Id = @Id";
        connection.Execute(query, new { Id = id });
    }
}

