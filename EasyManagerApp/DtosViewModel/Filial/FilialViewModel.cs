using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Filial;
public partial class FilialViewModel : ObservableObject
{
    private readonly IFilialServices<FilialDto> _filialServices;

    public FilialViewModel(IFilialServices<FilialDto> filialServices)
    {
        _filialServices = filialServices;
    }

    [ObservableProperty]
    private ObservableCollection<FilialDto> filiaisDtos = new();
    [ObservableProperty]
    private FilialDto? filialSelecionada;

    [ObservableProperty]
    private string? nomeProduto;

    [ObservableProperty]
    private string? nomeFilial;


    [RelayCommand]
    public async Task GetAllFiliais()
    {
        var token = await SecureStorage.GetAsync("token") ?? string.Empty;

        var result = await _filialServices.SelectAllAsync(token);
        if (result.Status)
        {
            FiliaisDtos = new ObservableCollection<FilialDto>(result.Data);
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", result.Mensagem, "OK");
        }
    }
}
