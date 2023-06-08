using System.Windows.Forms;

namespace OutlookReplayBySender.Forms
{
    public partial class RootFormControl : UserControl
    {
        public RootFormControl()
        {
            InitializeComponent();

            RootEementHost.Child = new RootPane();
        }
    }
}
