using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using Video_Site.Models;

namespace Video_Site.Controllers
{
    public class KhoaHocController : Controller
    {
        private string connectionString = "Server= DESKTOP-VICTOR1\\SQLEXPRESS; Database = Video_Site; User Id = sa; Password = 1234;";
        public IActionResult DanhSach()
        {
            return View();
        }
        [Route("bai-hoc")]
        public IActionResult DanhSachBaiHoc()
        {
            return View();
        }

        [Route("thong-tin-khoa-hoc")]
        public IActionResult ThongTin(string MaKhoaHoc)
        {
            if (string.IsNullOrEmpty(MaKhoaHoc))
            {
                return RedirectToAction("Index", "Home");
            }
            List<DanhSachVideo> VidList = new List<DanhSachVideo>();
            DanhSachKhoaHoc khoa_hoc = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string queryKhoa = "select * from KhoaHoc where MaKhoaHoc = @MaKhoaHoc";
                SqlCommand cmdKhoa = new SqlCommand(queryKhoa, conn);
                cmdKhoa.Parameters.AddWithValue("@MaKhoaHoc", MaKhoaHoc);
                SqlDataReader reader = cmdKhoa.ExecuteReader();
                if (reader.Read())
                {
                    khoa_hoc = new DanhSachKhoaHoc
                    {
                        MaKhoaHoc = reader["MaKhoaHoc"].ToString(),
                        TenKhoaHoc = reader["TenKhoaHoc"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        Thumbnail = reader["Thumbnail"].ToString()
                    };
                }
                reader.Close();

                string queryVideo = "select * from VideoKhoaHoc where MaKhoaHoc = @MaKhoaHoc";
                SqlCommand cmdVideo = new SqlCommand(queryVideo, conn);
                cmdVideo.Parameters.AddWithValue("@MaKhoaHoc", MaKhoaHoc);
                SqlDataReader readerVideo = cmdVideo.ExecuteReader();

                while(readerVideo.Read())
                {
                    VidList.Add(new DanhSachVideo
                    {
                        MaVideo = readerVideo["MaVideo"].ToString(),
                        MaKhoaHoc = readerVideo["MaKhoaHoc"].ToString(),
                        TieuDe = readerVideo["TieuDe"].ToString(),
                        Link = readerVideo["Link"].ToString()
                    });
                }
            }
            ViewBag.KhoaHoc = khoa_hoc;
            ViewBag.DanhSachVideo = VidList;
            return View();
        }
    }
}
