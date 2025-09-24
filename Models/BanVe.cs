using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Models
{
    public class BanVe
    {
        public int BanVeId { get; set; }
        public int VeId { get; set; }
        public int KhachHangId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
        public string ThanhToan { get; set; } = "Tiền mặt";
        public string TrangThai { get; set; } = "Hoàn thành";
        public DateTime NgayBan { get; set; }
        public string Kenh { get; set; } = "offline"; // online/offline

        // Thông tin bổ sung từ JOIN
        public string TenKhachHang { get; set; } = "";
        public string LoaiVe { get; set; } = "";

        public BanVe()
        {
            NgayBan = DateTime.Now;
            // Tự động tính tổng tiền
            TongTien = (DonGia * SoLuong) - GiamGia;
        }

        // Method tính lại tổng tiền
        public void TinhLaiTongTien()
        {
            TongTien = (DonGia * SoLuong) - GiamGia;
        }
    }
}