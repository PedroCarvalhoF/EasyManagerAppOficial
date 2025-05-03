namespace EasyManagerApp.Dtos.Produto.Estoque.Movimento;
public class MovimentoEstoqueDtoFiltro
{
    public Guid? IdMovimento { get; private set; } = null;
    public Guid? ProdutoId { get; private set; } = null;
    public Guid? FilialId { get; private set; } = null;
    public string? Tipo { get; private set; } = null;
    public DateTime? DataMovimentacaoInicial { get; private set; } = null;
    public DateTime? DataMovimentacaoFinal { get; private set; } = null;
    public Guid? UsuarioRegistroId { get; private set; } = null;

    public static MovimentoEstoqueDtoFiltro Fitrar_FILIAL_PRODUTO(Guid filialID, Guid produtoID)
    {
        return new MovimentoEstoqueDtoFiltro
        {
            FilialId = filialID,
            ProdutoId = produtoID
        };
    }
}
