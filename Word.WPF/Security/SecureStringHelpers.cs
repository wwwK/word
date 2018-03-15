namespace KS.Word.Security
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    ///     Helpers for the <see cref="SecureString" /> class.
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        ///     Unsecures a <see cref="SecureString" /> to plain text.
        /// </summary>
        /// <param name="secureString">The secure string</param>
        /// <returns>Returns plain text</returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
                return string.Empty;

            // Get a pointer for an unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}