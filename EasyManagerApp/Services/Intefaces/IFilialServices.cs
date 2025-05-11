using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Filial;
using System.Security.Claims;

namespace EasyManagerApp.Services.Intefaces;
public interface IFilialServices<F> where F : FilialDto
{
    Task<RequestResult<FilialDto>> CadastrarFilial(FilialDtoCreate filialDtoCreate, string token);

    //passa token
    //consulta do cliente via token
    Task<RequestResult<IEnumerable<FilialDto>>> ConsultarFilialById(string token);
}
