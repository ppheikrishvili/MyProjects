namespace OutlookReplayBySender.Forms
{
    partial class RootFormControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RootEementHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // RootEementHost
            // 
            this.RootEementHost.Location = new System.Drawing.Point(5, 5);
            this.RootEementHost.Margin = new System.Windows.Forms.Padding(5);
            this.RootEementHost.Name = "RootEementHost";
            this.RootEementHost.Size = new System.Drawing.Size(883, 792);
            this.RootEementHost.TabIndex = 0;
            this.RootEementHost.Text = "elementHost1";
            this.RootEementHost.Child = null;
            // 
            // RootFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RootEementHost);
            this.Name = "RootFormControl";
            this.Size = new System.Drawing.Size(893, 802);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost RootEementHost;
    }
}
