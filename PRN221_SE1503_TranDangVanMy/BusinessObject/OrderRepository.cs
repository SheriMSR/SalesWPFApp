using DataAccess.DAO;
using BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetListOrder();
        Order GetOrderByID(int id);
        BaseResponseModel InsertOrder(Order order);
        BaseResponseModel DeleteOrder(Order order);
        BaseResponseModel UpdateOrder(Order order);
    }
    public class OrderRepository : IOrderRepository
    {
        public BaseResponseModel DeleteOrder(Order order) => OrderDAO.Instance.Remove(order);

        public IEnumerable<Order> GetListOrder() => OrderDAO.Instance.GetOrderList();

        public Order GetOrderByID(int id) => OrderDAO.Instance.GetOrderByID(id);

        public BaseResponseModel InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);

        public BaseResponseModel UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
    }
}
