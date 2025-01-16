using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HistoryCreator.Ressources.Core.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class InvertBoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        private static InvertBoolToVisibilityConverter converter;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible ? false : true;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new InvertBoolToVisibilityConverter());
        }
    }
}
