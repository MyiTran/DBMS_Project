#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using DBMS.DAO;
using DBMS.Models;

namespace DBMS.Service
{
    public class VeService
    {
        private VeDAO veDAO;

        public VeService()
        {
            veDAO = new VeDAO();
        }

        /// <summary>
        /// Lấy tất cả vé
        /// </summary>
        public List<Ve> LayTatCaVe()
        {
            var danhSach = veDAO.LayTatCaVe();

            // Cập nhật trạng thái vé dựa trên ngày và số lượng
            foreach (var ve in danhSach)
            {
                ve.TrangThai = XacDinhTrangThaiVe(ve);
            }

            return danhSach;
        }

        /// <summary>
        /// Thêm vé mới với validation
        /// </summary>
        public (bool thanhCong, string thongBao) ThemVe(Ve ve)
        {
            // Validation
            var ketQuaValidation = ValidateVe(ve, true);
            if (!ketQuaValidation.hopLe)
            {
                return (false, ketQuaValidation.thongBao);
            }

            // Kiểm tra trùng loại vé
            if (KiemTraTrungLoaiVe(ve.LoaiVe, 0))
            {
                return (false, $"Loại vé '{ve.LoaiVe}' đã tồn tại trong hệ thống!");
            }

            // Xác định trạng thái ban đầu
            ve.TrangThai = XacDinhTrangThaiVe(ve);

            // Thêm vé
            bool ketQua = veDAO.ThemVe(ve);

            if (ketQua)
            {
                return (true, $"Thêm vé '{ve.LoaiVe}' thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi thêm vé!");
            }
        }

        /// <summary>
        /// Sửa thông tin vé
        /// </summary>
        public (bool thanhCong, string thongBao) SuaVe(Ve ve)
        {
            // Validation
            var ketQuaValidation = ValidateVe(ve, false);
            if (!ketQuaValidation.hopLe)
            {
                return (false, ketQuaValidation.thongBao);
            }

            // Kiểm tra vé có tồn tại không
            var veExisting = veDAO.LayVeTheoId(ve.VeId);
            if (veExisting == null)
            {
                return (false, "Vé không tồn tại!");
            }

            // Kiểm tra trùng loại vé (trừ chính nó)
            if (KiemTraTrungLoaiVe(ve.LoaiVe, ve.VeId))
            {
                return (false, $"Loại vé '{ve.LoaiVe}' đã được sử dụng bởi vé khác!");
            }

            // Cập nhật trạng thái
            ve.TrangThai = XacDinhTrangThaiVe(ve);

            // Sửa vé
            bool ketQua = veDAO.CapNhatVe(ve);

            if (ketQua)
            {
                return (true, $"Cập nhật vé '{ve.LoaiVe}' thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi cập nhật vé!");
            }
        }

        /// <summary>
        /// Xóa vé
        /// </summary>
        public (bool thanhCong, string thongBao) XoaVe(int veId)
        {
            var ve = veDAO.LayVeTheoId(veId);
            if (ve == null)
            {
                return (false, "Vé không tồn tại!");
            }

            // TODO: Kiểm tra ràng buộc - vé đã được bán chưa
            // Hiện tại chưa có BanVeDAO nên bỏ qua

            bool ketQua = veDAO.XoaVe(veId);

            if (ketQua)
            {
                return (true, $"Xóa vé '{ve.LoaiVe}' thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi xóa vé!");
            }
        }

        /// <summary>
        /// Lấy vé theo ID
        /// </summary>
        public Ve LayVeTheoId(int veId)
        {
            var ve = veDAO.LayVeTheoId(veId);
            if (ve != null)
            {
                ve.TrangThai = XacDinhTrangThaiVe(ve);
            }
            return ve;
        }

        /// <summary>
        /// Lấy danh sách vé còn bán được
        /// </summary>
        public List<Ve> LayVeConBan()
        {
            return LayTatCaVe().Where(v => v.ConHan).ToList();
        }

        /// <summary>
        /// Cập nhật số lượng vé sau khi bán
        /// </summary>
        public (bool thanhCong, string thongBao) CapNhatSoLuongSauKhiBan(int veId, int soLuongBan, string kenh)
        {
            var ve = veDAO.LayVeTheoId(veId);
            if (ve == null)
            {
                return (false, "Vé không tồn tại!");
            }

            // Kiểm tra vé còn bán được không
            if (!ve.ConHan)
            {
                return (false, "Vé đã hết hạn hoặc hết hàng!");
            }

            // Kiểm tra số lượng đủ không
            if (kenh.ToLower() == "online" && ve.SoLuongOnline < soLuongBan)
            {
                return (false, $"Không đủ vé online! Còn lại: {ve.SoLuongOnline}");
            }

            if (kenh.ToLower() == "offline" && ve.SoLuongOffline < soLuongBan)
            {
                return (false, $"Không đủ vé offline! Còn lại: {ve.SoLuongOffline}");
            }

            // Cập nhật số lượng
            bool ketQua = veDAO.CapNhatSoLuongVe(veId, soLuongBan, kenh);

            if (ketQua)
            {
                return (true, "Cập nhật số lượng vé thành công!");
            }
            else
            {
                return (false, "Có lỗi xảy ra khi cập nhật số lượng vé!");
            }
        }

