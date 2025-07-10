using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace Marliazen.Share.UI.Converters
{
    public class RemoveDefaultValueEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ret = new List<object>();
            if (value is IList list)
                for (int i = 0; i < list.Count; i++)
                {
                    var val = list[i].ToString();
                    if (val.Equals("NotDefined") || val.Equals("Unknown"))
                        continue;
                    ret.Add(list[i]);
                }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}