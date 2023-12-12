﻿using EcommerceMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EcommerceMAUI.ViewModel.Base;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
{
    private long _isBusy;

    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

    [ObservableProperty]
    private bool _isInitialized;

    public INavigationService NavigationService { get; }

    public IAsyncRelayCommand InitializeAsyncCommand { get; }
    public bool IsInitializeds { get; private set; }

    public ViewModelBase(INavigationService navigationService)
    {
        NavigationService = navigationService;

        InitializeAsyncCommand =
            new AsyncRelayCommand(
               async  () =>
                {
                    await IsBusyFor(InitializeAsync);
                    IsInitialized = true;
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }


    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

  
    public async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }

   
}

