using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;
using Services.Interfaces;
using ViewModel;

namespace AndroidApp
{
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

            builder.Services.AddScoped<IMockService, MockService>();
            
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<ArrangerPage>();
            builder.Services.AddTransient<ArrangerViewModel>();

            return builder.Build();
        }
    }
}