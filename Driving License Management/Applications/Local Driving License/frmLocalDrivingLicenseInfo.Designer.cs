namespace Driving_License_Management
{
    partial class frmLocalDrivingLicenseInfo
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
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLiceneseApplicationInfo1 = new Driving_License_Management.ctrlLocalDrivingLiceneseApplicationInfo();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox5.Image = global::Driving_License_Management.Properties.Resources.document_orientation_potrait;
            this.pictureBox5.Location = new System.Drawing.Point(64, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(73, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 23;
            this.pictureBox5.TabStop = false;
            // 
            // ctrlLocalDrivingLiceneseApplicationInfo1
            // 
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Location = new System.Drawing.Point(3, 74);
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Name = "ctrlLocalDrivingLiceneseApplicationInfo1";
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Size = new System.Drawing.Size(774, 394);
            this.ctrlLocalDrivingLiceneseApplicationInfo1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-5, -2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(792, 73);
            this.label13.TabIndex = 60;
            this.label13.Text = "Local Driving Licenese Application";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLocalDrivingLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 464);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ctrlLocalDrivingLiceneseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalDrivingLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Info";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLocalDrivingLiceneseApplicationInfo ctrlLocalDrivingLiceneseApplicationInfo1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label13;
    }
}