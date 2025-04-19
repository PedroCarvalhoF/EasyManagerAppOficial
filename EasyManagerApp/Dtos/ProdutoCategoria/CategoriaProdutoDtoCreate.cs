using System.ComponentModel.DataAnnotations;

namespace EasyManagerApp.Dtos.ProdutoCategoria;
public class CategoriaProdutoDtoCreate
{
    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome da categoria deve ter entre 2 e 100 caracteres.")]
    public string NomeCategoria { get; set; }
    public CategoriaProdutoDtoCreate(string nomeCategoria)
    {
        NomeCategoria = nomeCategoria;
    }
}
