using Agencies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agencies.Models
{
    public class GuestActivity
    {
        private AGENCYDB db = new AGENCYDB();
        public int GetGuestId(string userName)
        {
            int guestId = db.Guests.SingleOrDefault(u => u.UserName == userName).GuestId; 
            return guestId;
        }
        public int CreateApp(string userName)
        {
            int id = 0;
            Guest guest = new Guest();
            guest.UserName = " ";
            guest.FirstName = userName;
            guest.LastName = " ";
            guest.Location = " ";
            guest.MobileNo = " ";

            guest.TetiaryInstitutionAttended = "";
            guest.DateOfBirth = "";
            guest.Address = "";


            //guest.Religion = "";
            guest.Quallification = "";
            //guest.MaritalStatus = "";
            //guest.Applicant_StateOfOrigin = "";
            //guest.Gender = "Male,Female";



            db.Guests.Add(guest);
            db.SaveChanges();
            id = GetGuestId(userName);
            return id;
        }
        public Guest GetGuest(string userName)
        {
            GuestActivity guestActivity = new GuestActivity();
            int id = guestActivity.GetGuestId(userName);
            Guest guest = db.Guests.Find(id);
            return guest;
        }
    }
}