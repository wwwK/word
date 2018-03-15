namespace KS.Word.ViewModels.Base
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Expressions;
    using Properties;

    /// <inheritdoc />
    /// <summary>
    ///     A base class for view model that trigger property changed events as needed.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc />
        /// <summary>
        ///     The event fired when any child property changes value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Call this to fire <see cref="PropertyChanged" /> event.
        /// </summary>
        /// <param name="propertyName">Name of property which changes.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Command Helpers

        /// <summary>
        ///     Runs a command if the updating flag is not set.
        ///     If the flag is true (indicating the function is already running) than the action is not run.
        ///     If the flag is false (indicating no running function) than the action is running.
        ///     Once the action is finished if it was run, than the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Check if the flag property is true
            if (updatingFlag.GetPropertyValue())
                return;

            // Set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Run the passed action.
                await action();
            }
            finally
            {
                // Set the property flag to false, now it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}