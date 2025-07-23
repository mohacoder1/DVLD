namespace DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications
{
    partial class frmShowLocalApplicationInfo
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
            this.ctrlLocalApplicationInfo1 = new DVLD_Presentation_Layer.Applications.ManageDrivingLicenseApplications.LocalDrivingLicenseApplications.controls.ctrlLocalApplicationInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlLocalApplicationInfo1
            // 
            this.ctrlLocalApplicationInfo1.Location = new System.Drawing.Point(0, 56);
            this.ctrlLocalApplicationInfo1.Name = "ctrlLocalApplicationInfo1";
            this.ctrlLocalApplicationInfo1.SelectedLocalAppID = -1;
            this.ctrlLocalApplicationInfo1.SelectedlocalLicenseApplication = null;
            this.ctrlLocalApplicationInfo1.Size = new System.Drawing.Size(818, 299);
            this.ctrlLocalApplicationInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Application Info";
            // 
            // frmShowLocalApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 349);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlLocalApplicationInfo1);
            this.Name = "frmShowLocalApplicationInfo";
            this.Text = "Local Application Info";
            this.Load += new System.EventHandler(this.frmShowLocalApplicationInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.ctrlLocalApplicationInfo ctrlLocalApplicationInfo1;
        private System.Windows.Forms.Label label1;
    }
}