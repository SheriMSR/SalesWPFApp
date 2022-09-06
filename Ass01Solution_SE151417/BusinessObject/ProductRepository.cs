using BusinessObject.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductList();
        Product GetProductByID(int id);
        void InsertProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

    }
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product) => ProductDAO.Instance.Remove(product);

        public IEnumerable<Product> GetProductList() => ProductDAO.Instance.GetProductList();

        public Product GetProductByID(int id) => ProductDAO.Instance.GetProductByID(id);

        public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
    }
}
