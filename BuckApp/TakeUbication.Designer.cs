namespace BuckApp
{
    partial class TakeUbication
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wbMaps = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbMaps
            // 
            this.wbMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMaps.Location = new System.Drawing.Point(0, 0);
            this.wbMaps.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMaps.Name = "wbMaps";
            this.wbMaps.Size = new System.Drawing.Size(800, 450);
            this.wbMaps.TabIndex = 0;
            // 
            // TakeUbication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wbMaps);
            this.Name = "TakeUbication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakeUbication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TakeUbication_FormClosing);
            this.Load += new System.EventHandler(this.TakeUbication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbMaps;
    }
}