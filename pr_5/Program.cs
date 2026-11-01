using pr_5.models; 
using pr5_PasswordSecurity; 
using System;
using System.Linq;

namespace pr_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание новой учетной записи для пользователя\n");

            Console.Write("Введите имя пользователя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию пользователя: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            PasswordHasher hasher = new PasswordHasher();
            string hashedPassword = hasher.ComputeHash(password);

            Console.WriteLine($"Хешированный пароль пользователя: {hashedPassword}");

            Helper helper = new Helper();

            if (Helper.GetContext().Users.Any(u => u.Login == login))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Пользователь с таким логином уже существует!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            try
            {
                Employees newEmployee = new Employees
                {
                    FullName = $"{lastName} {firstName}",
                    Position = "Пользователь системы"
                };

                Users newUser = new Users
                {
                    Employees = newEmployee,
                    Login = login,
                    PasswordHash = hashedPassword,
                    Role = "Пользователь",
                    CreatedDate = DateTime.Now 
                };

                helper.CreateUser(newUser);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Учетная запись добавлена");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Детали: {ex.InnerException.Message}");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}