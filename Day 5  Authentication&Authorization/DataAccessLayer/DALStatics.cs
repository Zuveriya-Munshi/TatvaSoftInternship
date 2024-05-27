using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALStatics
    {
        public static List<UserInfo> Users = new List<UserInfo>()
        {
            new UserInfo()
            {
                Username = "admin",
                EmailAddress = "admin@gmail.com",
                Password = "admin",
                GivenName = "Admin",
                Surname = "admin",
                Role = "Administrator"
            },

            new UserInfo()
            {
                Username = "zuveriya",
                EmailAddress = "zuveriya@gmail.com",
                Password = "zuveriya",
                GivenName = "Zuveriya",
                Surname = "Munshi",
                Role = "BookUser"
            },
        };
    }
}
