//using Agencies.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Agency.Models
//{
//    public class AgencyActivity
//    {
//        private AGENCYDB db = new AGENCYDB();

//        public void BookRoom(int? agencyId)
//        {
//            Agency room = db.Agencys.Find(agencyId);
//            if (room != null)
//            {
//                room.Status = false;
//                db.SaveChanges();
//            }
//        }
//        public void FreeRoom(int? roomId)
//        {
//            Room room = db.Rooms.Find(roomId);
//            if (room != null)
//            {
//                room.Status = true;
//                db.SaveChanges();
//            }
//        }
//    }
//}