namespace Quản_lý_thư_viện_Tri_Thức
{
    partial class frmXemThongKe
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
            this.rpvTatCaSach = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvTatCaSach
            // 
            this.rpvTatCaSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvTatCaSach.Location = new System.Drawing.Point(0, 0);
            this.rpvTatCaSach.Name = "rpvTatCaSach";
            this.rpvTatCaSach.ServerReport.BearerToken = null;
            this.rpvTatCaSach.Size = new System.Drawing.Size(952, 588);
            this.rpvTatCaSach.TabIndex = 0;
            // 
            // frmXemThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 588);
            this.Controls.Add(this.rpvTatCaSach);
            this.Name = "frmXemThongKe";
            this.Text = "frmXemThongKe";
            this.Load += new System.EventHandler(this.frmXemThongKe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvTatCaSach;
    }
}