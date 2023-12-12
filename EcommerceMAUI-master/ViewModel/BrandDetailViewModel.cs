using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EcommerceMAUI.ViewModel.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;
using EcommerceMAUI.Services.HttpServices;


namespace EcommerceMAUI.ViewModel
{
    [QueryProperty (nameof(BrandProduct), "BrandProduct")]
    public partial class BrandDetailViewModel : ViewModelBase
    {

        public readonly IApiServices _apiService;

        [ObservableProperty]
        public string _brandProduct;

        [ObservableProperty]
        public ObservableCollection<TabPageModel> _TabPageList ;

        [ObservableProperty]
        public ObservableCollection<CategoriesModel> _allProductDataList;

        [ObservableProperty]
        private bool isLoading;

        public bool IsNotLoading => !IsLoading;

        public BrandDetailViewModel(INavigationService navigationService, IApiServices apiService) : base(navigationService)
        {
            
            _apiService = apiService;
        }

    

        public override async Task InitializeAsync()
        {
            await IsBusyFor(
            async () => 
            {
                IsLoading = true;
                string brandApiUrl = "products.json?brand=" + BrandProduct;
                AllProductDataList = await _apiService.GetAsync<ObservableCollection<CategoriesModel>>(brandApiUrl);

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
}
