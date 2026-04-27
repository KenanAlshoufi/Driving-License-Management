namespace Driving_License_Management
{
    partial class frmTestAppointments
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
            this.components = new System.ComponentModel.Container();
            this.dgvVisionTestAppointment = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbImageMode = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLiceneseApplicationInfo1 = new Driving_License_Management.ctrlLocalDrivingLiceneseApplicationInfo();
            this.lblModeTestAppointment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisionTestAppointment)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageMode)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVisionTestAppointment
            // 
            this.dgvVisionTestAppointment.AllowUserToAddRows = false;
            this.dgvVisionTestAppointment.AllowUserToDeleteRows = false;
            this.dgvVisionTestAppointment.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVisionTestAppointment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVisionTestAppointment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVisionTestAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisionTestAppointment.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvVisionTestAppointment.Location = new System.Drawing.Point(6, 463);
            this.dgvVisionTestAppointment.Name = "dgvVisionTestAppointment";
            this.dgvVisionTestAppointment.ReadOnly = true;
            this.dgvVisionTestAppointment.Size = new System.Drawing.Size(775, 150);
            this.dgvVisionTestAppointment.TabIndex = 25;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.testToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.testToolStripMenuItem.Text = "Take Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(75, 620);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(96, 19);
            this.lblRecords.TabIndex = 27;
            this.lblRecords.Text = "CountRecord";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(6, 620);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(71, 19);
            this.label.TabIndex = 26;
            this.label.Text = "Records :";
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BackgroundImage = global::Driving_License_Management.Properties.Resources.eye;
            this.btnAddAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAppointment.FlatAppearance.BorderSize = 0;
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointment.Location = new System.Drawing.Point(722, 418);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(50, 39);
            this.btnAddAppointment.TabIndex = 28;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Driving_License_Management.Properties.Resources.close__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(673, 615);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 37);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbImageMode
            // 
            this.pbImageMode.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pbImageMode.Image = global::Driving_License_Management.Properties.Resources.eye;
            this.pbImageMode.Location = new System.Drawing.Point(103, 3);
            this.pbImageMode.Name = "pbImageMode";
            this.pbImageMode.Size = new System.Drawing.Size(79, 60);
            this.pbImageMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageMode.TabIndex = 0;
            this.pbImageMode.TabStop = false;
            // 
            // ctrlLocalDrivingLiceneseApplicationInfo1
            // 
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Location = new System.Drawing.Point(6, 74);
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Name = "ctrlLocalDrivingLiceneseApplicationInfo1";
            this.ctrlLocalDrivingLiceneseApplicationInfo1.Size = new System.Drawing.Size(782, 394);
            this.ctrlLocalDrivingLiceneseApplicationInfo1.TabIndex = 2;
            // 
            // lblModeTestAppointment
            // 
            this.lblModeTestAppointment.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblModeTestAppointment.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeTestAppointment.ForeColor = System.Drawing.Color.White;
            this.lblModeTestAppointment.Location = new System.Drawing.Point(-1, -2);
            this.lblModeTestAppointment.Name = "lblModeTestAppointment";
            this.lblModeTestAppointment.Size = new System.Drawing.Size(789, 73);
            this.lblModeTestAppointment.TabIndex = 60;
            this.lblModeTestAppointment.Text = "Vision Test Appointments";
            this.lblModeTestAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 656);
            this.Controls.Add(this.pbImageMode);
            this.Controls.Add(this.lblModeTestAppointment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dgvVisionTestAppointment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLocalDrivingLiceneseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisionTestAppointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisionTestAppointment)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImageMode;
        private ctrlLocalDrivingLiceneseApplicationInfo ctrlLocalDrivingLiceneseApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvVisionTestAppointment;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Label lblModeTestAppointment;
    }
}