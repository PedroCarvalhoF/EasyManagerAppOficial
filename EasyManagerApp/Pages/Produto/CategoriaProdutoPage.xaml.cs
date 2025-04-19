using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Helper.Enum;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;

namespace EasyManagerApp.Pages.Produto;
public partial class CategoriaProdutoPage : ContentPage
{
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;

    private IEnumerable<CategoriaProdutoDto> _categorias = new List<CategoriaProdutoDto>();
    private ObservableCollection<CategoriaProdutoDto> _categoriasProdutosDtos = new ObservableCollection<CategoriaProdutoDto>();
    private string _tonken = string.Empty;

    public CategoriaProdutoPage(ICategoriaProdutoServices categoriaProdutoServices)
    {
        InitializeComponent();
        _categoriaProdutoServices = categoriaProdutoServices;

        // Define o template com o evento EditarClicked
        cvCategoriaProduto.ItemTemplate = new DataTemplate(() =>
        {
            var view = new Views.ProdutoCategoria.CategoriaProdutoView();
            view.EditarClicked += CategoriaProdutoView_EditarClicked;
            return view;
        });

        cvCategoriaProduto.ItemsSource = _categoriasProdutosDtos;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _tonken = await SecureStorage.GetAsync("token");
        await ConsultarCategorias();
    }

    private async Task ConsultarCategorias()
    {
        var result = await _categoriaProdutoServices.ConsultarCategoriasProdutos<CategoriaProdutoDto>(_tonken, default);

        if (result != null && result.Data != null && result.Status)
        {
            _categorias = result.Data;
            _categoriasProdutosDtos.Clear();

            foreach (var item in result.Data)
            {
                _categoriasProdutosDtos.Add(item);
            }
        }
        else
        {
            await DisplayAlert("Erro", "Não foi possível carregar as categorias de produtos.", "OK");
        }
    }

    private async void CategoriaProdutoView_EditarClicked(object? sender, CategoriaProdutoDto categoria)
    {
        var paginaEdicao = new CategoriaProdutoEditarPage(categoria, _categoriaProdutoServices, AcoesTeleEnum.Alterar)
        {
            BindingContext = categoria
        };

        await Navigation.PushAsync(paginaEdicao);
    }
    private async void sBarCategoriaProduto_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            var strConsulta = e.NewTextValue.ToLower();

            if (string.IsNullOrEmpty(strConsulta))
            {
                _categoriasProdutosDtos.Clear();
                foreach (var item in _categorias)
                {
                    _categoriasProdutosDtos.Add(item);
                }
                return;
            }

            var categoriasFiltradas = _categorias.Where(cat => cat.NomeCategoria.ToLower().Contains(strConsulta)).ToList();

            _categoriasProdutosDtos.Clear();
            foreach (var item in categoriasFiltradas)
            {
                _categoriasProdutosDtos.Add(item);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "ok");
        }
    }

    private async void btnCadastrarCategoria_Clicked(object sender, EventArgs e)
    {
        var paginaEdicao = new CategoriaProdutoEditarPage(null, _categoriaProdutoServices, AcoesTeleEnum.Cadastrar);

        await Navigation.PushAsync(paginaEdicao);

        await ConsultarCategorias();
    }
}
