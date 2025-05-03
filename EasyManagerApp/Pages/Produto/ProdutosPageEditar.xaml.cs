using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.Dtos.Produto.UnidadeMedida;
using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.Helper.Enum;
using EasyManagerApp.Services.Intefaces;

namespace EasyManagerApp.Pages.Produto;

public partial class ProdutosPageEditar : ContentPage
{
    private readonly ProdutoViewModel _viewModel;
    private readonly ProdutoDto _produto;
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;
    private readonly IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto> _unidadeMedidaProdutoServices;
    private AcoesTeleEnum _acaoTelaSelecionado;
    public ProdutosPageEditar(ProdutoViewModel viewModel, AcoesTeleEnum acao)
    {
        InitializeComponent();

        _viewModel = viewModel;  // O ViewModel é injetado aqui               

        BindingContext = _viewModel;
        _acaoTelaSelecionado = acao;

        _categoriaProdutoServices = App.Services.GetRequiredService<ICategoriaProdutoServices>();
        _unidadeMedidaProdutoServices = App.Services.GetRequiredService<IUnidadeMedidaProdutoServices<UnidadeMedidaProdutoDto>>();

        switch (acao)
        {
            case AcoesTeleEnum.Cadastrar:
                btnSalvar.Text = "Cadastrar";
                //lblId.IsVisible = false;
                break;
            case AcoesTeleEnum.Alterar:
                // lblId.IsVisible = true;
                //lblId.Text = $"id: {_viewModel.ProdutoSelecionado.Id}"; ;
                txtNomeProduto.Text = _viewModel.ProdutoSelecionado.NomeProduto;
                txtCodigoProduto.Text = _viewModel.ProdutoSelecionado.CodigoProduto;

                break;
            default:
                break;
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();


        try
        {
            var categoria = await _categoriaProdutoServices.ConsultarCategoriasProdutos<CategoriaProdutoDto>(await SecureStorage.GetAsync("token") ?? string.Empty, default);

            if (categoria.Status)
            {
                pctCategoria.ItemsSource = categoria.Data.ToList();

                if (_acaoTelaSelecionado == AcoesTeleEnum.Alterar)
                {
                    var categoriaSelecionada = categoria.Data
                        .FirstOrDefault(c => c.Id == _viewModel.ProdutoSelecionado.CategoriaProdutoEntityId);

                    pctCategoria.SelectedItem = categoriaSelecionada;
                }

            }


            var unidade = await _unidadeMedidaProdutoServices.SelectAsync();
            if (unidade.Status)
            {
                pckUnidadeMedida.ItemsSource = unidade.Data.ToList();

                if (_acaoTelaSelecionado == AcoesTeleEnum.Alterar)
                {
                    var unidadeSelecionada = unidade.Data
                    .FirstOrDefault(u => u.Id == _viewModel.ProdutoSelecionado.UnidadeMedidaProdutoEntityId);
                    pckUnidadeMedida.SelectedItem = unidadeSelecionada;
                }
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Atenção", ex.Message, "Ok");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (_acaoTelaSelecionado)
            {
                case AcoesTeleEnum.Cadastrar:

                    var produtoCreate = new ProdutoDtoCreate
                    {
                        CategoriaProdutoEntityId = ((CategoriaProdutoDto)pctCategoria.SelectedItem).Id,
                        CodigoProduto = txtCodigoProduto.Text,
                        NomeProduto = txtNomeProduto.Text,
                        UnidadeMedidaProdutoId = ((UnidadeMedidaProdutoDto)pckUnidadeMedida.SelectedItem).Id
                    };

                    await _viewModel.CadastrarAsync(produtoCreate);

                    break;
                case AcoesTeleEnum.Alterar:


                    var produtoudpate = new ProdutoDtoUpdate
                    {
                        CategoriaProdutoEntityId = ((CategoriaProdutoDto)pctCategoria.SelectedItem).Id,
                        CodigoProduto = txtCodigoProduto.Text,
                        NomeProduto = txtNomeProduto.Text,
                        UnidadeMedidaProdutoId = ((UnidadeMedidaProdutoDto)pckUnidadeMedida.SelectedItem).Id,
                        Id = _viewModel.ProdutoSelecionado.Id
                    };

                    await _viewModel.AlterarAsync(produtoudpate);

                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Atenção", ex.Message, "Ok");
        }
    }
}