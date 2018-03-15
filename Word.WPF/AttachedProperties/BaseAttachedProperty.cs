namespace KS.Word
{
    using System;
    using System.Windows;

    /// <summary>
    ///     Base attached property to replace the vanilla WPF attached property.
    /// </summary>
    /// <typeparam name="TParent">The parent class to be the attached property.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    public abstract class BaseAttachedProperty<TParent, TProperty>
        where TParent : BaseAttachedProperty<TParent, TProperty>, new()
    {
        #region Public Properties

        /// <summary>
        ///     A singleton instance of our parent class.
        /// </summary>
        public static TParent Instance { get; } = new TParent();

        #endregion

        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Event Methods

        /// <summary>
        ///     The method that is called when any attached property of this type is changed.
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for.</param>
        /// <param name="e">The arguments for this event.</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region Attached Property Definitions

        /// <summary>
        ///     The attached property for this class.
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(TProperty),
                typeof(BaseAttachedProperty<TParent, TProperty>),
                new PropertyMetadata(OnValuePropertyChanged));

        /// <summary>
        ///     The callback event when the <see cref="ValueProperty" /> is changed.
        /// </summary>
        /// <param name="d">The UI element that had it is property changed.</param>
        /// <param name="e">The arguments for the event.</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            // Call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        ///     Get's the attached property.
        /// </summary>
        /// <param name="d">The element to get the property from.</param>
        /// <returns>Returns the attached property.</returns>
        public static TProperty GetValue(DependencyObject d)
        {
            return (TProperty) d.GetValue(ValueProperty);
        }

        /// <summary>
        ///     Set's the value to the property.
        /// </summary>
        /// <param name="d">The element to get the property from.</param>
        /// <param name="value">The value to set the property to.</param>
        public static void SetValue(DependencyObject d, TProperty value)
        {
            d.SetValue(ValueProperty, value);
        }

        #endregion
    }
}