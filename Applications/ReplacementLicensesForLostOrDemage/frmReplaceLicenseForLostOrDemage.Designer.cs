namespace DVLD_Presentation_Layer.Applications.ReplacementLicensesForLostOrDemage
{
    partial class frmReplaceLicenseForLostOrDemage
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
            this.llShowLicense = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.o = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblReplaceLicenseID = new System.Windows.Forms.Label();
            this.lblOldLicense = new System.Windows.Forms.Label();
            this.lblCreatedByUserID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblReplaceApplicationID = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_Presentation_Layer.Licenses.controls.ctrlDriverLicenseInfoWithFilter();
            this.tpDriverInfo = new System.Windows.Forms.TabPage();
            this.tpReplacementApplicationInfo = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbForLost = new System.Windows.Forms.RadioButton();
            this.rbForDemage = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReplaceLicense = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDriverInfo.SuspendLayout();
            this.tpReplacementApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // llShowLicense
            // 
            this.llShowLicense.AutoSize = true;
            this.llShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.llShowLicense.Location = new System.Drawing.Point(212, 471);
            this.llShowLicense.Name = "llShowLicense";
            this.llShowLicense.Size = new System.Drawing.Size(143, 20);
            this.llShowLicense.TabIndex = 83;
            this.llShowLicense.TabStop = true;
            this.llShowLicense.Text = "Show New License";
            this.llShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicense_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.llShowLicenseHistory.Location = new System.Drawing.Point(40, 471);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(161, 20);
            this.llShowLicenseHistory.TabIndex = 82;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(104, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(462, 31);
            this.lblTitle.TabIndex = 79;
            this.lblTitle.Text = "Replacement License Application  ";
            // 
            // o
            // 
            this.o.AutoSize = true;
            this.o.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o.Location = new System.Drawing.Point(410, 153);
            this.o.Name = "o";
            this.o.Size = new System.Drawing.Size(186, 20);
            this.o.TabIndex = 60;
            this.o.Text = "Replaced LicenseID : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(458, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Old LicenseID : ";
            // 
            // lblReplaceLicenseID
            // 
            this.lblReplaceLicenseID.AutoSize = true;
            this.lblReplaceLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceLicenseID.Location = new System.Drawing.Point(636, 155);
            this.lblReplaceLicenseID.Name = "lblReplaceLicenseID";
            this.lblReplaceLicenseID.Size = new System.Drawing.Size(53, 20);
            this.lblReplaceLicenseID.TabIndex = 62;
            this.lblReplaceLicenseID.Text = "[????]";
            // 
            // lblOldLicense
            // 
            this.lblOldLicense.AutoSize = true;
            this.lblOldLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicense.ForeColor = System.Drawing.Color.Black;
            this.lblOldLicense.Location = new System.Drawing.Point(636, 192);
            this.lblOldLicense.Name = "lblOldLicense";
            this.lblOldLicense.Size = new System.Drawing.Size(53, 20);
            this.lblOldLicense.TabIndex = 63;
            this.lblOldLicense.Text = "[????]";
            // 
            // lblCreatedByUserID
            // 
            this.lblCreatedByUserID.AutoSize = true;
            this.lblCreatedByUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUserID.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedByUserID.Location = new System.Drawing.Point(636, 231);
            this.lblCreatedByUserID.Name = "lblCreatedByUserID";
            this.lblCreatedByUserID.Size = new System.Drawing.Size(53, 20);
            this.lblCreatedByUserID.TabIndex = 69;
            this.lblCreatedByUserID.Text = "[????]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(478, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 20);
            this.label12.TabIndex = 67;
            this.label12.Text = "Created By  : ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(58, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 20);
            this.label20.TabIndex = 42;
            this.label20.Text = "R.L.AppID  : ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(14, 190);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 20);
            this.label19.TabIndex = 43;
            this.label19.Text = "Application Date : ";
            // 
            // lblReplaceApplicationID
            // 
            this.lblReplaceApplicationID.AutoSize = true;
            this.lblReplaceApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceApplicationID.Location = new System.Drawing.Point(212, 153);
            this.lblReplaceApplicationID.Name = "lblReplaceApplicationID";
            this.lblReplaceApplicationID.Size = new System.Drawing.Size(53, 20);
            this.lblReplaceApplicationID.TabIndex = 44;
            this.lblReplaceApplicationID.Text = "[????]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationDate.Location = new System.Drawing.Point(212, 190);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(133, 20);
            this.lblApplicationDate.TabIndex = 45;
            this.lblApplicationDate.Text = "[????/????/????]";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(13, 226);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(158, 20);
            this.label28.TabIndex = 48;
            this.label28.Text = "Application Fees : ";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(212, 226);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(53, 20);
            this.lblApplicationFees.TabIndex = 50;
            this.lblApplicationFees.Text = "[????]";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnable = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(3, 3);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(805, 513);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlDriverLicenseInfoWithFilter1.onLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_onLicenseSelected);
            // 
            // tpDriverInfo
            // 
            this.tpDriverInfo.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.tpDriverInfo.Location = new System.Drawing.Point(4, 22);
            this.tpDriverInfo.Name = "tpDriverInfo";
            this.tpDriverInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpDriverInfo.Size = new System.Drawing.Size(803, 521);
            this.tpDriverInfo.TabIndex = 0;
            this.tpDriverInfo.Text = "Driver Info";
            this.tpDriverInfo.UseVisualStyleBackColor = true;
            // 
            // tpReplacementApplicationInfo
            // 
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpReplacementApplicationInfo.Controls.Add(this.label1);
            this.tpReplacementApplicationInfo.Controls.Add(this.groupBox1);
            this.tpReplacementApplicationInfo.Controls.Add(this.llShowLicense);
            this.tpReplacementApplicationInfo.Controls.Add(this.llShowLicenseHistory);
            this.tpReplacementApplicationInfo.Controls.Add(this.btnClose);
            this.tpReplacementApplicationInfo.Controls.Add(this.btnReplaceLicense);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblTitle);
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpReplacementApplicationInfo.Controls.Add(this.o);
            this.tpReplacementApplicationInfo.Controls.Add(this.label4);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblReplaceLicenseID);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblOldLicense);
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox5);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblCreatedByUserID);
            this.tpReplacementApplicationInfo.Controls.Add(this.label12);
            this.tpReplacementApplicationInfo.Controls.Add(this.label20);
            this.tpReplacementApplicationInfo.Controls.Add(this.label19);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblReplaceApplicationID);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox10);
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox9);
            this.tpReplacementApplicationInfo.Controls.Add(this.pictureBox14);
            this.tpReplacementApplicationInfo.Controls.Add(this.label28);
            this.tpReplacementApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tpReplacementApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpReplacementApplicationInfo.Name = "tpReplacementApplicationInfo";
            this.tpReplacementApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpReplacementApplicationInfo.Size = new System.Drawing.Size(803, 521);
            this.tpReplacementApplicationInfo.TabIndex = 1;
            this.tpReplacementApplicationInfo.Text = "Replacement Application Info";
            this.tpReplacementApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.Damaged_Driving_License_32;
            this.pictureBox1.Location = new System.Drawing.Point(172, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 28);
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 85;
            this.label1.Text = "Issue Reason : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbForLost);
            this.groupBox1.Controls.Add(this.rbForDemage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(216, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 67);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For";
            // 
            // rbForLost
            // 
            this.rbForLost.AutoSize = true;
            this.rbForLost.Location = new System.Drawing.Point(266, 20);
            this.rbForLost.Name = "rbForLost";
            this.rbForLost.Size = new System.Drawing.Size(140, 22);
            this.rbForLost.TabIndex = 1;
            this.rbForLost.TabStop = true;
            this.rbForLost.Text = "Replace For Lost";
            this.rbForLost.UseVisualStyleBackColor = true;
            this.rbForLost.CheckedChanged += new System.EventHandler(this.rbForDemage_CheckedChanged);
            // 
            // rbForDemage
            // 
            this.rbForDemage.AutoSize = true;
            this.rbForDemage.Location = new System.Drawing.Point(3, 20);
            this.rbForDemage.Name = "rbForDemage";
            this.rbForDemage.Size = new System.Drawing.Size(167, 22);
            this.rbForDemage.TabIndex = 0;
            this.rbForDemage.TabStop = true;
            this.rbForDemage.Text = "Replace For Demage";
            this.rbForDemage.UseVisualStyleBackColor = true;
            this.rbForDemage.CheckedChanged += new System.EventHandler(this.rbForDemage_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnClose.Image = global::DVLD_Presentation_Layer.Properties.Resources.cross_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(578, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 29);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReplaceLicense
            // 
            this.btnReplaceLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplaceLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnReplaceLicense.Image = global::DVLD_Presentation_Layer.Properties.Resources.IssueDrivingLicense_321;
            this.btnReplaceLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplaceLicense.Location = new System.Drawing.Point(685, 485);
            this.btnReplaceLicense.Name = "btnReplaceLicense";
            this.btnReplaceLicense.Size = new System.Drawing.Size(111, 29);
            this.btnReplaceLicense.TabIndex = 80;
            this.btnReplaceLicense.Text = "Replace ";
            this.btnReplaceLicense.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnReplaceLicense.UseVisualStyleBackColor = true;
            this.btnReplaceLicense.Click += new System.EventHandler(this.btnReplaceLicense_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Presentation_Layer.Properties.Resources.User_32__2;
            this.pictureBox2.Location = new System.Drawing.Point(596, 226);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 29);
            this.pictureBox2.TabIndex = 71;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Presentation_Layer.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox4.Location = new System.Drawing.Point(596, 149);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 28);
            this.pictureBox4.TabIndex = 64;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Presentation_Layer.Properties.Resources.License_View_32;
            this.pictureBox5.Location = new System.Drawing.Point(596, 183);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 29);
            this.pictureBox5.TabIndex = 65;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_Presentation_Layer.Properties.Resources.Number_32;
            this.pictureBox10.Location = new System.Drawing.Point(172, 147);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(34, 28);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 46;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD_Presentation_Layer.Properties.Resources.Calendar_32;
            this.pictureBox9.Location = new System.Drawing.Point(172, 181);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(34, 29);
            this.pictureBox9.TabIndex = 47;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::DVLD_Presentation_Layer.Properties.Resources.money_32;
            this.pictureBox14.Location = new System.Drawing.Point(172, 220);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(34, 28);
            this.pictureBox14.TabIndex = 52;
            this.pictureBox14.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDriverInfo);
            this.tabControl1.Controls.Add(this.tpReplacementApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(3, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 547);
            this.tabControl1.TabIndex = 2;
            // 
            // frmReplaceLicenseForLostOrDemage
            // 
            this.AcceptButton = this.btnReplaceLicense;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(822, 568);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceLicenseForLostOrDemage";
            this.Text = "frmReplaceLicenseForLostOrDemage";
            this.Load += new System.EventHandler(this.frmReplaceLicenseForLostOrDemage_Load);
            this.tpDriverInfo.ResumeLayout(false);
            this.tpReplacementApplicationInfo.ResumeLayout(false);
            this.tpReplacementApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel llShowLicense;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReplaceLicense;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label o;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblReplaceLicenseID;
        private System.Windows.Forms.Label lblOldLicense;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblCreatedByUserID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblReplaceApplicationID;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblApplicationFees;
        private Licenses.controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.TabPage tpDriverInfo;
        private System.Windows.Forms.TabPage tpReplacementApplicationInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbForLost;
        private System.Windows.Forms.RadioButton rbForDemage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}