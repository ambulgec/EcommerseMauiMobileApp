using EcommerceMAUI.Model;
using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;

namespace EcommerceMAUI.Views;

public partial class BrandDetail : ContentPage
{

    private readonly BrandDetailViewModel _brandDetailViewModel;
    public BrandDetail(BrandDetailViewModel brandDetailViewModel)
    {
        // NavigationPage.SetBackButtonTitle(this, string.Empty);
        InitializeComponent();
        BindingContext = brandDetailViewModel;
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModelBase ivmb)
        {
          
            return;
        }

        if (ivmb.InitializeAsyncCommand == null)
        {
            
            return;
        }

       
        await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
    }

    


}