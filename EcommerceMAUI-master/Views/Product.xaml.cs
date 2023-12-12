//using AndroidX.Lifecycle;
using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;
//using static Android.App.Assist.AssistStructure;

namespace EcommerceMAUI.Views;

public partial class Product : ContentPage
{
    public readonly AllProductViewModel _viewModel;
   
    public Product(AllProductViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void OnFilterClick(object sender, EventArgs e)
    {
        filterFrame.IsVisible = !filterFrame.IsVisible;
    }


    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    if (_viewModel.IsInitialized)
    //    {
    //        //_viewModel.RefreshCommand.Execute(null);
    //    }
    //}
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