using System.Windows;
using LoginDemo.classes;

namespace LoginDemo.Pages;

public partial class RegisterPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void RegisterPageLoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        // If NavigationService is available, navigate to the login page.
        if (NavigationService != null)
        {
            foreach (var page in MainWindow.GetPages())
            {
                if (page.GetType() == typeof(LoginPage))
                {
                    NavigationService.Navigate(page);
                    return;
                }
            }
        }
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (RegisterUserNameTextBox.Text == "")
        {
            // Username field is empty.
            MessageBox.Show("Username field is empty");
        }
        else if (RegisterPasswordTextBox.Password == "")
        {
            // Password field is empty.
            MessageBox.Show("Password field is empty");
        }
        else
        {
            // Check if user exists.
            var userExists = false;
            foreach (var user in User.GetUsers())
            {
                if (user.UserName == RegisterUserNameTextBox.Text)
                {
                    userExists = true;
                }
            }

            if (userExists)
            {
                MessageBox.Show("A user with that username already exists.");
                return;
            }

            // Create new user.
            User newUser = new StandardUser(RegisterUserNameTextBox.Text, RegisterPasswordTextBox.Password);
            MessageBox.Show("You have successfully created an account! You can now log in.");

            // If NavigationService is available, navigate to the login page.
            if (NavigationService != null)
            {
                foreach (var page in MainWindow.GetPages())
                {
                    if (page.GetType() == typeof(LoginPage))
                    {
                        NavigationService.Navigate(page);
                        return;
                    }
                }
            }
        }
    }
}