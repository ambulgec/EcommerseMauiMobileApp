using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;

namespace EcommerceMAUI.Views;

public partial class ProductAllType : ContentPage
{
    private readonly ProductTypeViewModel _productTypeViewModel;
    public ProductAllType(ProductAllTypeViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
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