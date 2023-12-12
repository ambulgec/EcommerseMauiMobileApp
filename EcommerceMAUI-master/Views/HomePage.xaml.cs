using EcommerceMAUI.ViewModel;

namespace EcommerceMAUI.Views;

public partial class HomePage : ContentPage
{
    public readonly HomePageViewModel _homePageViewModel;
    public HomePage(HomePageViewModel homePageViewModel)
    {
        InitializeComponent();
        InitializeImageCarousel();
        BindingContext = homePageViewModel;
    

    }

    private void InitializeImageCarousel()
    {
        
        var imageFileNames = new List<string>
            {
                "image1.png",
                "image2.png",
                "image3.png",
                "image4.png",
                "image5.png"
            };

    
        ImageCarousel.ItemsSource = imageFileNames;
    }
}