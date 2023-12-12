using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.HttpServices;
using EcommerceMAUI.ViewModel.Base;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel;

  [QueryProperty(nameof(ProductType), "ProductType")]
public partial class ProductAllTypeViewModel : ViewModelBase
{
   

    [ObservableProperty]
    public ObservableCollection<CategoriesModel>_AllProductDataList = new ObservableCollection<CategoriesModel>();
    [ObservableProperty]
    public string _productType;
    [ObservableProperty]
    private bool isLoading;
    public bool IsNotLoading => !IsLoading;
    public CategoriesModel Data { get; }
    private IApiServices _apiService;

    public ProductAllTypeViewModel(IApiServices apiServices, BrandDetailViewModel brandDetailViewModel, INavigationService navigationService) : base(navigationService)
    {

        _apiService = apiServices;
        
        
    }
   
   

    public override async Task InitializeAsync()
    {
      
        await IsBusyFor(
        async () =>
        {
            IsLoading = true;
            string productApi = "products.json?product_type=" + ProductType;
            AllProductDataList = await _apiService.GetAsync<ObservableCollection<CategoriesModel>>(productApi);

            IsLoading = false;
            OnPropertyChanged(nameof(IsNotLoading));
        });
    }
   

    [RelayCommand]
    private async Task SelectProduct(CategoriesModel obj)
    {
        await NavigationService.NavigateToAsync(
      "ProductType", new Dictionary<string, object>
      {
          [nameof(ProductDetailsViewModel.ProductInDetails)] = obj
      });

    }


}
