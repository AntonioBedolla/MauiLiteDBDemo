using MauiLiteDBDemo.ViewModels;

namespace MauiLiteDBDemo.Views;

public partial class TaskPage : ContentPage
{
	public TaskPage(TasksViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
