using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EcommerceMAUI.Converters;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.Repository;
using EcommerceMAUI.ViewModel.Base;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    [QueryProperty(nameof(ProductInDetails), "ProductInDetails")]
    public partial class ProductDetailsViewModel : ViewModelBase
    {



        [Obsolete]
        public Color AddToFavButtonBackgroundColor => IsInFavorites ? Color.FromHex("#000000") : Color.FromHex("#FF0000");


        [ObservableProperty]
        private bool _IsInFavorites;

        public bool AddToFavButtonEnabled => !IsInFavorites;

        double lastScrollIndex;
        double currentScrollIndex;

        [ObservableProperty]
        public CategoriesModel _productDetails;
        [ObservableProperty]
        public CategoriesModel _productDetailss;
        [ObservableProperty]
        public CategoriesModel _productInDetails;

        public ObservableCollection<CategoriesModel> CartItems { get; set; }


        [ObservableProperty]
        private bool isLoading;

        public bool IsNotLoading => !IsLoading;

        private UserFav userfav;


        private UserProduct adduserProduct;

      

   

        private readonly IUserRepository _userRepository;

        public   ClassConverter _classConverter;
      

        [ObservableProperty]
        public CategoriesModel _ProductDetail;
        [ObservableProperty]
        public bool _IsFooterVisible = false;
        
        [ObservableProperty]
        public bool _IsFavorite;
      

        [ObservableProperty]
        private bool _isLoginEnabled;

        public ProductDetailsViewModel(INavigationService navigationService, UserRepository userRepository,ClassConverter classConverter) : base(navigationService)
        {
            _userRepository = userRepository;
           _classConverter = classConverter;


          
        }

        [Obsolete]
        private  async  Task CheckProductallreadyInFav(int lm)
        {
            Expression<Func<UserFav, bool>> predicate = u => u.ProductId == lm;
            UserFav kl = await _userRepository.GetItemByKeyAsync<UserFav>(lm);

           if(kl.ProductId ==lm)
            {
                IsFavorite = false;
                OnPropertyChanged(nameof(AddToFavButtonBackgroundColor));
                OnPropertyChanged(nameof(AddToFavButtonEnabled));
            }
            else
            {
                IsFavorite = true;
                OnPropertyChanged(nameof(AddToFavButtonBackgroundColor));
                OnPropertyChanged(nameof(AddToFavButtonEnabled));
            }
        }

        public override async Task InitializeAsync()
        {
            await IsBusyFor(
            () =>
            {
                IsLoading = true;
                ProductDetails = ProductInDetails;
                int kl = ProductDetails.id;

               checkProductallreadyInFav(kl);

                IsLoading = false;
                OnPropertyChanged(nameof(IsNotLoading));
                return Task.CompletedTask;
            });
        }

        [RelayCommand]
        public  async Task AddToCart(CategoriesModel pductDetail)
        {
            adduserProduct = _classConverter.ConvertToTargets(pductDetail);
            bool result = await _userRepository.AddItemAsync<UserProduct>(adduserProduct);
           
            await Application.Current.MainPage.DisplayAlert("Added to Cart", "Product has been added to your cart.", "OK");
        }

        //[RelayCommand]
        //public async Task AddToFav(CategoriesModel pductDetail)
        //{
        //    userfav = _classConverter.ConvertToFavTargets(pductDetail);
        //    bool result = await _userRepository.AddItemAsync<UserFav>(userfav);
        //    IsInFavorites = true;
        //    OnPropertyChanged(nameof(AddToFavButtonBackgroundColor));

        //}

        [RelayCommand]
        public async Task AddToFav(CategoriesModel pductDetail)
        {
            userfav = _classConverter.ConvertToFavTargets(pductDetail);
            bool result = await _userRepository.AddItemAsync<UserFav>(userfav);
            IsInFavorites = true;
            RefreshButtonColor(); 
        }

        private async Task checkProductallreadyInFav(int lm)
        {
            Expression<Func<UserFav, bool>> predicate = u => u.ProductId == lm;
            UserFav kl = await _userRepository.GetItemByKeyAsync<UserFav>(lm);

            if (kl.ProductId == lm)
            {
                IsFavorite = false;
            }
            else
            {
                IsFavorite = true;
            }

            RefreshButtonColor(); 
        }


        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        
        public void ChageFooterVisibility(double currentY)
        {
            currentScrollIndex = currentY;
            if (currentScrollIndex > lastScrollIndex)
            {
                IsFooterVisible = true;
            }
            else
            {
                IsFooterVisible = true;
            }
            lastScrollIndex = currentScrollIndex;
        }


        public void RefreshButtonColor()
        {
            OnPropertyChanged(nameof(AddToFavButtonBackgroundColor));
            OnPropertyChanged(nameof(AddToFavButtonEnabled));
        }


    }
}
