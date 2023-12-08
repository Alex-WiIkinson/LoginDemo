using System.Windows.Controls;
using LoginDemo.classes;
using LoginDemo.Pages;

namespace LoginDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    // Static list of "global" pages.
    private static readonly Page[] Pages =
    {
        new RegisterPage(),
        new LoginPage()
    };

    //static list of pages that are only available to the current session so they can be removed when the user logs out.
    private static readonly List<Page> SessionPages = [];

    public MainWindow()
    {
        InitializeComponent();

        // Test User
        var test = new AdminUser("admin", "admin");

        // If no user is logged in, show the login page.
        if (User.CurrentUser != null) return;
        foreach (var page in Pages)
        {
            if (page.GetType() == typeof(LoginPage))
            {
                Main.Content = page;
            }
        }
    }

    public static Array GetPages()
    {
        // Returns list of "Global" pages.
        return Pages;
    }

    public static List<Page> GetSessionPages()
    {
        // Returns the list of session pages.
        return SessionPages;
    }

    public static void ShowPages()
    {
        // Shows list of pages in console for testing.
        foreach (var i in Pages)
        {
            Console.WriteLine(i.ToString());
        }
    }

    public static void ShowSessionPages()
    {
        // Shows list of pages in console for testing.
        foreach (var i in SessionPages)
        {
            Console.WriteLine(i.ToString());
        }
    }

    public static void AddSessionPage(Page page)
    {
        // adds a page to the session pages list.
        SessionPages.Add(page);
    }
    
    public static void RemoveSessionPage(Page page)
    {
        // removes a page from the session pages list.
        SessionPages.Remove(page);
    }

    public static void ClearSessionPages()
    {
        // Clears the session pages list.
        SessionPages.Clear();
    }
}