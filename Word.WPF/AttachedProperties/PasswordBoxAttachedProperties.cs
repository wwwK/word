namespace KS.Word
{
    using System.Windows;
    using System.Windows.Controls;

    /// <inheritdoc />
    /// <summary>
    ///     The MonitorPassword attached property for a <see cref="T:System.Windows.Controls.PasswordBox" />
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox))
                return;

            // Remove any previous event
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // If the caller set MonitorPassword to true...
            if ((bool) e.NewValue)
            {
                // Set default value
                HasTextProperty.SetValue(passwordBox);

                // Start listining out for password changes
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        ///     Fired when the password box password value changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox) sender);
        }
    }

    /// <inheritdoc />
    /// <summary>
    ///     The HasText attached property for a <see cref="T:System.Windows.Controls.PasswordBox" />
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        ///     Set's the HasText property based on if the caller <see cref="PasswordBox" /> has any text.
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox) sender).SecurePassword.Length > 0);
        }
    }
}