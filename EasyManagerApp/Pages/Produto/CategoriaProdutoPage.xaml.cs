using EasyManagerApp.Dtos.ProdutoCategoria;
using EasyManagerApp.Services.Intefaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EasyManagerApp.Pages.Produto;
public partial class CategoriaProdutoPage : ContentPage
{
    private readonly ICategoriaProdutoServices _categoriaProdutoServices;

    private IEnumerable<CategoriaProdutoDto> _categorias = new List<CategoriaProdutoDto>();
    private ObservableCollection<CategoriaProdutoDto> _categoriasProdutosDtos = new ObservableCollection<CategoriaProdutoDto>();

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

        var token = await SecureStorage.GetAsync("token");

        var result = await _categoriaProdutoServices.ConsultarCategoriasProdutos<CategoriaProdutoDto>(token, default);

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
        var paginaEdicao = new CategoriaProdutoEditarPage(categoria, _categoriaProdutoServices)
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
}
