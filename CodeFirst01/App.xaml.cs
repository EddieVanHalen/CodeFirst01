using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;
using CodeFirst01.DbContext;
using CodeFirst01.View;
using CodeFirst01.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst01;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ServiceCollection Collection { get; private set; } = null!;

    public static ServiceProvider Provider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Collection = new ServiceCollection();

        Collection.AddSingleton<MainView>();
        Collection.AddSingleton<MainViewModel>();
        Collection.AddSingleton<MainPageViewModel>();
        Collection.AddSingleton<ConfigurationBuilder>();
        Collection.AddScoped<LibraryContext>();

        Provider = Collection.BuildServiceProvider();

        var view = Provider.GetService<MainView>();

        view!.Show();
    }
}