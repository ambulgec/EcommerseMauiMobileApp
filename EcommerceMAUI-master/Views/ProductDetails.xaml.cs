
using EcommerceMAUI.Model;
using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;
namespace EcommerceMAUI.Views;

public partial class ProductType : ContentPage
{
    private readonly ProductDetailsViewModel _viewModel;
   

   
    public ProductType(ProductDetailsViewModel viewModel)
    {
        InitializeComponent();
       _viewModel = viewModel;
        BindingContext = _viewModel;
        NavigationPage.SetBackButtonTitle(this, string.Empty);
        viewModel.RefreshButtonColor();
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

    

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        _viewModel.ChageFooterVisibility(e.ScrollY);
    }
}