using BusinessObject.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetListOrder();
        Order GetOrderByID(int id);
        void InsertOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
    }
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order order) => OrderDAO.Instance.Remove(order);

        public IEnumerable<Order> GetListOrder() => OrderDAO.Instance.GetOrderList();

        public Order GetOrderByID(int id) => OrderDAO.Instance.GetOrderByID(id);

        public void InsertOrder(Order order) => OrderDAO.Instance.AddNew(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.Update(order);
    }
}
