using MauiLiteDBDemo.Services;
using MauiLiteDBDemo.ViewModels;
using MauiLiteDBDemo.Views;

namespace MauiLiteDBDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// 🔹 Registrar servicios y ViewModels
		builder.Services.AddSingleton<LiteDbService>();
		builder.Services.AddSingleton<TasksViewModel>();
		builder.Services.AddSingleton<TaskPage>();

        return builder.Build();
	}
}

