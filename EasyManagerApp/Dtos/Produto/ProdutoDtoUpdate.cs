﻿namespace EasyManagerApp.Dtos.Produto;
public class ProdutoDtoUpdate
{
    public Guid Id { get; set; }
    public string NomeProduto { get; set; }
    public string CodigoProduto { get; set; }
    public Guid CategoriaProdutoEntityId { get; set; }
    public Guid UnidadeMedidaProdutoId { get; set; }
}
