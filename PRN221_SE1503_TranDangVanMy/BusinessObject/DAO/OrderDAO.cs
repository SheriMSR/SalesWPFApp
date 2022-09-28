using BusinessObject.Entity;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public string msg = null;
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrderList()
        {
            List<Order> orders;
            try
            {
                var fStoreDB = new FStoreDBContext();
                orders = fStoreDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrderByID(int orderID)
        {
            Order order = null;
            try
            {
                var fStoreDB = new FStoreDBContext();
                order = fStoreDB.Orders.SingleOrDefault(order => order.OrderId == orderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public BaseResponseModel AddNew(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Orders.Add(order);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    msg = "This order is already exist.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new BaseResponseModel()
            {
                Message = msg
            };
        }

        public BaseResponseModel Update(Order order)
        {
            try
            {
                Order o = GetOrderByID(order.OrderId);
                if (o == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Entry<Order>(order).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    msg = "This order does not exist.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new BaseResponseModel()
            {
                Message = msg
            };
        }

        public BaseResponseModel Remove(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Orders.Remove(order);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    msg = "This order does not exist.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new BaseResponseModel()
            {
                Message = msg
            };
        }
    }
}

