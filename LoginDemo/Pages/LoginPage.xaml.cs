using System.Windows;
using LoginDemo.classes;
using static LoginDemo.classes.User;

namespace LoginDemo.Pages;

public partial class LoginPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        // login user
        if (LoginUserNameTextBox.Text == "")
        {
            // Username field is empty.
            MessageBox.Show("Username field is empty");
        }
        else if (LoginPasswordTextBox.Password == "")
        {
            // Password field is empty.
            MessageBox.Show("Password field is empty");
        }
        else
        {
            // If a user is found by username, loginUser will be set to that user.
            User? loginUser = null;

            // Check if user exists and if password is correct.
            foreach (var user in GetUsers())
            {
                if (user.UserName == LoginUserNameTextBox.Text)
                {
                    loginUser = user;
                }
            }


            if (loginUser != null)
            {
                if (loginUser.CheckLogin(LoginUserNameTextBox.Text, LoginPasswordTextBox.Password))
                {
                    // Testing
                    Console.WriteLine($"Attempting login for: {loginUser.UserName}");

                    // If user exists and password is correct, set the current user and navigate to the home page.
                    CurrentUser = loginUser;

                    // If NavigationService is available, add the home page to the session pages and navigate to the home page.
                    if (NavigationService != null)
                    {
                        MainWindow.AddSessionPage(new HomePage());

                        foreach (var page in MainWindow.GetSessionPages())
                        {
                            if (page.GetType() == typeof(HomePage))
                            {
                                NavigationService.Navigate(page);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    // Password not correct.
                    MessageBox.Show("Invalid username or password");
                }
            }
            else
            {
                // Username not correct.
                MessageBox.Show("Invalid username or password");
            }
        }
    }

    private void LoginPageRegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        // If NavigationService is available, navigate to the register page.
        if (NavigationService != null)
        {
            foreach (var page in MainWindow.GetPages())
            {
                if (page.GetType() == typeof(RegisterPage))
                {
                    NavigationService.Navigate(page);
                    return;
                }
            }
        }
    }
}