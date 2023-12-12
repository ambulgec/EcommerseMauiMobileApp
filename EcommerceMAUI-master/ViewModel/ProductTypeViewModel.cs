namespace EcommerceMAUI.ViewModel;

public class ProductTypeViewModel : ContentPage
{
	public ProductTypeViewModel()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}