using SmemONews.BLL.StaticDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmemONews.BLL.BusinessModels
{
    public static class StatusValidator
    {
        public static bool CheckStatus(string status)
        {
            if (status.Equals(StatusValue.Ok) ||
                status.Equals(StatusValue.App) ||
                status.Equals(StatusValue.Ban) ||
                status.Equals(StatusValue.Rejected))
            {
                return true;
            }
            else return false;
        }
    }
}
