using EasyManagerApp.DtosViewModel.Role;

namespace EasyManagerApp.Pages.PageAdmin;

public partial class AdminPage : Shell
{
    private UserRoleViewModel? UserRoleViewModel => BindingContext as UserRoleViewModel;
    public AdminPage(UserRoleViewModel userRoleViewModel)
    {
        InitializeComponent();
        BindingContext = userRoleViewModel;
    }
    protected override async void OnAppearing()
    {
        await UserRoleViewModel.InitAsync();
        base.OnAppearing();
    }
}