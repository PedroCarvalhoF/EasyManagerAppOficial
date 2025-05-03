using EasyManagerApp.Dtos;
using EasyManagerApp.Dtos.Filial;

namespace EasyManagerApp.Services.Intefaces;
public interface IFilialServices<F> where F : FilialDto
{
    Task<RequestResult<IEnumerable<F>>> SelectAllAsync(string token);
}
