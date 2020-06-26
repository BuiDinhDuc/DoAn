using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Microsoft.Reporting.WinForms;

namespace Quản_lý_thư_viện_Tri_Thức
{
    public partial class frmXemThongKe : Form
    {
        SachBUS sachBUS = new SachBUS();
        DauSachBUS dauSachBUS = new DauSachBUS();
        public frmXemThongKe()
        {
            InitializeComponent();
        }

        private void frmXemThongKe_Load(object sender, EventArgs e)
        {
        }

        public void TatCaSach()
        {
            List<SachDTO> lstSach = sachBUS.LayDSSach();
            this.rpvTatCaSach.LocalReport.ReportEmbeddedResource = "Quản_lý_thư_viện_Tri_Thức.rptTatCaSach.rdlc";

            this.rpvTatCaSach.LocalReport.DataSources.Add(new ReportDataSource("dsSach", lstSach));
            this.rpvTatCaSach.RefreshReport();
        }
        public void SachTheoLoai(string MaDauSach)
        {
            List<SachDTO> lstSach = sachBUS.LaySachTheoDauSach(MaDauSach);
            this.rpvTatCaSach.LocalReport.ReportEmbeddedResource = "Quản_lý_thư_viện_Tri_Thức.rptSachTheoLoai.rdlc";
            this.rpvTatCaSach.LocalReport.SetParameters(new ReportParameter("paLoaiSach", MaDauSach));
            this.rpvTatCaSach.LocalReport.DataSources.Add(new ReportDataSource("dsSach", lstSach));
            this.rpvTatCaSach.RefreshReport();
        }
        public void NhomTheoDauSach()
        {
            List<DauSachDTO> lstDauSach = dauSachBUS.LayDSDauSach();
            this.rpvTatCaSach.LocalReport.ReportEmbeddedResource = "Quản_lý_thư_viện_Tri_Thức.rptSachNhom.rdlc";

            this.rpvTatCaSach.LocalReport.DataSources.Add(new ReportDataSource("dsDauSach", lstDauSach));
            this.rpvTatCaSach.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            this.rpvTatCaSach.RefreshReport();
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            string maDauSach = e.Parameters["paMaDauSach"].Values[0];
            e.DataSources.Add(new ReportDataSource("dsSach", sachBUS.LaySachTheoDauSach(maDauSach)));
        }
        public void HoaDon()
        {
            List<SachDTO> lstSach = sachBUS.LayDSSach();
            this.rpvTatCaSach.LocalReport.ReportEmbeddedResource = "Quản_lý_thư_viện_Tri_Thức.rptHoaDon.rdlc";
            this.rpvTatCaSach.LocalReport.SetParameters(new ReportParameter("paNguoiLap", "<Tên Người Lập>"));
            this.rpvTatCaSach.LocalReport.SetParameters(new ReportParameter("paNgayLap", DateTime.Today.ToString()));
            this.rpvTatCaSach.LocalReport.DataSources.Add(new ReportDataSource("dsSach", lstSach));
            this.rpvTatCaSach.RefreshReport();
        }
    }
}
