using CommunityToolkit.Mvvm.ComponentModel;
using EasyManagerApp.Dtos.Role;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Role;

[ObservableObject]
public partial class UserRoleViewModel
{
    private readonly IUserRoleServices<RoleDto> _userRoleServices;

    public ObservableCollection<RoleDto> RolesPermissoes { get; set; } = new ObservableCollection<RoleDto>();
    public UserRoleViewModel(IUserRoleServices<RoleDto> userRoleServices)
    {
        _userRoleServices = userRoleServices;
    }    
    public async Task InitAsync()
    {
        try
        {
            var resultResponse = await _userRoleServices.SelectRolesAscyn(await SecureStorage.GetAsync("token") ?? throw new Exception("Não foi possível localizar token"));
            if (!resultResponse.Status)
                throw new Exception(resultResponse.Mensagem ?? "Erro inesperado. Verifique a conexão.");

            if (resultResponse.Data == null)
                return;

            RolesPermissoes.Clear();
            foreach (var item in resultResponse.Data)
                RolesPermissoes.Add(item);
        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
