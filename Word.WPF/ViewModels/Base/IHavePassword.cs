namespace KS.Word.ViewModels.Base
{
    using System.Security;

    /// <summary>
    ///     An interface for a class that can provide a secure password.
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        ///     The secure password.
        /// </summary>
        SecureString SecureString { get; }
    }
}