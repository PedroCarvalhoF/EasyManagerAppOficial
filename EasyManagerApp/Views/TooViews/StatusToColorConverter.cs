using System.Globalization;

namespace EasyManagerApp.Views.TooViews;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool habilitado)
        {
            return habilitado ? Colors.Green : Colors.Red;
        }

        return Colors.Black;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
