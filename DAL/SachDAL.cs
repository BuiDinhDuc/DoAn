﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class SachDAL
    {
        QuanLyThuVienEntities data = new QuanLyThuVienEntities();
        public List<SachDTO> LayDSSach()
        {
            List<SachDTO> result = new List<SachDTO>();
            result = data.Saches.Where(u => u.TrangThai.Value == true).Select(u => new SachDTO
            {
                MaSach = u.MaSach,
                TenSach = u.TenSach,
                MaDauSach = u.MaDauSach,
                MaTheLoai = u.DauSach.MaTheLoai,
                TenTacGia = u.TenTacGia,
                TenNhaXuatBan = u.TenNhaXuatBan,
                NamXuatBan = u.NamXuatBan.Value,
                TrangThai = u.TrangThai.Value,
                SoLuong = u.SoLuong.Value,
                SachHiem = u.SachHiem.Value,
                DonGia = (int)u.DonGia,

            }).ToList();

           

            return result;
        }

        //------------------------------
       public bool DeleteBooks(string MaSach)
        {
            try
            {
                Sach s = data.Saches.SingleOrDefault(u => u.MaSach == MaSach && u.TrangThai.Value == true);
                s.TrangThai = false;
                data.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
                    
        }

        public SachDTO timSach(string MaSach)
        {
            SachDTO result = new SachDTO();
            result = data.Saches.Where( u =>u.MaSach == MaSach && u.TrangThai.Value == true).Select(u => new SachDTO
            {
                MaSach = u.MaSach,
                TenSach = u.TenSach,
                MaDauSach = u.MaDauSach,
                MaTheLoai = u.DauSach.MaTheLoai,
                TenTacGia = u.TenTacGia,
                TenNhaXuatBan = u.TenNhaXuatBan,
                NamXuatBan = u.NamXuatBan.Value,
                TrangThai = u.TrangThai.Value,
                SoLuong = u.SoLuong.Value,
                SachHiem = u.SachHiem.Value,
                DonGia = (int)u.DonGia,
            }).SingleOrDefault();


            return result;
        }

        public bool EditBook(SachDTO sach)
        {
            try
            {
                Sach s = data.Saches.SingleOrDefault(u => u.MaSach == sach.MaSach && u.TrangThai.Value == true);


                s.TenSach = sach.TenSach;
                s.MaDauSach = sach.MaDauSach;
                s.TenTacGia = sach.TenTacGia;
                s.TenNhaXuatBan = sach.TenNhaXuatBan;
                s.NamXuatBan = sach.NamXuatBan;
                s.SoLuong = sach.SoLuong;
                s.SachHiem = sach.SachHiem;
                s.DonGia = sach.DonGia;

                data.SaveChanges();

                return true;
            } catch(Exception)
            {
                return false;
            }

        }

        public List<SachDTO> SearchBook(string tieuchi)
        {

            List<SachDTO> ketqua = new List<SachDTO>();
            ketqua = data.Saches.Where(c =>     (c.MaSach.Contains(tieuchi) ||
                                                 c.TenSach.Contains(tieuchi) ||
                                                 c.DauSach.TenDauSach.Contains(tieuchi) ||
                                                 c.DauSach.TheLoai.TenTheLoai.Contains(tieuchi) ||
                                                 c.TenTacGia.Contains(tieuchi) ||
                                                 c.TenNhaXuatBan.Contains(tieuchi)
                                                  ) && c.TrangThai.Value == true).Select(c => new SachDTO
                                                   {

                                                       MaSach = c.MaSach,
                                                       MaDauSach = c.MaDauSach,
                                                       TenSach = c.TenSach,
                                                       MaTheLoai = c.DauSach.MaTheLoai,
                                                       TenTacGia = c.TenTacGia,
                                                       TenNhaXuatBan = c.TenNhaXuatBan,
                                                       NamXuatBan = c.NamXuatBan.Value,
                                                       TrangThai = c.TrangThai.Value,
                                                       SoLuong = c.SoLuong.Value,
                                                       SachHiem = c.SachHiem.Value,
                                                       DonGia = (int)c.DonGia.Value
                                                   }


                                         ).ToList();
            return ketqua;
        }

        public bool AddBook(SachDTO sachDTO)
        {
            try
            {
                Sach sach = new Sach();

                sach.MaSach = sachDTO.MaSach;
                sach.TenSach = sachDTO.TenSach;
                sach.MaDauSach = sachDTO.MaDauSach;
                sach.TenTacGia = sachDTO.TenTacGia;
                sach.TenNhaXuatBan = sachDTO.TenNhaXuatBan;
                sach.NamXuatBan = sachDTO.NamXuatBan;
                sach.TrangThai = sachDTO.TrangThai;
                sach.SoLuong = sachDTO.SoLuong;
                sach.SachHiem = sachDTO.SachHiem;
                sach.DonGia = sachDTO.DonGia;

                data.Saches.Add(sach);
                data.SaveChanges();

                return true;
            }catch(Exception)
            {
                return false;
            }
        }
        public bool ThemSachCu(string MaSach, int SoLuongThem)
        {
            try
            {
                Sach sach = new Sach();
                sach = data.Saches.SingleOrDefault(u => u.MaSach == MaSach && u.TrangThai == true);
                sach.SoLuong += SoLuongThem;
                data.SaveChanges();
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public int DemSo()
        {
            return data.Saches.Count() + 1;
        }

        public List<SachDTO> SearchBookWithName(string tieuchi)
        {

            List<SachDTO> ketqua = new List<SachDTO>();
            ketqua = data.Saches.Where(c => c.TenSach.Contains(tieuchi) && c.TrangThai.Value == true).Select(c => new SachDTO
                                                  {

                                                      MaSach = c.MaSach,
                                                      MaDauSach = c.MaDauSach,
                                                      TenSach = c.TenSach,
                                                      MaTheLoai = c.DauSach.MaTheLoai,
                                                      TenTacGia = c.TenTacGia,
                                                      TenNhaXuatBan = c.TenNhaXuatBan,
                                                      NamXuatBan = c.NamXuatBan.Value,
                                                      TrangThai = c.TrangThai.Value,
                                                      SoLuong = c.SoLuong.Value,
                                                      SachHiem = c.SachHiem.Value,
                                                      DonGia = (int)c.DonGia.Value
                                                  }


                                         ).ToList();
            return ketqua;
        }

        public SachDTO LayDSDuocChon(string dssach)
        {
            SachDTO result = new SachDTO();

            result = data.Saches.Where(u => u.TrangThai.Value == true && u.MaSach == dssach).Select(u => new SachDTO
            {
                MaSach = u.MaSach,
                TenSach = u.TenSach,
                MaDauSach = u.MaDauSach,
                MaTheLoai = u.DauSach.MaTheLoai,
                TenTacGia = u.TenTacGia,
                TenNhaXuatBan = u.TenNhaXuatBan,
                NamXuatBan = u.NamXuatBan.Value,
                TrangThai = u.TrangThai.Value,
                SoLuong = u.SoLuong.Value,
                SachHiem = u.SachHiem.Value,
                DonGia = (int)u.DonGia,

            }).SingleOrDefault();

            return result;
        }
        public List<SachDTO> LaySachTheoDauSach(string MaDauSach)
        {
            List<SachDTO> lstSach = new List<SachDTO>();

            lstSach = data.Saches.Where(u => u.MaDauSach == MaDauSach).Select(u => new SachDTO
            {
                MaSach = u.MaSach,
                TenSach = u.TenSach,
                MaDauSach = u.MaDauSach,
                MaTheLoai = u.DauSach.MaTheLoai,
                TenTacGia = u.TenTacGia,
                TenNhaXuatBan = u.TenNhaXuatBan,
                NamXuatBan = u.NamXuatBan.Value,
                TrangThai = u.TrangThai.Value,
                SoLuong = u.SoLuong.Value,
                SachHiem = u.SachHiem.Value,
                DonGia = (int)u.DonGia,
            }).ToList();

            return lstSach;
        }
    }
}
