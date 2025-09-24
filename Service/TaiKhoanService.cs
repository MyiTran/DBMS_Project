#nullable disable
using System;
using DBMS.DAO;
using DBMS.Models;

namespace DBMS.Service
{
    public class TaiKhoanService
    {
        private TaiKhoanDAO taiKhoanDAO;

        public TaiKhoanService()
        {
            taiKhoanDAO = new TaiKhoanDAO();
        }

        public (bool thanhCong, string thongBao, TaiKhoan taiKhoan) DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                return (false, "Vui lòng nhập tên đăng nhập!", null);
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                return (false, "Vui lòng nhập mật khẩu!", null);
            }

            if (tenDangNhap.Length < 3)
            {
                return (false, "Tên đăng nhập phải có ít nhất 3 ký tự!", null);
            }

            if (matKhau.Length < 6)
            {
                return (false, "Mật khẩu phải có ít nhất 6 ký tự!", null);
            }

            TaiKhoan taiKhoan = taiKhoanDAO.KiemTraDangNhap(tenDangNhap, matKhau);

            if (taiKhoan != null)
            {
                PhienDangNhap.TenDangNhap = taiKhoan.TenDangNhap;
                PhienDangNhap.VaiTro = taiKhoan.VaiTro;
                PhienDangNhap.ThoiGianDangNhap = DateTime.Now;

                return (true, $"Chào mừng {taiKhoan.TenDangNhap}!", taiKhoan);
            }
            else
            {
                return (false, "Tên đăng nhập hoặc mật khẩu không đúng!", null);
            }
        }

        public bool KiemTraQuyen(string chucNangYeuCau)
        {
            string vaiTro = PhienDangNhap.VaiTro;

            switch (chucNangYeuCau.ToUpper())
            {
                case "QUAN_LY_TAI_KHOAN":
                    return vaiTro == "Admin";
                case "QUAN_LY_VE":
                    return vaiTro == "Admin" || vaiTro == "Manager";
                case "BAN_VE":
                    return vaiTro == "Admin" || vaiTro == "Manager" || vaiTro == "Staff";
                case "XEM_BAO_CAO":
                    return vaiTro == "Admin" || vaiTro == "Manager";
                case "QUAN_LY_DICH_VU":
                    return vaiTro == "Admin" || vaiTro == "Manager";
                case "QUAN_LY_KHACH_HANG":
                    return vaiTro == "Admin" || vaiTro == "Manager" || vaiTro == "Staff";
                default:
                    return vaiTro == "Admin";
            }
        }

        public string[] LayDanhSachQuyen()
        {
            string vaiTro = PhienDangNhap.VaiTro;

            switch (vaiTro)
            {
                case "Admin":
                    return new string[] { "Quản lý Tài khoản", "Quản lý Vé", "Bán Vé", "Quản lý Khách hàng", "Quản lý Dịch vụ", "Xem Báo cáo", "Cài đặt Hệ thống" };
                case "Manager":
                    return new string[] { "Quản lý Vé", "Bán Vé", "Quản lý Khách hàng", "Quản lý Dịch vụ", "Xem Báo cáo" };
                case "Staff":
                    return new string[] { "Bán Vé", "Quản lý Khách hàng", "Quản lý Dịch vụ" };
                case "User":
                    return new string[] { "Xem thông tin cơ bản" };
                default:
                    return new string[] { };
            }
        }

        public void DangXuat()
        {
            PhienDangNhap.XoaPhien();
        }

        public bool KiemTraDangNhap()
        {
            return PhienDangNhap.DaDangNhap;
        }
    }

    public static class PhienDangNhap
    {
        public static string TenDangNhap { get; set; } = "";
        public static string VaiTro { get; set; } = "";
        public static DateTime ThoiGianDangNhap { get; set; }

        public static bool DaDangNhap => !string.IsNullOrEmpty(TenDangNhap);

        public static void XoaPhien()
        {
            TenDangNhap = "";
            VaiTro = "";
            ThoiGianDangNhap = DateTime.MinValue;
        }

        public static string ThongTinPhien()
        {
            if (DaDangNhap)
                return $"{TenDangNhap} ({VaiTro}) - {ThoiGianDangNhap:HH:mm dd/MM/yyyy}";
            else
                return "Chưa đăng nhập";
        }
    }
}