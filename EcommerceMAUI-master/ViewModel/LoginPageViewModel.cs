using EcommerceMAUI.Model;
//using EcommerceMAUI.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EcommerceMAUI.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private string _emailError;
        private string _passwordError;

        private bool _isLoginEnabled;
        public bool IsLoginEnabled
        {
            get => _isLoginEnabled;
            set
            {
                if (_isLoginEnabled != value)
                {
                    _isLoginEnabled = value;
                    OnPropertyChanged(nameof(IsLoginEnabled));
                }
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    ValidateEmail();
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    ValidatePassword();
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string EmailError
        {
            get => _emailError;
            set
            {
                if (_emailError != value)
                {
                    _emailError = value;
                    OnPropertyChanged(nameof(EmailError));
                }
            }
        }
        public string PasswordError
        {
            get => _passwordError;
            set
            {
                if (_passwordError != value)
                {
                    _passwordError = value;
                    OnPropertyChanged(nameof(PasswordError));
                }
            }
        }



        //public event PropertyChangedEventHandler PropertyChanged;



        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}



        private void ValidateEmail()
        {
            // Email validation logic
            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Email is required.";
            }
            else if (!Email.EndsWith("@gmail.com"))
            {
                EmailError = "Email must end with @gmail.com.";
            }
            else
            {
                EmailError = null;
            }



            // Check both fields for enabling/disabling the Login button
            IsLoginEnabled = string.IsNullOrEmpty(PasswordError) && string.IsNullOrEmpty(EmailError) && !string.IsNullOrWhiteSpace(Password); ;
        }



        private void ValidatePassword()
        {
            // Password validation logic
            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = "Password is required.";
            }
            else if (Password.Length < 6)
            {
                PasswordError = "Password must be at least 6 characters long.";
            }
            else if (!Regex.IsMatch(Password, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@#$%^&+=]).{6,}$"))
            {
                PasswordError = "Password must contain at least one letter, one number, one special character.";
            }
            else
            {
                PasswordError = null;
            }



            // Check both fields for enabling/disabling the Login button
            IsLoginEnabled = string.IsNullOrEmpty(PasswordError) && string.IsNullOrEmpty(EmailError) && !string.IsNullOrWhiteSpace(Email);
        }
    }
}

