using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        UserRepository userRepository = new UserRepository();

        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Создать пользователя");
        Console.WriteLine("2. Получить всех пользователей");
        Console.WriteLine("3. Обновить пользователя");
        Console.WriteLine("4. Удалить пользователя");
        Console.WriteLine("5. Импорт пользователей из Excel");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Введите имя: ");

                string username = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();


                userRepository.CreateUser(username, password);
                Console.WriteLine("Пользователь создан");
                break;

            case 2:
                var users = userRepository.GetAllUsers();


                foreach (var user in users)
                    Console.WriteLine($"ID: {user.Id}, Имя: {user.Username}");
                break;

            case 3:
                Console.Write("Введите ID пользователя: ");
                int updateId = int.Parse(Console.ReadLine());

                Console.Write("Введите новое имя: ");
                string newUsername = Console.ReadLine();

                userRepository.UpdateUser(updateId, newUsername);


                Console.WriteLine("Имя обновлено");
                break;

            case 4:
                Console.Write("Введите ID пользователя для удаления: ");
                int deleteId = int.Parse(Console.ReadLine());

                userRepository.DeleteUser(deleteId);
                Console.WriteLine("Пользователь удалён");
                break;

            case 5:
                Console.Write("Введите путь к файлу Excel: ");//C:\Users\USER\Desktop\Новая папка (2)\users.xlsx
                string filePath = Console.ReadLine();
                var importedUsers = ExcelImporter.ImportUsersFromExcel(filePath);


                foreach (var user in importedUsers)
                {
                    userRepository.CreateUser(user.Username, user.Password);
                }
                Console.WriteLine("Импорт завершён");
                break;



        }
    }
}
