using System;
using System.Collections.Generic;
using System.Linq;
using DBMS.Models;

namespace DBMS.DAO
{
    public class VeDAO
    {
        // Giả lập database
        private static List<Ve> danhSachVe = new List<Ve>
        {
            new Ve { VeId = 1, LoaiVe = "Vé người lớn", Gia = 100000, NgayHieuLuc = DateTime.Now,
                    NgayHetHan = DateTime.Now.AddMonths(6), SoLuongOnline = 1000, SoLuongOffline = 500 },
            new Ve { VeId = 2, LoaiVe = "Vé trẻ em", Gia = 50000, NgayHieuLuc = DateTime.Now,
                    NgayHetHan = DateTime.Now.AddMonths(6), SoLuongOnline = 500, SoLuongOffline = 300 },
            new Ve { VeId = 3, LoaiVe = "Vé học sinh", Gia = 30000, NgayHieuLuc = DateTime.Now,
                    NgayHetHan = DateTime.Now.AddMonths(6), SoLuongOnline = 200, SoLuongOffline = 100 }
        };

        public List<Ve> LayTatCaVe()
        {
            return danhSachVe.ToList();
        }

        public bool ThemVe(Ve ve)
        {
            try
            {
                ve.VeId = danhSachVe.Max(v => v.VeId) + 1;
                danhSachVe.Add(ve);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhatVe(Ve ve)
        {
            var veExisting = danhSachVe.FirstOrDefault(v => v.VeId == ve.VeId);
            if (veExisting != null)
            {
                veExisting.LoaiVe = ve.LoaiVe;
                veExisting.Gia = ve.Gia;
                veExisting.NgayHieuLuc = ve.NgayHieuLuc;
                veExisting.NgayHetHan = ve.NgayHetHan;
                veExisting.TrangThai = ve.TrangThai;
                veExisting.SoLuongOnline = ve.SoLuongOnline;
                veExisting.SoLuongOffline = ve.SoLuongOffline;
                return true;
            }
            return false;
        }

        public bool XoaVe(int veId)
        {
            var ve = danhSachVe.FirstOrDefault(v => v.VeId == veId);
            if (ve != null)
            {
                danhSachVe.Remove(ve);
                return true;
            }
            return false;
        }

        public Ve LayVeTheoId(int veId)
        {
            return danhSachVe.FirstOrDefault(v => v.VeId == veId);
        }

        /// <summary>
        /// Cập nhật số lượng vé khi bán
        /// </summary>
        public bool CapNhatSoLuongVe(int veId, int soLuongBan, string kenh)
        {
            var ve = LayVeTheoId(veId);
            if (ve == null) return false;

            if (kenh.ToLower() == "online")
            {
                if (ve.SoLuongOnline >= soLuongBan)
                {
                    ve.SoLuongOnline -= soLuongBan;
                    return true;
                }
            }
            else if (kenh.ToLower() == "offline")
            {
                if (ve.SoLuongOffline >= soLuongBan)
                {
                    ve.SoLuongOffline -= soLuongBan;
                    return true;
                }
            }

            return false; // Không đủ số lượng
        }
    }
}