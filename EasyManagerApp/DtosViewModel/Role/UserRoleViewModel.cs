using CommunityToolkit.Mvvm.ComponentModel;
using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Role;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Role;

[ObservableObject]
public partial class UserRoleViewModel
{
    private readonly IUserRoleServices<RoleDto> _userRoleServices;

    public ObservableCollection<RoleDto> RolesPermissoes { get; set; } = new ObservableCollection<RoleDto>();
    public ObservableCollection<RoleUserDto> RolesPermissoesUser { get; set; } = new ObservableCollection<RoleUserDto>();
    public ObservableCollection<RoleDto> RolesUsersAtivas { get; set; } = new ObservableCollection<RoleDto>();

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
            {
                // Set default descriptions based on role names
                item.Description = GetRoleDescription(item.RoleName);
                RolesPermissoes.Add(item);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
    private string GetRoleDescription(string? roleName)
    {
        return roleName?.ToLower() switch
        {
            "programador" => "Acesso total ao sistema com todas as permissões",
            "admin" => "Acesso administrativo para gerenciar usuários e configurações",
            "supervisor" => "Acesso para supervisionar operações e relatórios",
            "auxiliarcozinha" => "Acesso básico para auxiliar nas operações da cozinha",
            "cozinheiro" => "Acesso para gerenciar operações da cozinha",
            "copeiro" => "Acesso para gerenciar operações de copa",
            _ => "Permissão personalizada"
        };
    }
    public List<RoleDto> GetSelectedRoles()
    {
        return RolesPermissoes.Where(r => r.IsSelected).ToList();
    }
    public async Task<RequestResult<RoleUserDto>> SelectRolesUserAscyn(DtoRequestId requestId)
    {
        try
        {
            var token = await SecureStorage.GetAsync("token")
                         ?? throw new Exception("Não foi possível localizar token");

            var resultResponse = await _userRoleServices.SelectRolesUserAscyn(token, requestId);

            if (!resultResponse.Status)
                throw new Exception(resultResponse.Mensagem ?? "Erro inesperado. Verifique a conexão.");

            // Atualiza os RoleUserDto
            RolesPermissoesUser.Clear();
            if (resultResponse.Data != null)
            {
                RolesPermissoesUser.Add(resultResponse.Data);
            }

            RolesUsersAtivas.Clear();

            if (resultResponse.Data?.Roles != null)
            {
                foreach (var item in resultResponse.Data.Roles.OrderBy(u => u.RoleName))
                {
                    RolesUsersAtivas.Add(item);
                }
            }

            return resultResponse;
        }
        catch (Exception ex)
        {
            return new RequestResult<RoleUserDto>(ex);
        }
    }
    public async Task AdcionarRoleUser(RoleDtoAddRoleUser roleDtoAddRoleUser)
    {
        try
        {
            var token = await SecureStorage.GetAsync("token")
                         ?? throw new Exception("Não foi possível localizar token");
            var resultResponse = await _userRoleServices.AdcionarRoleUser(token, roleDtoAddRoleUser);
            if (!resultResponse.Status)
                throw new Exception(resultResponse.Mensagem ?? "Erro inesperado. Verifique a conexão.");


            await SelectRolesUserAscyn(new DtoRequestId(roleDtoAddRoleUser.UserId));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    public async Task RemoverRoleUser(RoleDtoRemoverRoleUser removerRoleUser)
    {
        try
        {
            var token = await SecureStorage.GetAsync("token")
                         ?? throw new Exception("Não foi possível localizar token");

            var resultResponse = await _userRoleServices.RemovarRoleUser(token, removerRoleUser);
            if (!resultResponse.Status)
                throw new Exception(resultResponse.Mensagem ?? "Erro inesperado. Verifique a conexão.");


            await SelectRolesUserAscyn(new DtoRequestId(removerRoleUser.UserId));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
