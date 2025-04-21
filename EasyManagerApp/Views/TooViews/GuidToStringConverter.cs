using System.Globalization;

namespace EasyManagerApp.Views.TooViews;

public class GuidToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Guid guid)
        {
            return guid.ToString(); // Converte o Guid para string
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str && Guid.TryParse(str, out var guid))
        {
            return guid; // Converte de volta para Guid
        }
        return Guid.Empty; // Ou retorna Guid.Empty se o valor não for válido
    }
}
