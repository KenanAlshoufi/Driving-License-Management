namespace Driving_License_Management
{
    partial class frmShowPersonLicenseHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlFilterPerosnDet1 = new Driving_License_Management.ctrlFilterPerosnDet();
            this.ctrlPersonLicenseHistory1 = new Driving_License_Management.ctrlPersonLicenseHistory();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(804, 73);
            this.label1.TabIndex = 19;
            this.label1.Text = "            Show Person License History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox1.Image = global::Driving_License_Management.Properties.Resources.document;
            this.pictureBox1.Location = new System.Drawing.Point(178, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlFilterPerosnDet1
            // 
            this.ctrlFilterPerosnDet1.AddPerson = true;
            this.ctrlFilterPerosnDet1.EnableFilter = true;
            this.ctrlFilterPerosnDet1.Location = new System.Drawing.Point(1, 71);
            this.ctrlFilterPerosnDet1.Name = "ctrlFilterPerosnDet1";
            this.ctrlFilterPerosnDet1.Size = new System.Drawing.Size(804, 400);
            this.ctrlFilterPerosnDet1.TabIndex = 21;
            this.ctrlFilterPerosnDet1.OnPersonSelect += new System.Action<int>(this.ctrlFilterPerosnDet1_OnPersonSelect);
            // 
            // ctrlPersonLicenseHistory1
            // 
            this.ctrlPersonLicenseHistory1.Location = new System.Drawing.Point(-3, 455);
            this.ctrlPersonLicenseHistory1.Name = "ctrlPersonLicenseHistory1";
            this.ctrlPersonLicenseHistory1.Size = new System.Drawing.Size(808, 225);
            this.ctrlPersonLicenseHistory1.TabIndex = 22;
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 671);
            this.Controls.Add(this.ctrlPersonLicenseHistory1);
            this.Controls.Add(this.ctrlFilterPerosnDet1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowPersonLicenseHistory";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private ctrlFilterPerosnDet ctrlFilterPerosnDet1;
        private System.Windows.Forms.Label label1;
        private ctrlPersonLicenseHistory ctrlPersonLicenseHistory1;
    }
}