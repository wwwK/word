namespace KS.Word.Animations
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;

    /// <summary>
    ///     Animations helpers for <see cref="Storyboard" />.
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        ///     Adds a slide from right animation to the <see cref="Storyboard" />.
        /// </summary>
        /// <param name="storyboard">The <see cref="Storyboard" /> to add the animation to.</param>
        /// <param name="secounds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelarationRatio">The rate of decelaration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float secounds, double offset,
            float decelarationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secounds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelarationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Adds a slide to left animation to the <see cref="Storyboard" />.
        /// </summary>
        /// <param name="storyboard">The <see cref="Storyboard" /> to add the animation to.</param>
        /// <param name="secounds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelarationRatio">The rate of decelaration</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float secounds, double offset,
            float decelarationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secounds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelarationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Adds a fade in animation to the <see cref="Storyboard" />.
        /// </summary>
        /// <param name="storyboard">The <see cref="Storyboard" /> to add the animation to.</param>
        /// <param name="secounds">The time the animation will take</param>
        /// <param name="decelarationRatio">The rate of decelaration</param>
        public static void AddFadeIn(this Storyboard storyboard, float secounds, float decelarationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secounds)),
                From = 0,
                To = 1
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Adds a fade out animation to the <see cref="Storyboard" />.
        /// </summary>
        /// <param name="storyboard">The <see cref="Storyboard" /> to add the animation to.</param>
        /// <param name="secounds">The time the animation will take</param>
        /// <param name="decelarationRatio">The rate of decelaration</param>
        public static void AddFadeOut(this Storyboard storyboard, float secounds, float decelarationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secounds)),
                From = 1,
                To = 0
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add animation to the storyboard
            storyboard.Children.Add(animation);
        }
    }
}