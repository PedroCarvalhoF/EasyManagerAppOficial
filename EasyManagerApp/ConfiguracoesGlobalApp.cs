using EasyManagerApp.Dtos.Filial;

namespace EasyManagerApp;
public static class ConfiguracoesGlobalApp
{
    private static List<FilialDto> _filiais = new List<FilialDto>();
    private static FilialDto? _filialSelecionada { get; set; }
    public static FilialDto AtualizarFilialSelecionada(FilialDto fililal)
    {
        _filialSelecionada = fililal;

        return GetFilialSelecionada();
    }
    public static void AtualizarFilialSelecionada(List<FilialDto> filiais)
    {
        _filiais.Clear();
        _filiais.AddRange(filiais);
    }
    public static FilialDto GetFilialSelecionada()
    => _filialSelecionada ?? throw new ArgumentException("Filial não localizada");
    public static List<FilialDto> GetFiliais()
    => _filiais;
}
