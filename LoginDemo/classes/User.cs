namespace LoginDemo.classes;

public abstract class User
{
    public string UserName { get; set; }
    private string Password { get; set; }

    public static List<User> Users { get; set; } = new List<User>();
    public static User? CurrentUser;

    protected User(string userName, string password)
    {
        UserName = userName;
        Password = password;

        // Add user to list of users.
        Users.Add(this);
    }

    public static List<User> GetUsers()
    {
        // Returns list of users.
        return Users;
    }

    public bool CheckLogin(string userNameAttempt, string passwordAttempt)
    {
        // Returns true if username and password are correct.
        return userNameAttempt == UserName && passwordAttempt == Password;
    }
}