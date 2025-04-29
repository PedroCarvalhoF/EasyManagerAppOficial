using EasyManagerApp.Dtos.Produto;
using EasyManagerApp.DtosViewModel.Produto;
using EasyManagerApp.Helper.Enum;
using EasyManagerApp.Pages.Produto;
using System.Windows.Input;

namespace EasyManagerApp.Views.Produto;

public partial class ProdutoView : ContentView
{
    public ProdutoView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty EditarCommandProperty =
      BindableProperty.Create(
          nameof(EditarCommand),
          typeof(ICommand),
          typeof(ProdutoView),
          default(ICommand));

    public ICommand EditarCommand
    {
        get => (ICommand)GetValue(EditarCommandProperty);
        set => SetValue(EditarCommandProperty, value);
    }
    private async void OnProdutoTapped(object sender, EventArgs e)
    {
        try
        {
            if (BindingContext is ProdutoDto produto)
            {
                var viewModel = App.Services.GetRequiredService<ProdutoViewModel>();

                AcoesTeleEnum acao = AcoesTeleEnum.Alterar;

                viewModel.ProdutoSelecionado = produto;

                await Navigation.PushAsync(new ProdutosPageEditar(viewModel, acao));

                await viewModel.CarregarProdutosAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}