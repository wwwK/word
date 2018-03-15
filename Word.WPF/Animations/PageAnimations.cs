namespace KS.Word.Animations
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;

    /// <summary>
    ///     Helpers to animate pages in specific ways.
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        ///     Add silde and fade from right to the page.
        /// </summary>
        /// <param name="page">Page to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // Create the storyboard
            var storyboard = new Storyboard();

            // Add slide from right animation
            storyboard.AddSlideFromRight(seconds, page.WindowWidth);

            // Add slide from right animation
            storyboard.AddFadeIn(seconds);

            // Start animating
            storyboard.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for animation finish
            await Task.Delay((int) (seconds * 1000));
        }

        /// <summary>
        ///     Add silde and fade from right to the page.
        /// </summary>
        /// <param name="page">Page to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // Create the storyboard
            var storyboard = new Storyboard();

            // Add slide from right animation
            storyboard.AddSlideToLeft(seconds, page.WindowWidth);

            // Add slide from right animation
            storyboard.AddFadeOut(seconds);

            // Start animating
            storyboard.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for animation finish
            await Task.Delay((int) (seconds * 1000));
        }
    }
}