namespace UserClass;
public class User
{
    private static int _idCounter = 0;
    public int Id { get; private set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    private string _password;

    public string Password
    {
        get { return _password; }
        set
        {
            if (PasswordChecker(value))
            {
                _password = value;
            }

        }
    }

    public User(string fullname, string email, string password)
    {
        Id = ++_idCounter;
        Fullname = fullname;
        Email = email;
        Password = password;
    }

    public bool PasswordChecker(string password)
    {
        if (password.Length < 8) return false;
        if (!password.Any(char.IsUpper)) return false;
        if (!password.Any(char.IsLower)) return false;
        if (!password.Any(char.IsDigit)) return false;
        return true;
    }

    public void GetInfo()
    {
        Console.WriteLine($"ID: {Id}, Fullname: {Fullname}, Email: {Email}");
    }

    public static User FindUserById(User[] users, int id)
    {
        return users.FirstOrDefault(user => user.Id == id);
    }
}