namespace KS.Word
{
    using System.Windows;
    using ViewModels;

    /// <inheritdoc cref="System.Windows.Window" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }
    }
}