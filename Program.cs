using ISE102_A2_Part1.cs;
using System;
using System.Security.Cryptography.X509Certificates;

public class Bank

{
    private List<User> users = new List<User>();
    public Bank()
    {
        User jd = new User();
        jd.userName = "john.doe";
        jd.password = "tesT12##";
        jd.phone = "1234567890";
        jd.email = "johnDoe@gmail.com";
        users.Add(jd);
    }

    public void Register()
    {
        Console.WriteLine("Register");

        User newUser = new User();

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        foreach (User usr in users)
        {
            if (username == usr.userName)
            {
                Console.WriteLine(" Username already exists, please try again");
                Register();
            }
        }

        newUser.userName = username;

            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            if (email != null && email != "")
            {
                newUser.email = email;
            }
            else
            {
                Console.WriteLine(" Email must not be null");
                Register();
            }

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            if (phone != null && phone != "")
            {
                newUser.phone = phone;
            }
            else
            {
                Console.WriteLine(" Phone must not be null");
                Register();
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (password != null && password != "")
            {
                newUser.password = password;
            }
            else
            {
                Console.WriteLine(" Password must not be null");
                Register();
            }

            users.Add(newUser);
            Console.WriteLine($"New user added: {newUser.userName} - {newUser.email}");
    }
    public bool Login()
    {
        Console.WriteLine("Login");
        int attempts = 0;

        while (attempts < 3)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            foreach (User usr in users)
            {
                if (usr.userName == username)
                {
                    if (usr.password == password)
                    {
                        Console.WriteLine("Login successful! Welcome, " + username);
                        return true;
                    }
                    
                    Console.WriteLine("Invalid credentials. please Try again.");
                    attempts++;
                }
            }
        }
        Console.WriteLine("Too many failed attempts. Access denied.");
        return false;
    }
}

public class program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        while (true)
        {
            Console.WriteLine("Welcome to abc bank");
            Console.Write(" 1: Login\n 2: Register\n 3: Quit\n Please Select an option:  ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    bool loggedIn = (bank.Login());
                    if (loggedIn)
                    {
                        Console.WriteLine("Accessing main banking operations...");

                    }
                    else
                    {
                        return; 
                    }
                        break;

                case "2":
                    bank.Register();
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0); // Terminates the program 
                    break;
                    

                default:
                    Console.WriteLine("Invalid option."); 
                    break;

            }
        }
    }
}  