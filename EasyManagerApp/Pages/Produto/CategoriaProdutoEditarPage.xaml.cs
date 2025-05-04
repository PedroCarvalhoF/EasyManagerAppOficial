using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Helper.Enum;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.Produto;

public partial class CategoriaProdutoEditarPage : ContentPage
{
    public CategoriaProdutoDto? CategoriaProdutoDtoSelecionada;
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;
    AcoesTeleEnum _acaoTelaSelecionada;

    public CategoriaProdutoEditarPage(CategoriaProdutoDto? categoriaProdutoDtoSelecionada, ICategoriaProdutoServices iCategoriaProdutoServices, AcoesTeleEnum acaoTelaSelecionada)
    {
        InitializeComponent();
        CategoriaProdutoDtoSelecionada = categoriaProdutoDtoSelecionada;
        _categoriaProdutoServices = iCategoriaProdutoServices;
        _acaoTelaSelecionada = acaoTelaSelecionada;

        switch (_acaoTelaSelecionada)
        {
            case AcoesTeleEnum.Cadastrar:

                //lblId.IsVisible = false;
                btnAlterar.Text = "Cadastrar";
                chcCategoria.IsVisible = false;
                break;
            case AcoesTeleEnum.Alterar:
                //lblId.IsVisible = true;

                break;
            default:
                break;
        }

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();


    }

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnAlterar_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (_acaoTelaSelecionada)
            {
                case AcoesTeleEnum.Cadastrar:

                    var cat = new CategoriaProdutoDtoCreate(txtCategoria.Text);

                    var result =
                        await _categoriaProdutoServices.
                        CadastrarCategoriaProduto<CategoriaProdutoDto>(await SecureStorage.GetAsync("token") ?? string.Empty, cat, new CancellationToken());

                    if (result.Status)
                    {
                        await DisplayAlert("Sucesso", "Categoria cadastrada com sucesso.", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Erro", result.Mensagem, "OK");
                    }


                    break;
                case AcoesTeleEnum.Alterar:

                    var catUpdate = new CategoriaProdutoDtoUpdate(CategoriaProdutoDtoSelecionada.Id, txtCategoria.Text, chcCategoria.IsChecked);
                    var resultUpdate = await _categoriaProdutoServices.AlterarCategoriaProduto<CategoriaProdutoDto>(await SecureStorage.GetAsync("token") ?? string.Empty, catUpdate, new CancellationToken());

                    if (resultUpdate.Status)
                    {
                        await DisplayAlert("Sucesso", "Categoria atualizada com sucesso.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Erro", resultUpdate.Mensagem, "OK");
                    }
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erro.", ex.Message, "OK");
        }
    }
}