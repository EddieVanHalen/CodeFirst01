using System.Windows;
using CodeFirst01.ViewModel;

namespace CodeFirst01.View;

public partial class MainView : Window
{
    public MainView(MainViewModel mainViewModel)
    {
        InitializeComponent();

        DataContext = mainViewModel;
    }
}