namespace KS.Word.Pages
{
    using System.Security;
    using ViewModels.Base;

    /// <inheritdoc cref="BasePage{TVM}" />
    /// <summary>
    ///     Interaction logic for login page.
    /// </summary>
    public partial class LoginPage : IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        /// <summary>
        ///     The secure password for this login page.
        /// </summary>
        public SecureString SecureString => PasswordText.SecurePassword;
    }
}