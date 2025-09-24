namespace DBMS.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            quanLyToolStripMenuItem = new ToolStripMenuItem();
            khachHangToolStripMenuItem = new ToolStripMenuItem();
            veToolStripMenuItem = new ToolStripMenuItem();
            dichVuToolStripMenuItem = new ToolStripMenuItem();
            baoCaoToolStripMenuItem = new ToolStripMenuItem();
            heThongToolStripMenuItem = new ToolStripMenuItem();
            dangXuatToolStripMenuItem = new ToolStripMenuItem();
            banVeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { quanLyToolStripMenuItem, baoCaoToolStripMenuItem, heThongToolStripMenuItem, banVeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1274, 42);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // quanLyToolStripMenuItem
            // 
            quanLyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { khachHangToolStripMenuItem, veToolStripMenuItem, dichVuToolStripMenuItem });
            quanLyToolStripMenuItem.Name = "quanLyToolStripMenuItem";
            quanLyToolStripMenuItem.Size = new Size(121, 36);
            quanLyToolStripMenuItem.Text = "Quan Ly";
            // 
            // khachHangToolStripMenuItem
            // 
            khachHangToolStripMenuItem.Name = "khachHangToolStripMenuItem";
            khachHangToolStripMenuItem.Size = new Size(359, 44);
            khachHangToolStripMenuItem.Text = "Khach Hang";
            khachHangToolStripMenuItem.Click += khachHangToolStripMenuItem_Click;
            // 
            // veToolStripMenuItem
            // 
            veToolStripMenuItem.Name = "veToolStripMenuItem";
            veToolStripMenuItem.Size = new Size(359, 44);
            veToolStripMenuItem.Text = "Ve";
            veToolStripMenuItem.Click += veToolStripMenuItem_Click;
            // 
            // dichVuToolStripMenuItem
            // 
            dichVuToolStripMenuItem.Name = "dichVuToolStripMenuItem";
            dichVuToolStripMenuItem.Size = new Size(359, 44);
            dichVuToolStripMenuItem.Text = "Dich Vu";
            dichVuToolStripMenuItem.Click += dichVuToolStripMenuItem_Click;
            // 
            // baoCaoToolStripMenuItem
            // 
            baoCaoToolStripMenuItem.Name = "baoCaoToolStripMenuItem";
            baoCaoToolStripMenuItem.Size = new Size(122, 36);
            baoCaoToolStripMenuItem.Text = "Bao Cao";
            baoCaoToolStripMenuItem.Click += baoCaoToolStripMenuItem_Click_1;
            // 
            // heThongToolStripMenuItem
            // 
            heThongToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dangXuatToolStripMenuItem });
            heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            heThongToolStripMenuItem.Size = new Size(140, 36);
            heThongToolStripMenuItem.Text = "He Thong";
            // 
            // dangXuatToolStripMenuItem
            // 
            dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            dangXuatToolStripMenuItem.Size = new Size(259, 44);
            dangXuatToolStripMenuItem.Text = "Dang Xuat";
            dangXuatToolStripMenuItem.Click += dangXuatToolStripMenuItem_Click;
            // 
            // banVeToolStripMenuItem
            // 
            banVeToolStripMenuItem.Name = "banVeToolStripMenuItem";
            banVeToolStripMenuItem.Size = new Size(107, 38);
            banVeToolStripMenuItem.Text = "Ban Ve";
            banVeToolStripMenuItem.Click += banVeToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1274, 718);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem quanLyToolStripMenuItem;
        private ToolStripMenuItem khachHangToolStripMenuItem;
        private ToolStripMenuItem veToolStripMenuItem;
        private ToolStripMenuItem dichVuToolStripMenuItem;
        private ToolStripMenuItem baoCaoToolStripMenuItem;
        private ToolStripMenuItem heThongToolStripMenuItem;
        private ToolStripMenuItem dangXuatToolStripMenuItem;
        private ToolStripMenuItem banVeToolStripMenuItem;
    }
}