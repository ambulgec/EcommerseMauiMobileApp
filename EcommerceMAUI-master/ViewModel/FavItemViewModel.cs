using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.HttpServices;
using EcommerceMAUI.Services.Repository;
using EcommerceMAUI.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel;

public partial class FavItemViewModel : ViewModelBase
{
   
    [ObservableProperty]
    private ObservableCollection<UserFav> _allProductDataList;
    private IApiServices _apiService;
    private IUserRepository _userRepository;

    

    public FavItemViewModel(IApiServices apiService, BrandDetailViewModel brandDetailViewModel, INavigationService navigationService, IUserRepository userRepository) : base(navigationService)
    {

        _apiService = apiService;
        _userRepository = userRepository;
      

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




    private async void FetchCardData()
    {
        int UserId = Preferences.Get("UserId", -1);
        

        Expression<Func<UserFav, bool>> predicate = u => u.UserId == UserId;

        IEnumerable<UserFav> matchingUsers = await _userRepository.GetFileteredAsync<UserFav>(predicate);

        AllProductDataList = new ObservableCollection<UserFav>(matchingUsers);


        
    }

    [RelayCommand]
    private async Task DeleteProduct(UserFav productId)
    {
         bool delteProduct = await _userRepository.DeleteItemByKeyAsync<UserFav>(productId.ProductsFavId);
        
        AllProductDataList.Remove(productId);

       
       
    }
}
