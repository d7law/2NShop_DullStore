using DullStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class KhachHangDAO
    {
        DullStoreDbContex db;
        public KhachHangDAO()
        {
            db = new DullStoreDbContex();
        }
        public IQueryable<KhachHang> listKH()
        {
            var res = (from kh in db.KhachHang select kh);
            return res;
        }
        public bool Login(string tk, string mk)
        {
            var res = db.KhachHang.Count(x => x.email == tk && x.password == mk);
            if (res > 0)
                return true;
            else
                return false;
        }
        public List<GioHang> listGioHang(int makhachhang)
        {
            string search = "select * from GioHang where makhachhang = " + makhachhang;
            var rs = db.GioHang.SqlQuery(search).ToList();
            return rs;
        }
    }
}