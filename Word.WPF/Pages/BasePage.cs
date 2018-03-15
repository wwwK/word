namespace KS.Word.Pages
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using Animations;
    using ViewModels.Base;

    /// <inheritdoc />
    /// <summary>
    ///     A base page class for all pages to gain base functionality.
    /// </summary>
    /// <typeparam name="TVM">View Model</typeparam>
    public class BasePage<TVM> : Page where TVM : BaseViewModel, new()

    {
        #region Private Members

        private TVM _viewModel;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public BasePage()
        {
            // If we are animating in, hide to begin with.
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loaded;

            // Create a default view model
            ViewModel = new TVM();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The animation the play the page is first time loaded.
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        ///     The animation the play the page is first time unloaded.
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        ///     The time any slides animation takes to complete.
        /// </summary>
        public float SlideSecouds { get; set; } = 0.8f;

        /// <summary>
        ///     The View Model associated with this page.
        /// </summary>
        public TVM ViewModel
        {
            get => _viewModel;
            set
            {
                // Check if view model changed.
                if (_viewModel == value)
                    return;

                // Set value.
                _viewModel = value;

                // Set the data context for this view model.
                DataContext = _viewModel;
            }
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        ///     Once the page is loaded, perform animation.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        ///     Animates in page.
        /// </summary>
        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSecouds);
                    break;
            }
        }

        /// <summary>
        ///     Animates out page.
        /// </summary>
        public async Task AnimateOut()
        {
            if (PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSecouds);
                    break;
            }
        }

        #endregion
    }
}