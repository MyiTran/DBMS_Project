using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Models
{
    public class KhachHang
    {
        public int KhachHangId { get; set; }
        public string HoTen { get; set; } = "";
        public string GioiTinh { get; set; } = "";
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime NgayDangKy { get; set; }
        public int? TaiKhoanId { get; set; }

        public KhachHang()
        {
            NgayDangKy = DateTime.Now;
        }
    }
}