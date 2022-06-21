using DullStore.DAO;
using DullStore.Entities;
using DullStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DullStoreDbContex db = new DullStoreDbContex();
        public static SanPhamDAO sp = new SanPhamDAO();
        IQueryable<SanPham> ListSanPham = sp.ListSP();

        public ActionResult SPTheoMuc(int madm)
        {
            SanPhamDAO sp = new SanPhamDAO();
            IQueryable < SanPham > ListSP= sp.ListSP(madm);
            return View(ListSP);
        }

        public ActionResult Index(int ? trang)
        {
            //return View(ListSanPham);
            int sosptrentrang = 6;
            int stttrang = (trang ?? 1);
            return View(db.SanPham.ToList().OrderBy(x => x.ma).ToPagedList(stttrang, sosptrentrang));
        }
        public ActionResult KMProduct()
        {
            return View(ListSanPham);
        }
        public ActionResult BCProduct()
        {
            return View(ListSanPham);
        }

        public ActionResult ChitietSP(int id)
        {

            SanPham sptk = new SanPham();
            foreach (var item in ListSanPham)
            {
                if (item.ma == id) sptk = item;
            }
            ViewBag.spct = sptk;
            return View();
        }
        public ActionResult timkiem(string tensp)
        {
            SanPhamDAO sp = new SanPhamDAO();
            ViewData["TimKiem"] = sp.listspTimkiem(tensp);
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHang.FirstOrDefault(s => s.email == kh.email);
                if(check == null)
                {
                    kh.password = GetMD5(kh.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHang.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Tai khoan da ton tai";
                    return View();
                }
            }
            return View(kh);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.KhachHang.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data.Count > 0)
                {
                    Session["FullName"] = data.FirstOrDefault().hoten;
                    Session["Email"] = data.FirstOrDefault().email;
                    Session["idUser"] = data.FirstOrDefault().ma;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login that bai";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult UserInfo()
        {
            KhachHangDAO sp = new KhachHangDAO();
            int makh = int.Parse(Session["idUser"].ToString());
            List < GioHang > giohang = sp.listGioHang(makh);
            return View(giohang);
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}