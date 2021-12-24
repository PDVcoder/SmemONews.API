using SmemONews.BLL.StaticDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmemONews.BLL.BusinessModels
{
    public static class RoleValidator
    {
        public static bool CheckRole(string role)
        {
            if (role.Equals(RoleValue.Admin) ||
                role.Equals(RoleValue.Moderator) ||
                role.Equals(RoleValue.Author) ||
                role.Equals(RoleValue.Guest))
            {
                return true;
            }
            else return false;
        }
    }
}
