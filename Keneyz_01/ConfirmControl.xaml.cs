using System.Windows.Controls;


namespace Keneyz_01
{
    /// <summary>
    /// Interaction logic for ConfirmControl.xaml
    /// </summary>
    public partial class ConfirmControl : UserControl
    {
        public ConfirmControl()
        {
            InitializeComponent();
            DataContext = new ConfirmViewModel();
        }
    }
}
