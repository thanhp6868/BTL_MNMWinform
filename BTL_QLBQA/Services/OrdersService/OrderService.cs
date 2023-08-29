using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Services.OrdersService
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public Order getOrderAndOrderDetailById(int id)
        {
            return GetAll().Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
        }

        public bool setDraftOrder(Order order)
        {
            order.Status = ConstLib.EnumOrder.Draft;
            if(order.Id > 0)
                Update(order);
            else
                Insert(order);
            return true;
        }
    }
}
