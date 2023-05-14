using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraspWayDataAccessLayer.Repositories
{
    internal class NoticeBoardRepo : Repo, IData<NoticeBoard, int, bool>
    {
        public List<NoticeBoard> Get()
        {
            return db.NoticesBoards.ToList();
        }

        public NoticeBoard Get(int id)
        {
            return db.NoticesBoards.Find(id);
        }

        public bool Add(NoticeBoard obj)
        {
            db.NoticesBoards.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(NoticeBoard obj)
        {
            var notice = Get(obj.Id);
            db.Entry(notice).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var notice = Get(id);
            db.NoticesBoards.Remove(notice);
            return db.SaveChanges() > 0;
        }
    }
}

