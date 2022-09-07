using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public OrderDetail GetOrderDetailByOrderID(int orderID)
        {
            OrderDetail orderDetail = null;
            try
            {
                var fStoreDB = new FStoreDBContext();
                orderDetail = fStoreDB.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderId == orderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                var _orderDetail = GetOrderDetailByOrderID(orderDetail.OrderId);
                if (_orderDetail == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.OrderDetails.Add(orderDetail);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This order is already have detail.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail od = GetOrderDetailByOrderID(orderDetail.OrderId);
                if (od == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This order does not have detail, pls add new.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByOrderID(orderDetail.OrderId);
                if (_orderDetail == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.OrderDetails.Remove(_orderDetail);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This order does not have detail.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
