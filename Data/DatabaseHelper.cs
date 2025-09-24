using Microsoft.Data.SqlClient;
using System;

namespace DBMS.Data
{
    public static class DatabaseHelper
    {
        public static bool TEST_MODE = false;  // ← BẬT TEST MODE
        private static readonly string connectionString =
            "Server=tcp:khoi-dbms.database.windows.net,1433;" +
            "Initial Catalog=TraMy;" +
            "User ID=my_user;" +
            "Password=TraMy2005@@;" +
            "Persist Security Info=False;" +
            "MultipleActiveResultSets=False;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;" +
            "Connection Timeout=30;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            if (TEST_MODE) return true; // Bỏ qua test trong chế độ TEST

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Lỗi kết nối database:\n{ex.Message}",
                    "Lỗi Database",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}