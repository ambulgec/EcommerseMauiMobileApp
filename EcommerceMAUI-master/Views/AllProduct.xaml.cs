using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;

namespace EcommerceMAUI.Views;

public partial class AllProduct : ContentPage
{
    public readonly AllProductViewModel _allProductViewModel;
    public AllProduct(AllProductViewModel allProductViewModel)
    {
        InitializeComponent();
        BindingContext = allProductViewModel;
      

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