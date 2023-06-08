using Microsoft.Office.Interop.Outlook;

namespace OutlookReplayBySender.Service
{
    public static class EmailsService
    {
        public static MailItem GetActiveMailItem()
        {
            if (Globals.ThisAddIn.Application.ActiveExplorer().Selection.Count == 0) return null;
            object selection = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1];
            if (!(selection is MailItem item)) return null;
            return item;
        }
    }
}
