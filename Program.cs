 
using System;

public class Bank
    
{
    private Dictionary<string, string> users = new Dictionary<string, string>();
    public Bank()
    {
         users["Joe.Doe"] = "Password123";
    }

    public void SignUp()
    {
        Console.WriteLine("Sign Up");
        string username;
        while (true)
        {
            Console.Write("Enter username: ");
            username = Console.ReadLine();
            if (!users.ContainsKey(username))
            {
                break;
            }
            Console.WriteLine(" Username already exists, please try again");
        }
        while (true)
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (!(password == null))
            {
                users.Add(username, password);
                break;
            }
            Console.WriteLine("Password cannot be null");
        }
        return; 
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

            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine("Login successful! Welcome, " + username);
                return true;
            }
            else
            {
                Console.WriteLine("Invalid credentials. please Try again.");
                attempts++;
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
            Console.Write(" 1: Login\n 2: Signup\n 3: Quit\n Please Select an option:  ");
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
                    bank.SignUp();
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