using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class NoticeBoardService
    {
        public static List<NoticeBoardDTO> Get()
        {
            var data = DataAccessFactory.NoticeBoardData().Get();
            return Convert(data);
        }

        public static NoticeBoardDTO Get(int id)
        {
            return Convert(DataAccessFactory.NoticeBoardData().Get(id));
        }

        public static bool Create(NoticeBoardDTO noticeBoard)
        {
            var data = Convert(noticeBoard);
            return DataAccessFactory.NoticeBoardData().Add(data);
        }

        public static bool Update(NoticeBoardDTO noticeBoard)
        {
            var data = Convert(noticeBoard);
            return DataAccessFactory.NoticeBoardData().Update(data);
        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.NoticeBoardData();
            return data.Delete(id);
        }

        static List<NoticeBoardDTO> Convert(List<NoticeBoard> noticeBoard)
        {
            var data = new List<NoticeBoardDTO>();
            foreach (NoticeBoard i in noticeBoard)
            {
                data.Add(Convert(i));
            }
            return data;
        }

        static NoticeBoardDTO Convert(NoticeBoard noticeBoard)
        {
            return new NoticeBoardDTO()
            {
                Id = noticeBoard.Id,
                Title = noticeBoard.Title,
                Notice = noticeBoard.Notice,
                Time = noticeBoard.Time
            };
        }

        static NoticeBoard Convert(NoticeBoardDTO noticeBoard)
        {
            return new NoticeBoard()
            {
                Id = noticeBoard.Id,
                Title = noticeBoard.Title,
                Notice = noticeBoard.Notice,
                Time = noticeBoard.Time
            };
        }
    }
}
