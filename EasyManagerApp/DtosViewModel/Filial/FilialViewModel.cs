using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyManagerApp.Dtos.Filial;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.DtosViewModel.Filial;
public partial class FilialViewModel : ObservableObject
{
    private readonly IFilialServices<FilialDto> _filialServices;
    private string _token;

    public FilialViewModel(IFilialServices<FilialDto> filialServices)
    {
        _filialServices = filialServices;
    }

    [ObservableProperty]
    private ObservableCollection<FilialDto> filiaisDtos = new();
    //[ObservableProperty]
    //private FilialDto? filialSelecionada;

    [ObservableProperty]
    private string? nomeFilial;

    public async Task InitializeAsync()
    {
        await GetAllFiliais();
    }


    [RelayCommand]
    public async Task GetAllFiliais()
    {
        _token = await SecureStorage.GetAsync("token") ?? string.Empty;

        var result = await _filialServices.ConsultarFilialById(_token);
        if (result.Status)
        {
            FiliaisDtos.Clear();

            foreach (var item in result.Data)
            {
                FiliaisDtos.Add(item);
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", result.Mensagem, "OK");
        }
    }

    [RelayCommand]
    public async Task CadastrarFilialAsync()
    {

        var filialDtoCreate = new FilialDtoCreate(nomeFilial);


        var token = await SecureStorage.GetAsync("token") ?? string.Empty;
        var result = await _filialServices.CadastrarFilial(filialDtoCreate, token);
        if (result.Status)
        {
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Filial cadastrada com sucesso!", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", result.Mensagem, "OK");
        }

    }
}
