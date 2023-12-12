using CommunityToolkit.Mvvm.Input;
//using EcommerceMAUI.Data;
using EcommerceMAUI.Model;
using EcommerceMAUI.Services.Repository;
using EcommerceMAUI.ViewModel;
using Syncfusion.Maui.Core.Internals;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace EcommerceMAUI.Views;

public partial class LoginPage : ContentPage
{
    private readonly IUserRepository _userRepository;
    public UserTable usertable;

   // private readonly DatabaseContext _contestss;

    public readonly LoginPageViewModel _loginpage;
    public LoginPage(LoginPageViewModel loginpage,IUserRepository userRepository)
    {
        InitializeComponent();
       _userRepository = userRepository;
       
        BindingContext = loginpage;
        
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
      string _username = UsernameEntry.Text;
      string _password = PasswordEntry.Text;
        int userIdToFetch = 123;
        var user = new UserTable
        {
            UserName = _username,
            Password = _password
        };


        bool kl =await _userRepository.CreateTableIfNotExists<UserTable>();
        //bool isItemAdded = await _userRepository.AddItemAsync<UserTable>(user);

       bool km=await  _userRepository.AddItemAsync<UserTable>(user);


        Expression<Func<UserTable, bool>> predicate = u => u.UserName == _username && u.Password == _password;

        IEnumerable<UserTable> matchingUsers =await _userRepository.GetFileteredAsync<UserTable>(predicate);



        if (matchingUsers.Count() >0)
        {
            UserTable userToFetch = matchingUsers.FirstOrDefault(u => u.UserId == userIdToFetch);
            int userIdToSave = matchingUsers.First().UserId;
            Preferences.Default.Set("UserId", userIdToSave);
            await Shell.Current.GoToAsync("//home");
        }
        else
        {
            await DisplayAlert("Authentication Failed", "Please check your username and password.", "OK");
        }

       
        // await Shell.Current.GoToAsync("//home");

        //  var GetAlluserdsata = _userRepository.GetAll();



        //  bool auth = await _userRepository.CheckUserCredentials("_username", "_password");
        // int Userid = _userRepository.GetUserIdCheckUserCredentials<UserTable>(_username, _password);

        // bool isCredentialsValid =await  _userRepository.CheckUserCredentials<UserTable>(_username, _password);
        //   Preferences.Default.Set("UserId", Userid);



        ////  int UserId = Preferences.Default.Get("UserId", -1);
        //  if (isCredentialsValid)
        //  {
        //      //int Userid = _userRepository.GetuserId(_username, _password);
        //   //   Preferences.Default.Set("UserId", Userid);



        //   //   int UserId = Preferences.Default.Get("UserId", -1);
        //      await Shell.Current.GoToAsync("//home");
        //      //await NavigationService.NavigateToAsync(
        //      // "BrandDetail");
        //  }
        //  else
        //  {
        //      await DisplayAlert("Authentication Failed", "Please check your username and password.", "OK");
        //  }

    }
  
    private void OnForgotPasswordClicked(object sender, EventArgs e)
    {
       
        DisplayAlert("Forgot Password", "Feature coming soon!", "OK");
    }

}
