
//using OutlookReplayBySender;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookReplayBySender
{
    public partial class ThisAddIn
    {
        public static Outlook.Application ActiveApplication;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ActiveApplication = Application;
            var ribbon = new ReplayBySender();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += ThisAddIn_Startup;
            this.Shutdown += ThisAddIn_Shutdown;
        }
        
        #endregion
    }
}
