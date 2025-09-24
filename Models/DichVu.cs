using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Models
{
    public class DichVu
    {
        public int DichVuId { get; set; }
        public string TenDichVu { get; set; } = "";
        public decimal Gia { get; set; }
        public string MoTa { get; set; } = "";
        public string TrangThai { get; set; } = "Đang ký";
        public int KhachHangId { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string PhuongThuc { get; set; } = "Tiền mặt";

        // Thông tin bổ sung
        public string TenKhachHang { get; set; } = "";

        public DichVu()
        {
            NgayDangKy = DateTime.Now;
            SoLuong = 1;
        }

        // Method tính lại tổng tiền
        public void TinhLaiTongTien()
        {
            TongTien = Gia * SoLuong;
        }
    }
}