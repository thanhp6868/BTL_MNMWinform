using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System.Linq;

namespace BTL_QLBQA.Services.AdminService
{
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService() : base()
        {
        }
        public Admin CheckLogin(string userName, string passWord)
        {
            return base.dbContext.Admins.FirstOrDefault(u => u.Username == userName && u.Password == passWord);
        }
    }
}
