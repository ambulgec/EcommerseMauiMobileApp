using EcommerceMAUI.Model;
using EcommerceMAUI.ViewModel;
using EcommerceMAUI.ViewModel.Base;

namespace EcommerceMAUI.Views;

public partial class CartPage : ContentPage
{

    public readonly CartViewModel _cartViewModel;
   public CartPage(CartViewModel cartViewModel)
    {
      
        InitializeComponent();
        BindingContext = cartViewModel;

       
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

    //public CartPage()
    //{

    //}

    //public CartPage(ProductDetail lm)
    //{

    //    BindingContext = new CartViewModel(lm);

    //}

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }

    async void checkoutBtn_Clicked(object sender, EventArgs e)
    {

       // await Shell.Current.GoToAsync($"{nameof(CheckoutPage)}", animate: true);
    }
}