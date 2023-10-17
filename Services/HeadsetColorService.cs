using VJAUDIO.Models;

namespace VJAUDIO.Services
{
    public class HeadsetColorService
    {
        public static bool Add(MariaDbContext db, string color)
        {
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    HeadsetColor headset = new HeadsetColor();
                    headset.Color = color;
                    headset.Count = 1;
                    db.Add(headset);
                    db.SaveChanges();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                }
            }
            return true;
        }

        public static bool Update(MariaDbContext db, string color)
        {
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    HeadsetColor headset = db.HeadsetColor.FirstOrDefault(x => x.Color == color);
                    headset.Count = headset.Count + 1;
                    db.Update(headset);
                    db.SaveChanges();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                }
            }
            return true;
        }
    }
}
