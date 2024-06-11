namespace UserClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User[] users = new User[3];
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine($"Enter details for user {i + 1}:");

                Console.Write("Fullname: ");
                string fullname = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                string password;
                while (true)
                {
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    if (new User("", "", "").PasswordChecker(password))
                    {
                        users[i] = new User(fullname, email, password);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password does not meet the required criteria. Please try again.");
                    }
                }
            }

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Show all students");
                Console.WriteLine("2. Get info by id");
                Console.WriteLine("0. Quit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        foreach (var user in users)
                        {
                            user.GetInfo();
                        }
                        break;

                    case "2":
                        Console.Write("Enter user id: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            User user = User.FindUserById(users, id);
                            if (user != null)
                            {
                                user.GetInfo();
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid id format.");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }


    
}