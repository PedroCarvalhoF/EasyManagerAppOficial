namespace EasyManagerApp.Dtos.Filial;
public class FilialDtoUpdate
{
    public Guid IdFilial { get; private set; }
    public string NomeFilial { get; set; }
    public FilialDtoUpdate(Guid idFilial, string nomeFilial)
    {
        IdFilial = idFilial;
        NomeFilial = nomeFilial;
    }
}
