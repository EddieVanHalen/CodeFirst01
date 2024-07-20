using CodeFirst01.ViewModel;

namespace CodeFirst01.Messages;

public class ChangeViewModelMessage : Message
{
    public BaseViewModel ViewModel { get; set; }

    public ChangeViewModelMessage(BaseViewModel viewModel)
    {
        ViewModel = viewModel;
    }
}