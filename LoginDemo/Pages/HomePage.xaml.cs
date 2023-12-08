using System.Windows;
using LoginDemo.classes;

namespace LoginDemo.Pages;

public partial class HomePage
{
    public HomePage()
    {
        InitializeComponent();

        // Set welcome text.
        HomeWelcomeTextBlock.Text = $"Welcome {User.CurrentUser?.UserName}!";
        
        if (User.CurrentUser is AdminUser)
        {
            // If user is admin, show admin button.
            HomeAdminButton.Visibility = Visibility.Visible;
        }
    }

    private void HomeLogoutButton_OnClick(object sender, RoutedEventArgs e)
    {
        // If NavigationService is available, navigate to the login page and clear current user.
        if (NavigationService != null)
        {
            User.CurrentUser = null;

            foreach (var page in MainWindow.GetPages())
            {
                if (page.GetType() == typeof(LoginPage))
                {
                    // Navigate
                    NavigationService.Navigate(page);
                    // Clear session pages
                    MainWindow.ClearSessionPages();
                    return;
                }
            }
        }
    }

    private void HomeAdminButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (NavigationService != null)
        {
            MainWindow.AddSessionPage(new AdminPage());

            foreach (var page in MainWindow.GetSessionPages())
            {
                if (page.GetType() == typeof(AdminPage))
                {
                    NavigationService.Navigate(page);
                    return;
                }
            }
        }
    }
}