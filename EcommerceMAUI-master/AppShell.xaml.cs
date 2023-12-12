using EcommerceMAUI.Model;
using EcommerceMAUI.Views;

namespace EcommerceMAUI;

public partial class AppShell : Shell
{
    //public AppShell()
    //{
    //    InitializeComponent();
    //    Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

    //}

    private readonly INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;

        AppShell.InitializeRouting();
        InitializeComponent();
    }

    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }

    private static void InitializeRouting()
    {
        Routing.RegisterRoute("AllProduct", typeof(AllProduct));
        Routing.RegisterRoute("BrandDetail", typeof(BrandDetail));
        Routing.RegisterRoute("CartPage", typeof(CartPage));
        Routing.RegisterRoute("CategoryDetail", typeof(CategoryDetail));
        Routing.RegisterRoute("FavItem", typeof(FavItem));
     //   Routing.RegisterRoute("HomePage", typeof(HomePage));
      //  Routing.RegisterRoute("Login", typeof(LoginPage));
        Routing.RegisterRoute("Product", typeof(Product));
        Routing.RegisterRoute("ProductAllType", typeof(ProductAllType));
        Routing.RegisterRoute("ProductType", typeof(ProductType));
        
    }
}
