namespace KS.Word.ValueConverters
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using DataModels;
    using Pages;

    /// <inheritdoc />
    /// <summary>
    ///     Convert the <see cref="T:KS.Word.DataModels.ApplicationPage" /> to an actual view/page.
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                switch ((ApplicationPage) value)
                {
                    case ApplicationPage.Login:
                        return new LoginPage();

                    default:
                        Debugger.Break();
                        return null;
                }
            Debugger.Break();
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}