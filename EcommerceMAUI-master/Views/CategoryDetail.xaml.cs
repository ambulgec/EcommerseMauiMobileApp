using EcommerceMAUI.Model;
using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;

namespace EcommerceMAUI.Views;

public partial class CategoryDetail : ContentPage
{
    private readonly CategoryDetailViewModel _categoryDetailViewModel;
    public CategoryDetail(CategoryDetailViewModel categoryDetailViewModel)
    {
        InitializeComponent();
        BindingContext = categoryDetailViewModel;
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

        // Execute InitializeAsyncCommand if everything is as expected.
        await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
    }

}