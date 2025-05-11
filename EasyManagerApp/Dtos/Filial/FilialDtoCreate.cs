namespace EasyManagerApp.Dtos.Filial;
public class FilialDtoCreate
{
    public string NomeFilial { get; private set; }
    public FilialDtoCreate(string nomeFilial)
    {
        NomeFilial = nomeFilial;
    }
}
