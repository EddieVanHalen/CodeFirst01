using System.Collections.ObjectModel;
using CodeFirst01.DbContext;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst01.ViewModel;

[INotifyPropertyChanged]
public partial class MainPageViewModel : BaseViewModel
{
    public ObservableCollection<string> Topics { get; set; }

    public ObservableCollection<Book> Books { get; set; }

    public ObservableCollection<string> TopicsContent { get; set; }

    public LibraryContext LibraryDb { get; set; }

    [ObservableProperty] private int _selectedTopicIndex = -1;

    [ObservableProperty] private int _selectedTopicItemIndex = -1;

    public MainPageViewModel()
    {
        LibraryDb = App.Provider.GetService<LibraryContext>()!;

        Topics = new ObservableCollection<string>
        {
            "Authors",
            "Themes",
            "Categories"
        };

        Books = new ObservableCollection<Book>();
        TopicsContent = new ObservableCollection<string>();
    }

    [RelayCommand]
    private async Task TopicContentSelectionChanged()
    {
        Books.Clear();

        if (SelectedTopicIndex == 0)
        {
            var books = await Task.Run(() => LibraryDb.Books.Where(b => b.IdAuthor == (SelectedTopicItemIndex + 1)).ToList());

            foreach (var book in books)
            {
                Books.Add(book);
            }
        }
        else if(SelectedTopicIndex == 1)
        {
            var themes = await Task.Run(() => LibraryDb.Books.Where(b => b.IdThemes == (SelectedTopicItemIndex + 1)).ToList());

            foreach (var theme in themes)
            {
                Books.Add(theme);
            }
        }
        else if(SelectedTopicIndex == 2)
        {
            var categories = await Task.Run(() => LibraryDb.Books.Where(b => b.IdCategory == (SelectedTopicItemIndex + 1)).ToList());

            foreach (var category in categories)
            {
                Books.Add(category);
            }
        }
    }

    [RelayCommand]
    private async Task TopicSelectionChanged()
    {
        TopicsContent.Clear();
        if (SelectedTopicIndex == 0)
        {
            var authors = await Task.Run(() => LibraryDb.Authors.ToList());

            foreach (var author in authors)
            {
                TopicsContent.Add(author.ToString());
            }
        }
        else if (SelectedTopicIndex == 1)
        {
            var themes = await Task.Run(() => LibraryDb.Themes.ToList());

            foreach (var theme in themes)
            {
                TopicsContent.Add(theme.ToString());
            }
        }
        else
        {
            var categories = await Task.Run(() => LibraryDb.Categories.ToList());

            foreach (var category in categories)
            {
                TopicsContent.Add(category.ToString());
            }
        }
    }
}