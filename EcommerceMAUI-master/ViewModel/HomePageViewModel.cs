using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Input;
//using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EcommerceMAUI.ViewModel.Base;
using EcommerceMAUI.Services.HttpServices;
//using GalaSoft.MvvmLight;

namespace EcommerceMAUI.ViewModel
{
    public partial class HomePageViewModel : ViewModelBase
    {

    [ObservableProperty]
    public ObservableCollection<CategoriesModel> _CategoriesDataList;
    [ObservableProperty]
    public ObservableCollection<CategoriesModel> _BestSellingDataList;
    [ObservableProperty]
    public ObservableCollection<CategoriesModel>_FeaturedBrandsDataList;
    [ObservableProperty]
    public ObservableCollection<CategoriesModel> _ProductList;
        // public readonly ApiService _apiService;
    private readonly IApiServices _apiService;
    public bool IsVisible { get; set; }
    public const string ProductsJsonFileName = "products.json";
    public readonly BrandDetailViewModel _brandDetailViewModel;
    private readonly INavigationService _navigationservice;
    [ObservableProperty]
    private bool isLoading;
        
    public bool IsNotLoading => !IsLoading;

        public HomePageViewModel( INavigationService navigationService, IApiServices apiService) :base(navigationService)
        {

            _apiService = apiService;
        
             var _ = CallUrlMethodAsync();
            
         
        }



        public async Task CallUrlMethodAsync()

        {
            IsLoading = true;

            ObservableCollection<CategoriesModel> allCategoriesData = await _apiService.GetAsync<ObservableCollection<CategoriesModel>>(ProductsJsonFileName);


            var uniqueBrandAndImagePairs = allCategoriesData.GroupBy(item => item.brand)
                                          .Select(group => new CategoriesModel
                                          {
                                              brand = group.Key,
                                              image_link = group.First().image_link 
                                          });

             FeaturedBrandsDataList = new ObservableCollection<CategoriesModel>(uniqueBrandAndImagePairs);

            var uniqueCatrgoryList = allCategoriesData.GroupBy(item => item.category)
                                      .Select(group => new CategoriesModel
                                      {
                                          CategoryName = group.Key,
                                          image_link = group.First().image_link
                                      });

            CategoriesDataList = new ObservableCollection<CategoriesModel>(uniqueCatrgoryList);



            var uniqueProductList = allCategoriesData.GroupBy(item => item.product_type)
                                      .Select(group => new CategoriesModel
                                      {
                                          product_type = group.Key,
                                          image_link = group.First().image_link
                                      });



            ProductList = new ObservableCollection<CategoriesModel>(uniqueProductList);

            IsLoading = false;
            OnPropertyChanged(nameof(IsNotLoading));
        }



       


        [RelayCommand]
        private async Task BrandTap(CategoriesModel obj)
        {

            await NavigationService.NavigateToAsync(
           "BrandDetail", new Dictionary<string, object>
           {
               [nameof(BrandDetailViewModel.BrandProduct)] = obj.brand
           });

        }

        [RelayCommand]
        private async Task CategoryTap(CategoriesModel obj)
        {
            await NavigationService.NavigateToAsync(
           "CategoryDetail", new Dictionary<string, object>
           {
               [nameof(CategoryDetailViewModel.CategoriesProduct)] = obj.CategoryName
           });
        }

        [RelayCommand]
        private async Task ProductTap(CategoriesModel obj)
        {

            await NavigationService.NavigateToAsync(
          "ProductAllType", new Dictionary<string, object>
          {
              [nameof(ProductAllTypeViewModel.ProductType)] = obj.product_type
          });

        }

       

    }
}
    


   

