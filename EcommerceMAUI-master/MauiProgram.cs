using CommunityToolkit.Maui;
using EcommerceMAUI.Converters;
//using EcommerceMAUI.Interfaces;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services;
using EcommerceMAUI.Services.HttpServices;
using EcommerceMAUI.Services.Repository;
using EcommerceMAUI.ViewModel;
using EcommerceMAUI.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using SQLite;

namespace EcommerceMAUI;

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
                fonts.AddFont("fontello.ttf", "Iconss");
            })
            .UseMauiCommunityToolkit();

        builder.Services.AddTransient<FavItem>();
        builder.Services.AddTransient<CartPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<BrandDetail>();
        builder.Services.AddSingleton<CartPage>();
        builder.Services.AddTransient<ProductType>();
        builder.Services.AddTransient<ProductDetail>();
        builder.Services.AddSingleton<CategoryDetail>();
        builder.Services.AddSingleton<ProductAllType>();
        builder.Services.AddSingleton<Product>();
        builder.Services.AddSingleton<CartPage>();

        builder.Services.AddSingleton<UserFav>();
        builder.Services.AddSingleton<UserProduct>();
        builder.Services.AddSingleton<UserTable>();
      //  builder.Services.AddTransient()

            builder.Services.AddTransient<FavItemViewModel>();
            builder.Services.AddTransient<CartViewModel>();
            builder.Services.AddTransient<UserRepository>();
            builder.Services.AddSingleton<LoginPageViewModel>();
           
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddTransient<BrandDetailViewModel>();
            builder.Services.AddTransient<ProductDetailsViewModel>();
            builder.Services.AddSingleton<ClassConverter>();
            builder.Services.AddSingleton<CategoryDetailViewModel>();
            builder.Services.AddSingleton<ProductAllTypeViewModel>();
            builder.Services.AddSingleton<AllProductViewModel>();

           builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
           builder.Services.AddSingleton<IUserRepository, UserRepository>();
           builder.Services.AddSingleton<IApiServices, ApiService>();




        return builder.Build();
    }
}
