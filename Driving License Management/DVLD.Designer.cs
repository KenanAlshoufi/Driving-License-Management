using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Driving_License_Management
{
    partial class DVLD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DVLD));
            this.msControl = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicneseServersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewLicneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationTypesStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.accuntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentUserInfotoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.signouttoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.msControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // msControl
            // 
            this.msControl.BackColor = System.Drawing.Color.White;
            this.msControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.msControl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msControl.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.msControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.smiPeople,
            this.driversToolStripMenuItem,
            this.smiUsers,
            this.accuntToolStripMenuItem});
            this.msControl.Location = new System.Drawing.Point(0, 0);
            this.msControl.Name = "msControl";
            this.msControl.Size = new System.Drawing.Size(134, 621);
            this.msControl.TabIndex = 1;
            this.msControl.Text = "Control";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicneseServersToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.ApplicationTypesStripMenuItem1,
            this.manageTestTypesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem});
            this.applicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.applicationToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.feature_selection;
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(127, 34);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // drivingLicneseServersToolStripMenuItem
            // 
            this.drivingLicneseServersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localToolStripMenuItem,
            this.renewLicneseToolStripMenuItem,
            this.replacementLicenseToolStripMenuItem,
            this.releseLicenseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicneseServersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drivingLicneseServersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drivingLicneseServersToolStripMenuItem.Image")));
            this.drivingLicneseServersToolStripMenuItem.Name = "drivingLicneseServersToolStripMenuItem";
            this.drivingLicneseServersToolStripMenuItem.Size = new System.Drawing.Size(237, 38);
            this.drivingLicneseServersToolStripMenuItem.Text = "Driving Licnese Servers";
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicneseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.localToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localToolStripMenuItem.Image")));
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(350, 36);
            this.localToolStripMenuItem.Text = "New Driving Licnese";
            // 
            // localDrivingLicneseToolStripMenuItem
            // 
            this.localDrivingLicneseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localDrivingLicneseToolStripMenuItem.Image")));
            this.localDrivingLicneseToolStripMenuItem.Name = "localDrivingLicneseToolStripMenuItem";
            this.localDrivingLicneseToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.localDrivingLicneseToolStripMenuItem.Text = "Local Driving Licnese";
            this.localDrivingLicneseToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicneseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.driver_license;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.internationalLicenseToolStripMenuItem.Text = "&International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // renewLicneseToolStripMenuItem
            // 
            this.renewLicneseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.renew;
            this.renewLicneseToolStripMenuItem.Name = "renewLicneseToolStripMenuItem";
            this.renewLicneseToolStripMenuItem.Size = new System.Drawing.Size(350, 36);
            this.renewLicneseToolStripMenuItem.Text = "Renew Licnese";
            this.renewLicneseToolStripMenuItem.Click += new System.EventHandler(this.renewLicneseToolStripMenuItem_Click);
            // 
            // replacementLicenseToolStripMenuItem
            // 
            this.replacementLicenseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.data;
            this.replacementLicenseToolStripMenuItem.Name = "replacementLicenseToolStripMenuItem";
            this.replacementLicenseToolStripMenuItem.Size = new System.Drawing.Size(350, 36);
            this.replacementLicenseToolStripMenuItem.Text = "Replacement for Lost or &Damaged License";
            this.replacementLicenseToolStripMenuItem.Click += new System.EventHandler(this.replacementLicenseToolStripMenuItem_Click);
            // 
            // releseLicenseToolStripMenuItem
            // 
            this.releseLicenseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.product_development;
            this.releseLicenseToolStripMenuItem.Name = "releseLicenseToolStripMenuItem";
            this.releseLicenseToolStripMenuItem.Size = new System.Drawing.Size(350, 36);
            this.releseLicenseToolStripMenuItem.Text = "Relese License";
            this.releseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releseLicenseToolStripMenuItem_Click);
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.document_orientation_potrait;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(350, 36);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem1});
            this.manageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.modular;
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(237, 38);
            this.manageToolStripMenuItem.Text = "Manage Application ";
            // 
            // localDrivingLicenseToolStripMenuItem
            // 
            this.localDrivingLicenseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.resume;
            this.localDrivingLicenseToolStripMenuItem.Name = "localDrivingLicenseToolStripMenuItem";
            this.localDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(294, 36);
            this.localDrivingLicenseToolStripMenuItem.Text = "Local Driving license";
            this.localDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem1
            // 
            this.internationalLicenseToolStripMenuItem1.Image = global::Driving_License_Management.Properties.Resources.driver_license;
            this.internationalLicenseToolStripMenuItem1.Name = "internationalLicenseToolStripMenuItem1";
            this.internationalLicenseToolStripMenuItem1.Size = new System.Drawing.Size(294, 36);
            this.internationalLicenseToolStripMenuItem1.Text = "&International License Application";
            this.internationalLicenseToolStripMenuItem1.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem1_Click);
            // 
            // ApplicationTypesStripMenuItem1
            // 
            this.ApplicationTypesStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationTypesStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ApplicationTypesStripMenuItem1.Image")));
            this.ApplicationTypesStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ApplicationTypesStripMenuItem1.Name = "ApplicationTypesStripMenuItem1";
            this.ApplicationTypesStripMenuItem1.Size = new System.Drawing.Size(237, 38);
            this.ApplicationTypesStripMenuItem1.Text = "Application Types";
            this.ApplicationTypesStripMenuItem1.Click += new System.EventHandler(this.ApplicationTypesStripMenuItem1_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageTestTypesToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.exam;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(237, 38);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detainLicenseToolStripMenuItem1,
            this.releaseLicenseToolStripMenuItem,
            this.manageToolStripMenuItem1});
            this.detainLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detainLicenseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.bust__1_;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(237, 38);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            // 
            // detainLicenseToolStripMenuItem1
            // 
            this.detainLicenseToolStripMenuItem1.Image = global::Driving_License_Management.Properties.Resources.bust__1_;
            this.detainLicenseToolStripMenuItem1.Name = "detainLicenseToolStripMenuItem1";
            this.detainLicenseToolStripMenuItem1.Size = new System.Drawing.Size(233, 36);
            this.detainLicenseToolStripMenuItem1.Text = "Detain License";
            this.detainLicenseToolStripMenuItem1.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem1_Click);
            // 
            // releaseLicenseToolStripMenuItem
            // 
            this.releaseLicenseToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.product_development;
            this.releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            this.releaseLicenseToolStripMenuItem.Size = new System.Drawing.Size(233, 36);
            this.releaseLicenseToolStripMenuItem.Text = "Release License";
            this.releaseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseLicenseToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem1
            // 
            this.manageToolStripMenuItem1.Image = global::Driving_License_Management.Properties.Resources.modular;
            this.manageToolStripMenuItem1.Name = "manageToolStripMenuItem1";
            this.manageToolStripMenuItem1.Size = new System.Drawing.Size(233, 36);
            this.manageToolStripMenuItem1.Text = "Manage Detain License";
            this.manageToolStripMenuItem1.Click += new System.EventHandler(this.manageToolStripMenuItem1_Click);
            // 
            // smiPeople
            // 
            this.smiPeople.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smiPeople.ForeColor = System.Drawing.Color.Black;
            this.smiPeople.Image = global::Driving_License_Management.Properties.Resources.group;
            this.smiPeople.Name = "smiPeople";
            this.smiPeople.Size = new System.Drawing.Size(127, 34);
            this.smiPeople.Text = "People";
            this.smiPeople.Click += new System.EventHandler(this.smiPeople_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.taxi_driver;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(127, 34);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // smiUsers
            // 
            this.smiUsers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smiUsers.ForeColor = System.Drawing.Color.Black;
            this.smiUsers.Image = global::Driving_License_Management.Properties.Resources.student;
            this.smiUsers.Name = "smiUsers";
            this.smiUsers.Size = new System.Drawing.Size(127, 34);
            this.smiUsers.Text = "Users";
            this.smiUsers.Click += new System.EventHandler(this.smiUsers_Click);
            // 
            // accuntToolStripMenuItem
            // 
            this.accuntToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentUserInfotoolStripMenuItem1,
            this.ChangePasswordtoolStripMenuItem1,
            this.toolStripSeparator1,
            this.signouttoolStripMenuItem2});
            this.accuntToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuntToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.accuntToolStripMenuItem.Image = global::Driving_License_Management.Properties.Resources.user_profile__1_;
            this.accuntToolStripMenuItem.Name = "accuntToolStripMenuItem";
            this.accuntToolStripMenuItem.Size = new System.Drawing.Size(127, 34);
            this.accuntToolStripMenuItem.Text = "Settings";
            // 
            // CurrentUserInfotoolStripMenuItem1
            // 
            this.CurrentUserInfotoolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentUserInfotoolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("CurrentUserInfotoolStripMenuItem1.Image")));
            this.CurrentUserInfotoolStripMenuItem1.Name = "CurrentUserInfotoolStripMenuItem1";
            this.CurrentUserInfotoolStripMenuItem1.Size = new System.Drawing.Size(201, 38);
            this.CurrentUserInfotoolStripMenuItem1.Text = "Current User Info";
            this.CurrentUserInfotoolStripMenuItem1.Click += new System.EventHandler(this.CurrentUserInfotoolStripMenuItem1_Click);
            // 
            // ChangePasswordtoolStripMenuItem1
            // 
            this.ChangePasswordtoolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordtoolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ChangePasswordtoolStripMenuItem1.Image")));
            this.ChangePasswordtoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ChangePasswordtoolStripMenuItem1.Name = "ChangePasswordtoolStripMenuItem1";
            this.ChangePasswordtoolStripMenuItem1.Size = new System.Drawing.Size(201, 38);
            this.ChangePasswordtoolStripMenuItem1.Text = "Change Password";
            this.ChangePasswordtoolStripMenuItem1.Click += new System.EventHandler(this.ChangePasswordtoolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // signouttoolStripMenuItem2
            // 
            this.signouttoolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signouttoolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("signouttoolStripMenuItem2.Image")));
            this.signouttoolStripMenuItem2.Name = "signouttoolStripMenuItem2";
            this.signouttoolStripMenuItem2.Size = new System.Drawing.Size(201, 38);
            this.signouttoolStripMenuItem2.Text = "sign out";
            this.signouttoolStripMenuItem2.Click += new System.EventHandler(this.signouttoolStripMenuItem2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1057, 621);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(135, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Number of users :";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(252, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 17);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "N/A";
            // 
            // DVLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1057, 621);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msControl);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Old Antic Outline Shaded", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msControl;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "DVLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DVLD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DVLD_Load);
            this.msControl.ResumeLayout(false);
            this.msControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msControl;
        private System.Windows.Forms.ToolStripMenuItem smiPeople;
        private System.Windows.Forms.ToolStripMenuItem smiUsers;
        private System.Windows.Forms.ToolStripMenuItem accuntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordtoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CurrentUserInfotoolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem signouttoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ApplicationTypesStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicneseServersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem renewLicneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releseLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem1;
        private Label label1;
        private Label lblUser;
    }
}

