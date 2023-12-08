using System.Windows;
using LoginDemo.classes;

namespace LoginDemo.Pages;

public partial class AdminPage
{
    public AdminPage()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void AdminPageBackButton_OnClick(object sender, RoutedEventArgs e)
    {
        // Go through all session pages.
        foreach (var page in MainWindow.GetSessionPages())
        {
            // If the page is the home page, navigate to it and remove the admin page from the session pages.
            if (page.GetType() == typeof(HomePage) && NavigationService != null)
            {
                NavigationService.Navigate(page);

                foreach (var i in MainWindow.GetSessionPages())
                {
                    if (i.GetType() == typeof(AdminPage))
                    {
                        MainWindow.RemoveSessionPage(i);
                        return;
                    }
                }
            }
        }
    }
}