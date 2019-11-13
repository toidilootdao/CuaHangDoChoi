﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
        public class SanPhamDAO
        {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            private set => instance = value;
        }

        private SanPhamDAO() { }

        // đổ data vào 
        public List<SanPham> LaySanPham()
        {
            List<SanPham> sp = new List<SanPham>();
            string query = "SELECT * FROM dbo.SanPham";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                sp.Add(new SanPham(row));
            }
            return sp;
        }

        public List<SanPham> TimSP(int masanpham)
        {
            List<SanPham> nv = new List<SanPham>();
            string query = "SELECT * FROM dbo.SanPham WHERE maSanPham = '" + masanpham + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                nv.Add(new SanPham(row));
            }
            return nv;
        }
    }
}
