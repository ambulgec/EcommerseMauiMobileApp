


using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using EcommerceMAUI.Data;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.HttpServices;
using EcommerceMAUI.Services.Repository;
using EcommerceMAUI.ViewModel.Base;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    public partial class CartViewModel : ViewModelBase
    {
        private readonly IUserRepository _userRepository;
     

        [ObservableProperty]
        public ObservableCollection<UserProduct> _AllProductDataList = new ObservableCollection<UserProduct>();
        private IApiServices _apiService;

      


        public CartViewModel(IApiServices apiService, BrandDetailViewModel brandDetailViewModel, INavigationService navigationService, IUserRepository userRepository) : base(navigationService)
        {

            _apiService = apiService;
            _userRepository = userRepository;
           // FetchData();

        }


        public override async Task InitializeAsync()
        {
            await IsBusyFor(
            () =>
            {
                FetchCardData();
                return Task.CompletedTask;
            });
        }


       

        public decimal TotalPrice
        {
            get { return AllProductDataList.Sum(item => item.Price); }
        }
        private async void FetchCardData()
        {

            int UserId = Preferences.Default.Get("UserId", -1);
            Expression<Func<UserProduct, bool>> predicate = u => u.UserId == UserId;

            IEnumerable<UserProduct> matchingUsers = await _userRepository.GetFileteredAsync<UserProduct>(predicate);

            AllProductDataList = new ObservableCollection<UserProduct>(matchingUsers);
            OnPropertyChanged("TotalPrice");
        }

        [RelayCommand]
        private async Task DeleteProduct(UserProduct productId)
        {
            bool delteProduct = await _userRepository.DeleteItemByKeyAsync<UserProduct>(productId.UserProductId);
          
            AllProductDataList.Remove(productId);
            OnPropertyChanged("TotalPrice");
        }

        
    }
}

