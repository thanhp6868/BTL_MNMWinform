using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Services.OrdersService
{
    public interface IOrderService : IBaseService<Order>
    {
        bool setDraftOrder(Order order);
        Order getOrderAndOrderDetailById(int id);
    }
}
