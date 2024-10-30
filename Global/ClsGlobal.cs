using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyDVLD_Project
{
    public class ClsGlobal
    {

        public static string CurrentUserName { get; set; }


        public static int PersonID { get; set; }
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public static bool IsActive { get; set; }


        public static ClsUserBusiness _CurrentUser; 



        public static void AssignCurrentUserData()
        {

            _CurrentUser = ClsUserBusiness.FindByUserName(CurrentUserName);

            if (_CurrentUser != null)
            {
                UserID = _CurrentUser.UserID;
                PersonID = _CurrentUser.PersonID;
                UserName = _CurrentUser.UserName;
                Password = _CurrentUser.Password;
                IsActive = _CurrentUser.IsActive;
            }
        }


    }
}
