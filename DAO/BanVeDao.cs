using Microsoft.Data.SqlClient;
using DBMS.Models;
using DBMS.Data;
using System;
using System.Collections.Generic;

namespace DBMS.DAO
{
    public class BanVeDAO
    {
        // Data giả cho TEST MODE
        private static List<BanVe> dataGia = new List<BanVe>();
        private static int nextId = 1;

        public (bool thanhCong, string thongBao) BanVe(BanVe banVe)
        {
            // Validation C# (trước khi gọi SP)
            if (banVe.SoLuong <= 0)
                return (false, "Số lượng phải lớn hơn 0!");

            if (banVe.DonGia <= 0)
                return (false, "Đơn giá phải lớn hơn 0!");

            if (banVe.GiamGia < 0)
                return (false, "Giảm giá không được âm!");

            if (banVe.GiamGia > (banVe.DonGia * banVe.SoLuong))
                return (false, "Giảm giá không được lớn hơn tổng tiền!");

            if (banVe.Kenh != "online" && banVe.Kenh != "offline")
                return (false, "Kênh chỉ được là online hoặc offline!");

            if (DatabaseHelper.TEST_MODE)
            {
                banVe.BanVeId = nextId++;
                banVe.NgayBan = DateTime.Now;
                banVe.TongTien = (banVe.DonGia * banVe.SoLuong) - banVe.GiamGia;
                dataGia.Add(banVe);
                return (true, "Bán vé thành công (TEST MODE)!");
            }

            // Gọi SP (database sẽ validate lại lần nữa)
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_BanVe", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VeId", banVe.VeId);
                        cmd.Parameters.AddWithValue("@KhachHangId", banVe.KhachHangId);
                        cmd.Parameters.AddWithValue("@SoLuong", banVe.SoLuong);
                        cmd.Parameters.AddWithValue("@GiamGia", banVe.GiamGia);
                        cmd.Parameters.AddWithValue("@ThanhToan", banVe.ThanhToan);
                        cmd.Parameters.AddWithValue("@Kenh", banVe.Kenh);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            banVe.BanVeId = Convert.ToInt32(result);
                            return (true, "Bán vé thành công!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return (false, ex.Message);
            }

            return (false, "Có lỗi xảy ra!");
        }

        public List<BanVe> LayDanhSachBanVe(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            if (DatabaseHelper.TEST_MODE)
            {
                return dataGia;
            }

            var list = new List<BanVe>();
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_LayDanhSachBanVe", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay ?? (object)DBNull.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new BanVe
                                {
                                    BanVeId = reader.GetInt32(0),
                                    VeId = reader.GetInt32(1),
                                    LoaiVe = reader.GetString(2),
                                    KhachHangId = reader.GetInt32(3),
                                    TenKhachHang = reader.GetString(4),
                                    SoLuong = reader.GetInt32(5),
                                    DonGia = reader.GetDecimal(6),
                                    GiamGia = reader.GetDecimal(7),
                                    TongTien = reader.GetDecimal(8),
                                    ThanhToan = reader.GetString(9),
                                    TrangThai = reader.GetString(10),
                                    NgayBan = reader.GetDateTime(11),
                                    Kenh = reader.GetString(12)
                                });
                            }
                        }
                    }
                }
            }
            catch { }
            return list;
        }
    }
}