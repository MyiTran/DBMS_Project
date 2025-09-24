using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.Models
{
    public class TaiKhoan
    {
        public int TaiKhoanId { get; set; }
        public string TenDangNhap { get; set; } = "";
        public string MatKhau { get; set; } = "";
        public string VaiTro { get; set; } = "User";
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; } = true;

        public TaiKhoan()
        {
            NgayTao = DateTime.Now;
        }
    }
}