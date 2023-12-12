using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;

namespace EcommerceMAUI.Views;

public partial class FavItem : ContentPage
{
    public readonly FavItemViewModel _favItemViewModel;

    public FavItem(FavItemViewModel favItemViewModel)
    {
        InitializeComponent();
        BindingContext = favItemViewModel;

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