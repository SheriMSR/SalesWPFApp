using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        public static readonly object instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories;
            try
            {
                var fstoreDB = new FStoreDBContext();
                categories = fstoreDB.Categories.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public Category GetCategoryByID(int categoryID)
        {
            Category category = null;
            try
            {
                var fStoreDB = new FStoreDBContext();
                category = fStoreDB.Categories.SingleOrDefault(category => category.CategoryId == categoryID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public void AddNew(Category category)
        {
            try
            {
                Category _category = GetCategoryByID(category.CategoryId);
                if (_category == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Categories.Add(category);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Category is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Category category)
        {
            try
            {
                Category c = GetCategoryByID(category.CategoryId);
                if (c != null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Entry<Category>(category).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Category does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Category category)
        {
            try
            {
                Category c = GetCategoryByID(category.CategoryId);
                if (c != null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Categories.Remove(category);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Category does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
