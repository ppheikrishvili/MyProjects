using System.Linq;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using OutlookReplayBySender.Forms;
using OutlookReplayBySender.Service;
using System.Windows.Data;
using CustomTaskPane = Microsoft.Office.Tools.CustomTaskPane;

namespace OutlookReplayBySender
{
    public partial class ReplayBySender
    {
        readonly RootFormControl rootFormControl = new RootFormControl();
        //private MailItem mailItem = null;

        CustomTaskPane _pane;

        private void ReplayBySender_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void ShowPanelButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (_pane == null)
            {
                if (ThisAddIn.ActiveApplication.ActiveWindow() is Inspector inspector)
                {
                    // fromInspector = true;
                    _pane = Globals.ThisAddIn.CustomTaskPanes.Add(rootFormControl, "Mail Manager", inspector);
                    //mailItem = (MailItem) inspector.CurrentItem;
                    //mailItem.PropertyChange += MailItemOnPropertyChange;
                    //mailItem.BeforeCheckNames += MailItemOnBeforeCheckNames;
                }
                else
                {
                    Explorer explorer = ThisAddIn.ActiveApplication.ActiveExplorer();
                    _pane = Globals.ThisAddIn.CustomTaskPanes.Add(rootFormControl, "Mail Manager", explorer);
                    //mailItem = (MailItem)explorer.CurrentItem;
                    explorer.SelectionChange += SelectedEmailChanged;
                }
            }
            _pane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionRight;
            _pane.Width = 700; // (int) ( (MailPane) control.WpfControl.Child).Width;
            _pane.Visible = true;

        }

        private void SelectedEmailChanged()
        {
            var G = EmailsService.GetActiveMailItem();

            if (G == null) return;

            //ListCollectionView RecipientsCollectionView = CollectionViewSource.GetDefaultView(CollectionViewSource.CollectionViewTypeProperty) 
            //    as ListCollectionView;

            ListCollectionView RecipientsCollectionView =
                new ListCollectionView(G.Recipients.Cast<Recipient>().ToList());
                //{
                //    Filter = (e) =>
                //    {
                //        Recipient emp = e as Recipient;
                //        if (emp.Name.Contains("Nika"))
                //            return true;
                //        return false;
                //    }
                //};

            var ff = RecipientsCollectionView.Cast<Recipient>().ToList();

            var f = RecipientsCollectionView.SourceCollection.Cast<Recipient>().ToList();
        }
    }
}
