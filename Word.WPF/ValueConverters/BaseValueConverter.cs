namespace KS.Word.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <inheritdoc cref="IValueConverter" />
    /// <inheritdoc cref="MarkupExtension" />
    /// <summary>
    ///     A base value converter that allows direct XAML usage.
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        #region Private Members

        /// <summary>
        ///     A single instance of this value converter
        /// </summary>
        private static T _converter;

        #endregion

        /// <inheritdoc />
        /// <summary>
        ///     Provides a static instance of value converter.
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns>Returns instance of converter</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #region Value Converter Methods

        /// <inheritdoc />
        /// <summary>
        ///     The method to convert one type to another.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <inheritdoc />
        /// <summary>
        ///     The method convert a value to back to it's source.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}