        /// <summary>
        /// Validation vé
        /// </summary>
        private (bool hopLe, string thongBao) ValidateVe(Ve ve, bool isThemMoi)
        {
            // Kiểm tra loại vé
            if (string.IsNullOrWhiteSpace(ve.LoaiVe))
            {
                return (false, "Vui lòng nhập loại vé!");
            }

            if (ve.LoaiVe.Trim().Length < 3)
            {
                return (false, "Loại vé phải có ít nhất 3 ký tự!");
            }

            if (ve.LoaiVe.Length > 50)
            {
                return (false, "Loại vé không được vượt quá 50 ký tự!");
            }

            // Kiểm tra giá
            if (ve.Gia <= 0)
            {
                return (false, "Giá vé phải lớn hơn 0!");
            }

            if (ve.Gia > 999999999)
            {
                return (false, "Giá vé không được vượt quá 999,999,999 VND!");
            }

            // Kiểm tra ngày hiệu lực và hết hạn
            if (ve.NgayHetHan <= ve.NgayHieuLuc)
            {
                return (false, "Ngày hết hạn phải sau ngày hiệu lực!");
            }

            if (isThemMoi && ve.NgayHieuLuc < DateTime.Today)
            {
                return (false, "Ngày hiệu lực không được trước hôm nay!");
            }

            // Kiểm tra thời gian hợp lý (không quá 5 năm)
            if ((ve.NgayHetHan - ve.NgayHieuLuc).TotalDays > 1825) // 5 năm
            {
                return (false, "Thời hạn vé không được vượt quá 5 năm!");
            }

            // Kiểm tra số lượng
            if (ve.SoLuongOnline < 0)
            {
                return (false, "Số lượng online không được âm!");
            }

            if (ve.SoLuongOffline < 0)
            {
                return (false, "Số lượng offline không được âm!");
            }

            if (ve.TongSoLuong == 0)
            {
                return (false, "Tổng số lượng vé phải lớn hơn 0!");
            }

            if (ve.TongSoLuong > 999999)
            {
                return (false, "Tổng số lượng không được vượt quá 999,999!");
            }

            return (true, "Thông tin hợp lệ");
        }

        /// <summary>
        /// Xác định trạng thái vé
        /// </summary>
        private string XacDinhTrangThaiVe(Ve ve)
        {
            if (DateTime.Now > ve.NgayHetHan)
            {
                return "Hết hạn";
            }

            if (ve.TongSoLuong <= 0)
            {
                return "Hết hàng";
            }

            if (DateTime.Now < ve.NgayHieuLuc)
            {
                return "Chưa có hiệu lực";
            }

            return "Còn hạn";
        }

        /// <summary>
        /// Kiểm tra trùng loại vé
        /// </summary>
        private bool KiemTraTrungLoaiVe(string loaiVe, int excludeId)
        {
            var danhSach = veDAO.LayTatCaVe();
            return danhSach.Any(v => v.LoaiVe.Equals(loaiVe.Trim(), StringComparison.OrdinalIgnoreCase)
                                    && v.VeId != excludeId);
        }

        /// <summary>
        /// Thống kê số loại vé
        /// </summary>
        public int DemSoLoaiVe()
        {
            return veDAO.LayTatCaVe().Count;
        }

        /// <summary>
        /// Thống kê tổng số lượng vé
        /// </summary>
        public (int tongOnline, int tongOffline, int tongTatCa) ThongKeSoLuongVe()
        {
            var danhSach = veDAO.LayTatCaVe();

            int tongOnline = danhSach.Sum(v => v.SoLuongOnline);
            int tongOffline = danhSach.Sum(v => v.SoLuongOffline);
            int tongTatCa = tongOnline + tongOffline;

            return (tongOnline, tongOffline, tongTatCa);
        }

        /// <summary>
        /// Lấy danh sách vé sắp hết hạn (trong X ngày)
        /// </summary>
        public List<Ve> LayVeSapHetHan(int soNgay = 30)
        {
            var ngayKiemTra = DateTime.Now.AddDays(soNgay);
            return veDAO.LayTatCaVe()
                       .Where(v => v.NgayHetHan <= ngayKiemTra && v.NgayHetHan > DateTime.Now)
                       .OrderBy(v => v.NgayHetHan)
                       .ToList();
        }
    }
}