

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using EcommerceMAUI.Interfaces;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.HttpServices;
using EcommerceMAUI.ViewModel.Base;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    [QueryProperty(nameof(CategoriesProduct), "CategoriesProduct")]
    public partial class CategoryDetailViewModel : ViewModelBase
    {


        [ObservableProperty]
        public ObservableCollection<CategoriesModel> _AllProductDataList;
        [ObservableProperty]
        public ObservableCollection<ProductListModel> _FeaturedBrandsDataList;
        [ObservableProperty]
        public ObservableCollection<CategoriesModel> _CategoriesData;

        [ObservableProperty]
        public string _CategoriesProduct;
        public string PageTitle
        {
            get
            {
                return CategoryModel.CategoryName;
            }
        }
        CategoriesModel CategoryModel { get; set; }
        [ObservableProperty]
        private bool isLoading;
        public bool IsNotLoading => !IsLoading;
        private IApiServices _apiService;

      //  public bool IsNotLoading => !IsLoading;
        public CategoryDetailViewModel(IApiServices apiService, BrandDetailViewModel brandDetailViewModel, INavigationService navigationService) : base(navigationService)
        {
            _apiService = apiService;
            
        }

        public override async Task InitializeAsync()
        {
            await IsBusyFor(
            async () =>
            {
                IsLoading = true;
                CategoriesData = await _apiService.GetAsync<ObservableCollection<CategoriesModel>>("products.json");
                var dataForCategory = CategoriesData.Where(item => item.category == CategoriesProduct).ToList();
                List<CategoriesModel> productList = dataForCategory;

                ObservableCollection<CategoriesModel> observableCollection = new ObservableCollection<CategoriesModel>(productList);
                AllProductDataList = observableCollection;
                IsLoading = false;
                OnPropertyChanged(nameof(IsNotLoading));
            });
        }




        [RelayCommand]
        private async Task SelectCategories(CategoriesModel obj)
        {
            await NavigationService.NavigateToAsync(
          "ProductType", new Dictionary<string, object>
          {
              [nameof(ProductDetailsViewModel.ProductInDetails)] = obj
          });

        }
        //private async void GoBack(object obj)
        //{
        //    await Application.Current.MainPage.Navigation.PopModalAsync();
        //}
        

    }
}
