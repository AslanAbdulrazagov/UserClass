namespace UserClass;

internal class User
{
    private static int id;
    private string _password;
    public int Id { get; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Password
    {
        get => _password;
        set
        {
            while (!PasswordChecker(value))
            {
                Console.WriteLine("Sifreni duzgun daxil edin:");
                value = Console.ReadLine();
            }
            _password = value;
        }
    }
    public User(string email, string password, string fullname)
    {
        id++;
        Id = id;
        Email = email;
        Password = password;
        Fullname = fullname;

    }

    public bool PasswordChecker(string password)
    {
        bool Upper = false;
        bool Lower = false;
        bool Digit = false;
        if (password.Length >= 8)
        {
            foreach (var item in password)
            {
                if (char.IsUpper(item))
                {
                    Upper = true;
                }
                else if (char.IsLower(item))
                {
                    Lower = true;
                }
                else if (char.IsDigit(item))
                {
                    Digit = true;
                }
                if (Upper && Lower && Digit)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void GetInfo()
    {
        Console.WriteLine($"Id:{Id} - Fullname:{Fullname} - Email {Email}");
    }
    public static int FindByID(User[] users, int id)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }
}