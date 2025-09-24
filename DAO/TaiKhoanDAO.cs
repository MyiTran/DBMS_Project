using Microsoft.Data.SqlClient;
using DBMS.Models;
using DBMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBMS.DAO
{
    public class TaiKhoanDAO
    {
        // Data giả cho TEST MODE
        private static List<TaiKhoan> dataGia = new List<TaiKhoan>
        {
            new TaiKhoan { TaiKhoanId = 1, TenDangNhap = "admin", MatKhau = "123456", VaiTro = "Admin", NgayTao = DateTime.Now, TrangThai = true },
            new TaiKhoan { TaiKhoanId = 2, TenDangNhap = "user", MatKhau = "123456", VaiTro = "User", NgayTao = DateTime.Now, TrangThai = true },
            new TaiKhoan { TaiKhoanId = 3, TenDangNhap = "manager", MatKhau = "123456", VaiTro = "Manager", NgayTao = DateTime.Now, TrangThai = true },
            new TaiKhoan { TaiKhoanId = 4, TenDangNhap = "staff", MatKhau = "123456", VaiTro = "Staff", NgayTao = DateTime.Now, TrangThai = true }
        };

        public TaiKhoan KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            // Nếu TEST MODE → dùng data giả
            if (DatabaseHelper.TEST_MODE)
            {
                return dataGia.FirstOrDefault(tk =>
                    tk.TenDangNhap.Equals(tenDangNhap, StringComparison.OrdinalIgnoreCase)
                    && tk.MatKhau == matKhau);
            }

            // Nếu PRODUCTION MODE → dùng database
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_DangNhap", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TaiKhoan
                                {
                                    TaiKhoanId = reader.GetInt32(0),
                                    TenDangNhap = reader.GetString(1),
                                    MatKhau = reader.GetString(2),
                                    VaiTro = reader.GetString(3),
                                    NgayTao = reader.GetDateTime(4),
                                    TrangThai = reader.GetBoolean(5)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đăng nhập database: {ex.Message}");
            }

            return null;
        }
    }
}