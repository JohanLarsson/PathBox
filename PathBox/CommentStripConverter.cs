using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Media;

namespace PathBox
{
    public class CommentStripConverter : IValueConverter
    {
        private static readonly string commentPattern = @"/\*((?!\*/).)*\*/";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            var clean = Regex.Replace(s, commentPattern, "");
            return Geometry.Parse(clean);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
