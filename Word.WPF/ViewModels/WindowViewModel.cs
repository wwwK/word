namespace KS.Word.ViewModels
{
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Input;
    using Base;
    using DataModels;
    using WindowResizer;

    /// <inheritdoc />
    /// <summary>
    ///     The view model for the custom window.
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="window">Window object</param>
        public WindowViewModel(Window window)
        {
            _window = window;

            // Listen out for the window resizing.
            _window.StateChanged += (sender, args) => WindowResized();

            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

            // Fix window resize issue
            var resizer = new WindowResizer(_window);
            resizer.WindowDockChanged += dock =>
            {
                _dockPosition = dock;
                WindowResized();
            };
        }

        #endregion

        #region Private Members

        /// <summary>
        ///     The winow this view model controls.
        /// </summary>
        private readonly Window _window;

        /// <summary>
        ///     The margin around the window to allow for a drop shadow.
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        ///     The radius of the edges of the window.
        /// </summary>
        private int _windowRadius = 10;

        /// <summary>
        ///     The last known dock position.
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Properties

        /// <summary>
        ///     Window minimum width.
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        ///     Window minimum height.
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        ///     True if the window sholud be borderless because it is docker or maxmized.
        /// </summary>
        public bool Borderless =>
            _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked;

        /// <summary>
        ///     The size of the resize border around the window.
        /// </summary>
        public int ResizeBorder => Borderless ? 0 : 6;

        /// <summary>
        ///     The size of the resize border around the window, taking into account the outer margin.
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        ///     The paddint of the inner content of the main window.
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        ///     The margin around the window to allow for a drop shadow.
        /// </summary>
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        ///     The margin around the window to allow for a drop shadow.
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        ///     The radius of the edges of the window.
        /// </summary>
        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        ///     The radius of the edges of the window.
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        ///     The height of the title bar / caption of the window.
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        ///     The height of the title bar / caption of the window.
        /// </summary>
        public GridLength TitleHeightGridLine => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        ///     The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Commands

        /// <summary>
        ///     The command to minimize the window.
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        ///     The command to maximize the window.
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        ///     The command to close the window.
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        ///     The command to show menu window.
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Helpers

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point point);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        }

        /// <summary>
        ///     Gets the current positon of the mouse on the screen.
        /// </summary>
        /// <returns></returns>
        private static Point GetMousePosition()
        {
            var position = new Win32Point();
            GetCursorPos(ref position);
            return new Point(position.X, position.Y);
        }

        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}