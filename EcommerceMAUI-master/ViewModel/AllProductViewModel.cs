

//using Android.Accounts;
//using Android.Accounts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.HttpServices;
using EcommerceMAUI.ViewModel.Base;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    public partial class AllProductViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<CategoriesModel> _originalData;

        [ObservableProperty]

        //[NotifyCanExecuteChangedFor(nameof(ApplyFilterCommand))]
        public double _userEnterPrice;


       
        public double _klm;
        public ICommand TapCommand { get; private set; }


        [ObservableProperty]
        public ObservableCollection<CategoriesModel> _allProductDataList ;
        private IApiServices _apiService;

      


        public AllProductViewModel(IApiServices apiService, BrandDetailViewModel brandDetailViewModel, INavigationService navigationService) : base(navigationService)
        {

            _apiService = apiService;
            var _ = LoadData();
        }


        private async Task LoadData()
        {
           
            await CallUrlMethodAsync();
            OriginalData = new ObservableCollection<CategoriesModel>(AllProductDataList);
        }

        [RelayCommand]
        private void ApplyFilter()
        {
           var Klm = UserEnterPrice;

            if (Klm  > 0)
            {
                double priceToFilter = UserEnterPrice;
                
                var filteredList = OriginalData.Where(item =>
                {
                    if (double.TryParse(item.price, out double price))
                    {
                        
                        return price == priceToFilter;
                    }
                   
                    return false;
                }).ToList();

                AllProductDataList.Clear();
                foreach (var item in filteredList)
                {
                    AllProductDataList.Add(item);
                }
                UserEnterPrice = 0;
            }
            else
            {
             
                AllProductDataList.Clear();
                foreach (var item in OriginalData)
                {
                    AllProductDataList.Add(item);
                }
            }
          
        }





        //private void CommandInit()
        //{
        //    TapCommand = new Command<ProductListModel>(items =>
        //    {
        //        Application.Current.MainPage.Navigation.PushModalAsync(new
        //            ());
        //    });



        //}


        public async Task CallUrlMethodAsync()
        {

            AllProductDataList= await _apiService.GetAsync<ObservableCollection<CategoriesModel>>("products.json");
           
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
