#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DBMS.DAO;
using DBMS.Models;

namespace DBMS.Service
{
    public class KhachHangService
    {
        private KhachHangDAO khachHangDAO;

        public KhachHangService()
        {
            khachHangDAO = new KhachHangDAO();
        }

        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        public List<KhachHang> LayTatCaKhachHang()
        {
            return khachHangDAO.LayTatCaKhachHang();
        }

        /// <summary>
        /// Thêm khách hàng mới với validation
        /// </summary>
        public (bool thanhCong, string thongBao) ThemKhachHang(KhachHang khachHang)
        {
            // Validation
            var ketQuaValidation = ValidateKhachHang(khachHang);
            if (!ketQuaValidation.hopLe)
            {
                return (false, ketQuaValidation.thongBao);
            }

            // Kiểm tra trùng số điện thoại
            if (KiemTraTrungSoDienThoai(khachHang.SoDienThoai, 0))
            {
                return (false, "Số điện thoại đã tồn tại trong hệ thống!");
            }

            // Kiểm tra trùng email
            if (!string.IsNullOrEmpty(khachHang.Email) && KiemTraTrungEmail(khachHang.Email, 0))
            {
                return (false, "Email đã tồn tại trong hệ thống!");
            }

            // Thêm khách hàng
            bool ketQua = khachHangDAO.ThemKhachHang(khachHang);

            if (ketQua)
            {
                return (true, $"Thêm khách hàng {khachHang.HoTen} thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi thêm khách hàng!");
            }
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        public (bool thanhCong, string thongBao) SuaKhachHang(KhachHang khachHang)
        {
            // Validation
            var ketQuaValidation = ValidateKhachHang(khachHang);
            if (!ketQuaValidation.hopLe)
            {
                return (false, ketQuaValidation.thongBao);
            }

            // Kiểm tra khách hàng có tồn tại không
            var khExisting = khachHangDAO.LayKhachHangTheoId(khachHang.KhachHangId);
            if (khExisting == null)
            {
                return (false, "Khách hàng không tồn tại!");
            }

            // Kiểm tra trùng số điện thoại (trừ chính nó)
            if (KiemTraTrungSoDienThoai(khachHang.SoDienThoai, khachHang.KhachHangId))
            {
                return (false, "Số điện thoại đã được sử dụng bởi khách hàng khác!");
            }

            // Kiểm tra trùng email (trừ chính nó)
            if (!string.IsNullOrEmpty(khachHang.Email) && KiemTraTrungEmail(khachHang.Email, khachHang.KhachHangId))
            {
                return (false, "Email đã được sử dụng bởi khách hàng khác!");
            }

            // Sửa khách hàng
            bool ketQua = khachHangDAO.SuaKhachHang(khachHang);

            if (ketQua)
            {
                return (true, $"Cập nhật thông tin khách hàng {khachHang.HoTen} thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi cập nhật khách hàng!");
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public (bool thanhCong, string thongBao) XoaKhachHang(int khachHangId)
        {
            var khachHang = khachHangDAO.LayKhachHangTheoId(khachHangId);
            if (khachHang == null)
            {
                return (false, "Khách hàng không tồn tại!");
            }

            // TODO: Kiểm tra ràng buộc - khách hàng đã mua vé hay sử dụng dịch vụ chưa
            // Hiện tại chưa có BanVeDAO và DichVuDAO nên bỏ qua

            bool ketQua = khachHangDAO.XoaKhachHang(khachHangId);

            if (ketQua)
            {
                return (true, $"Xóa khách hàng {khachHang.HoTen} thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi xóa khách hàng!");
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        public List<KhachHang> TimKhachHang(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return LayTatCaKhachHang();
            }

            return khachHangDAO.TimKhachHang(keyword);
        }

        /// <summary>
        /// Lấy khách hàng theo ID
        /// </summary>
        public KhachHang LayKhachHangTheoId(int khachHangId)
        {
            return khachHangDAO.LayKhachHangTheoId(khachHangId);
        }

        /// <summary>
        /// Validation khách hàng
        /// </summary>
        private (bool hopLe, string thongBao) ValidateKhachHang(KhachHang khachHang)
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(khachHang.HoTen))
            {
                return (false, "Vui lòng nhập họ tên khách hàng!");
            }

            if (khachHang.HoTen.Trim().Length < 2)
            {
                return (false, "Họ tên phải có ít nhất 2 ký tự!");
            }

            if (khachHang.HoTen.Length > 100)
            {
                return (false, "Họ tên không được vượt quá 100 ký tự!");
            }

            // Kiểm tra giới tính
            if (!string.IsNullOrEmpty(khachHang.GioiTinh))
            {
                var gioiTinhHopLe = new[] { "Nam", "Nữ", "Khác" };
                if (!gioiTinhHopLe.Contains(khachHang.GioiTinh))
                {
                    return (false, "Giới tính chỉ được chọn: Nam, Nữ hoặc Khác!");
                }
            }

            // Kiểm tra ngày sinh
            if (khachHang.NgaySinh.HasValue)
            {
                if (khachHang.NgaySinh.Value > DateTime.Now)
                {
                    return (false, "Ngày sinh không được sau ngày hôm nay!");
                }

                if (khachHang.NgaySinh.Value.Year < 1900)
                {
                    return (false, "Ngày sinh không hợp lệ!");
                }

                // Kiểm tra tuổi hợp lý (không quá 150 tuổi)
                int tuoi = DateTime.Now.Year - khachHang.NgaySinh.Value.Year;
                if (tuoi > 150)
                {
                    return (false, "Tuổi không hợp lệ!");
                }
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(khachHang.SoDienThoai))
            {
                return (false, "Vui lòng nhập số điện thoại!");
            }

            if (!ValidatePhoneNumber(khachHang.SoDienThoai))
            {
                return (false, "Số điện thoại không đúng định dạng! (VD: 0123456789)");
            }

            // Kiểm tra email
            if (!string.IsNullOrEmpty(khachHang.Email) && !ValidateEmail(khachHang.Email))
            {
                return (false, "Email không đúng định dạng!");
            }

            return (true, "Thông tin hợp lệ");
        }

        /// <summary>
        /// Kiểm tra định dạng số điện thoại
        /// </summary>
        private bool ValidatePhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return false;

            // Regex cho số điện thoại Việt Nam: 10-11 số, bắt đầu bằng 0
            var regex = new Regex(@"^0[0-9]{8,10}$");
            return regex.IsMatch(phone);
        }

        /// <summary>
        /// Kiểm tra định dạng email
        /// </summary>
        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return true; // Email không bắt buộc

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }

