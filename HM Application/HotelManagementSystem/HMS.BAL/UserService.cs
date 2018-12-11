using HMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class UserService
    {
        public static bool CheckUser(string UserName, string Password)
        {
            bool result = false;
            using (HMSEntities dbContext = new HMSEntities())
            {
                var user = dbContext.USERS.Where(x => x.EMail == UserName && x.Password == Password).FirstOrDefault();
                if (user != null)
                {
                    result= true;                   

                }
            }
           return result;
        }


        public static string GetUserRoleByUserId(int UserId)
        {
            string userRole = string.Empty;
            //getting user role
            using (HMSEntities dbContext = new HMSEntities())
            {
                var role = dbContext.UserRoles.Where(x => x.UserId == UserId).FirstOrDefault();
                if (role != null && role.ROLE != null)
                {
                    userRole = role.ROLE.RoleName;
                }
            }
            return userRole;
        }

        public static string GetUserRoleByUserName(string UserName)
        {
            string userRole = string.Empty;
            //getting user role
            using (HMSEntities dbContext = new HMSEntities())
            {
                userRole = (from p in dbContext.USERS
                            join ur in dbContext.UserRoles on p.User_Id equals ur.UserId
                            join ro in dbContext.ROLES on ur.RoleId equals ro.Role_Id
                            where p.EMail==UserName
                            select ro.RoleName).FirstOrDefault();
            }
            return userRole;
        }
    }
    
}
