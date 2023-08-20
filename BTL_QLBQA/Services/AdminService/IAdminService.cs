using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Services.AdminService
{
    public interface IAdminService : IBaseService<Admin>
    {
        Admin CheckLogin(string userName, string passWord);
    }
}
