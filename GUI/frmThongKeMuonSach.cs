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

namespace Quản_lý_thư_viện_Tri_Thức
{

    public partial class frmThongKeMuonSach : Form
    {
        DauSachBUS dauSachBUS = new DauSachBUS();
        public frmThongKeMuonSach()
        {
            InitializeComponent();
            cbbDauSach.DataSource = dauSachBUS.LayDSDauSach();
            cbbDauSach.DisplayMember = "TenDauSach";
            cbbDauSach.ValueMember = "MaDauSach";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (rdoCrystal.Checked)
            {
                frmXemBaoCao frmXem = new frmXemBaoCao();
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }


                frmXem.MdiParent = this.MdiParent;
                frmXem.Show();
            }
            else if(rdoTatCaSach.Checked)
            {
                frmXemThongKe frm = new frmXemThongKe();
                frm.TatCaSach();

                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else if (rdoTheoDauSach.Checked)
            {
                frmXemThongKe frm = new frmXemThongKe();

                frm.MdiParent = this.MdiParent;

                frm.SachTheoLoai(cbbDauSach.SelectedValue.ToString());
                frm.Show();
            }
            else if (rdoTheoNhom.Checked)
            {
                frmXemThongKe frm = new frmXemThongKe();
                frm.MdiParent = this.MdiParent;

                frm.NhomTheoDauSach();
                frm.Show();
            }
            else if (rdoHoaDon.Checked)
            {
                frmXemThongKe frm = new frmXemThongKe();
                frm.MdiParent = this.MdiParent;

                frm.HoaDon();
                frm.Show();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
