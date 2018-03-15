namespace KS.Word.Animations
{
    /// <summary>
    ///     Styles of page animations for appearing/disappering
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        ///     No animation takes place.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The page slides in and fades in from the right.
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        ///     The page slides out and fades out from the left.
        /// </summary>
        SlideAndFadeOutToLeft = 2
    }
}