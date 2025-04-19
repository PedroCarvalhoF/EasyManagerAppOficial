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
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        switch (_acaoTelaSelecionada)
        {
            case AcoesTeleEnum.Cadastrar:

                lblId.IsVisible = false;
                btnAlterar.Text = "Cadastrar";
                break;
            case AcoesTeleEnum.Alterar:
                lblId.IsVisible = true;
               

                break;
            default:
                break;
        }
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