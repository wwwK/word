namespace KS.Word.ViewModels.Base
{
    using System;
    using System.Windows.Input;

    /// <inheritdoc />
    /// <summary>
    ///     A basic command that runs an <see cref="Action" />.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        ///     The action to run.
        /// </summary>
        private readonly Action _mAction;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            _mAction = action;
        }

        #endregion

        #region Public Events

        /// <inheritdoc />
        /// <summary>
        ///     The event thats fired when the <see cref="CanExecute(object)" /> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Command Methods

        /// <inheritdoc />
        /// <summary>
        ///     A relay command can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Executes the commands Action.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _mAction();
        }

        #endregion
    }
}