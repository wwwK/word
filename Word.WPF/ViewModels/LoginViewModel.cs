namespace KS.Word.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Base;
    using Security;

    /// <inheritdoc />
    /// <summary>
    ///     The view model for the login view.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async paramater => await Login(paramater));
        }

        #endregion

        #region Commands

        /// <summary>
        ///     Command to log user in.
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region MyRegion

        /// <summary>
        ///     Attemps to log the user in.
        /// </summary>
        /// <param name="paramater">The <see cref="System.Security.SecureString" /> passed from the view for the user password.</param>
        /// <returns></returns>
        private async Task Login(object paramater)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(500);

                var email = Email;
                var password = (paramater as IHavePassword)?.SecureString.Unsecure();
            });
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     The flag indicating if the login command is running.
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion
    }
}