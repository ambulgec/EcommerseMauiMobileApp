//using EcommerceMAUI.Repository;
using EcommerceMAUI.Views;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcommerceMAUI;

public partial class App : Application
{
    private readonly INavigationService _navigationService;
  //  public static UserRepository Database { get; private set; }
    public App(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeComponent();
        MainPage = new AppShell(navigationService);
        //Database = new UserRepository();
        //MainPage = new LoginPage();
    }
}
