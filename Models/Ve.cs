using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Models
{
    public class Ve
    {
        public int VeId { get; set; }
        public string LoaiVe { get; set; } = "";
        public decimal Gia { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TrangThai { get; set; } = "Còn hạn";
        public int SoLuongOnline { get; set; }
        public int SoLuongOffline { get; set; }

        // Tính tổng số lượng
        public int TongSoLuong => SoLuongOnline + SoLuongOffline;

        // Kiểm tra vé còn hạn
        public bool ConHan => DateTime.Now <= NgayHetHan && TongSoLuong > 0;
    }
}