using MauiLiteDBDemo.Views;

namespace MauiLiteDBDemo;

public partial class App : Application
{
	public App(TaskPage tasksPage)
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new NavigationPage(tasksPage);
	}
}

