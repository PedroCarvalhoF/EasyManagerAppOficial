using EasyManagerApp.DtosViewModel.Role;

namespace EasyManagerApp.Pages.UserRole;

public partial class UserRolePage : ContentPage
{
    private UserRoleViewModel? userRoleViewModel => BindingContext as UserRoleViewModel;

    public UserRolePage(UserRoleViewModel userRoleViewModel)
    {
        InitializeComponent();
        BindingContext = userRoleViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (userRoleViewModel != null)
            await userRoleViewModel.InitAsync();
    }
}