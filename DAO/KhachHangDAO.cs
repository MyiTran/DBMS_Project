using System;
using System.Collections.Generic;
using System.Linq;
using DBMS.Models;

namespace DBMS.DAO
{
    public class KhachHangDAO
    {
        // Giả lập database bằng static List
        private static List<KhachHang> danhSachKhachHang = new List<KhachHang>
        {
            new KhachHang { KhachHangId = 1, HoTen = "Nguyễn Văn A", GioiTinh = "Nam",
                           SoDienThoai = "0123456789", Email = "nva@gmail.com", NgayDangKy = DateTime.Now.AddDays(-30) },
            new KhachHang { KhachHangId = 2, HoTen = "Trần Thị B", GioiTinh = "Nữ",
                           SoDienThoai = "0987654321", Email = "ttb@gmail.com", NgayDangKy = DateTime.Now.AddDays(-15) },
            new KhachHang { KhachHangId = 3, HoTen = "Lê Văn C", GioiTinh = "Nam",
                           SoDienThoai = "0111222333", Email = "lvc@gmail.com", NgayDangKy = DateTime.Now.AddDays(-7) }
        };

        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        public List<KhachHang> LayTatCaKhachHang()
        {
            return danhSachKhachHang.ToList();
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        public bool ThemKhachHang(KhachHang khachHang)
        {
            try
            {
                khachHang.KhachHangId = danhSachKhachHang.Max(k => k.KhachHangId) + 1;
                khachHang.NgayDangKy = DateTime.Now;
                danhSachKhachHang.Add(khachHang);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        public bool SuaKhachHang(KhachHang khachHang)
        {
            var khExisting = danhSachKhachHang.FirstOrDefault(k => k.KhachHangId == khachHang.KhachHangId);
            if (khExisting != null)
            {
                khExisting.HoTen = khachHang.HoTen;
                khExisting.GioiTinh = khachHang.GioiTinh;
                khExisting.NgaySinh = khachHang.NgaySinh;
                khExisting.SoDienThoai = khachHang.SoDienThoai;
                khExisting.Email = khachHang.Email;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public bool XoaKhachHang(int khachHangId)
        {
            var kh = danhSachKhachHang.FirstOrDefault(k => k.KhachHangId == khachHangId);
            if (kh != null)
            {
                danhSachKhachHang.Remove(kh);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        public List<KhachHang> TimKhachHang(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return LayTatCaKhachHang();

            return danhSachKhachHang.Where(k =>
                k.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                k.SoDienThoai.Contains(keyword) ||
                k.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        /// <summary>
        /// Lấy khách hàng theo ID
        /// </summary>
        public KhachHang LayKhachHangTheoId(int khachHangId)
        {
            return danhSachKhachHang.FirstOrDefault(k => k.KhachHangId == khachHangId);
        }
    }
}