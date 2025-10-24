using Video_Site.Entity;

namespace Video_Site.Services
{
    public class KhoaHocService
    {
        private Video_SiteContext db;
        public KhoaHocService(Video_SiteContext dbContext)
        {
            db = dbContext;
        }
        public List<KhoaHoc> Get()
        {
            return db.KhoaHocs.ToList();
        }
    }
}
