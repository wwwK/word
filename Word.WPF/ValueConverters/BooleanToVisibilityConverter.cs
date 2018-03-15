namespace KS.Word.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows;

    /// <summary>
    ///     A converter that takies in a boolean and returns a <see cref="Visibility" />.
    /// </summary>
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return value != null && (bool) value ? Visibility.Hidden : Visibility.Visible;

            return value != null && (bool) value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}