        /// <summary>
        /// Kiểm tra trùng số điện thoại
        /// </summary>
        private bool KiemTraTrungSoDienThoai(string soDienThoai, int excludeId)
        {
            var danhSach = khachHangDAO.LayTatCaKhachHang();
            return danhSach.Any(kh => kh.SoDienThoai == soDienThoai && kh.KhachHangId != excludeId);
        }

        /// <summary>
        /// Kiểm tra trùng email
        /// </summary>
        private bool KiemTraTrungEmail(string email, int excludeId)
        {
            var danhSach = khachHangDAO.LayTatCaKhachHang();
            return danhSach.Any(kh => !string.IsNullOrEmpty(kh.Email) &&
                                     kh.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                                     kh.KhachHangId != excludeId);
        }

        /// <summary>
        /// Thống kê số lượng khách hàng
        /// </summary>
        public int DemSoLuongKhachHang()
        {
            return khachHangDAO.LayTatCaKhachHang().Count;
        }

        /// <summary>
        /// Lấy khách hàng mới đăng ký trong X ngày
        /// </summary>
        public List<KhachHang> LayKhachHangMoi(int soNgay = 7)
        {
            var tuNgay = DateTime.Now.AddDays(-soNgay);
            return khachHangDAO.LayTatCaKhachHang()
                              .Where(kh => kh.NgayDangKy >= tuNgay)
                              .OrderByDescending(kh => kh.NgayDangKy)
                              .ToList();
        }
    }
}