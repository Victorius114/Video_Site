namespace Video_Site.Models
{
    public class DanhSachKhoaHoc
    {
        public string MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa {  get; set; }

        public string Thumbnail { get; set; }

        public List<DanhSachVideo> ListVideo { get; set; }
    }
}
