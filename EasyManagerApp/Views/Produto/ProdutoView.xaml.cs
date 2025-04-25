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

    private async void btnProdutoEditar_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is ProdutoDto produto)
        {
            // Obter o ViewModel diretamente do contêiner de injeção de dependência
            var viewModel = App.Services.GetRequiredService<ProdutoViewModel>();

            // Defina a ação que deseja (por exemplo, AcoesTeleEnum.Alterar)
            AcoesTeleEnum acao = AcoesTeleEnum.Alterar;

            viewModel.ProdutoSelecionado = produto;
            // Navegue para a ProdutosPageEditar passando os três parâmetros
            await Navigation.PushAsync(new ProdutosPageEditar(viewModel, produto, acao));
        }
    }



}