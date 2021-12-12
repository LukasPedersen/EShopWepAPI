using DataLayer.Models;
using DataLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EShopServiceLayer : IEShopServiceLayer
    {
        private readonly EShopContext _EShopContext;

        public EShopServiceLayer(EShopContext eShopServiceLayer)
        {
            _EShopContext = eShopServiceLayer;
        }

        #region Catagory
        public IQueryable<Catagory> GetAllCatagotys()
        {
            IQueryable<Catagory> tempCatagories = _EShopContext.Catagories;

            return tempCatagories;

        }
        public IQueryable<Catagory> GetCatagotyById(int catagoryId)
        {
            IQueryable<Catagory> tempCatagories = _EShopContext.Catagories.Where(c => c.CatagoryID == catagoryId);

            return tempCatagories;
        }


        public IQueryable<ProductCatagory> GetAllProductCatagorys()
        {
            IQueryable<ProductCatagory> tempCatagories = _EShopContext.productCatagories;
            
            return tempCatagories;
        }
        public void CreateProductCatagorys(int ProductID, int CatagoryID)
        {
            _EShopContext.productCatagories.Add(new ProductCatagory { ProductID = ProductID, CatagoryID = CatagoryID });
            _EShopContext.SaveChanges();
        }
        #endregion

        #region Products
        public void CreateProduct(Product product)
        {
            _EShopContext.Products.Add(product);

            _EShopContext.SaveChanges();
        }
        public void DeleteProductById(int productId)
        {
            Product tempProduct = _EShopContext.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            _EShopContext.Products.Remove(tempProduct);
            _EShopContext.SaveChanges();
        }
        public Product GetSingleProductBy(int id)
        {
            Product tempProduct = _EShopContext.Products
                .Where(p => p.ProductID == id)
                .FirstOrDefault();

            return tempProduct;
        }
        public Product GetSingleFullProductBy(int id)
        {
            Product tempProduct = _EShopContext.Products
                .Where(p => p.ProductID == id)
                .Include(p => p.Reviews)
                .Include(p => p.Images)
                .Include(p => p.Catagories)
                .Include(p => p.Manufacturer)
                    .ThenInclude(m => m.Info)
                .FirstOrDefault();

            return tempProduct;
        }
        public Product GetSingleProductBy(string name)
        {
            Product tempProduct = _EShopContext.Products
                .Where(p => p.ProductName == name)
                .FirstOrDefault();

            return tempProduct;
        }
        public Product GetSingleFullProductBy(string name)
        {
            Product tempProduct = _EShopContext.Products
                .Where(p => p.ProductName == name)
                .Include(p => p.Reviews)
                .Include(p => p.Images)
                .Include(p => p.Catagories)
                .Include(p => p.Manufacturer)
                    .ThenInclude(m => m.Info)
                .FirstOrDefault();

            return tempProduct;
        }
        public void UpdateProductBy(int productId, Product newProduct)
        {
            Product tempProduct = _EShopContext.Products
                .Where(p => p.ProductID == productId)
                .FirstOrDefault();
            tempProduct.ProductName = newProduct.ProductName;
            tempProduct.ProductDescription = newProduct.ProductDescription;
            tempProduct.Price = newProduct.Price;

            _EShopContext.SaveChanges();
        }
        public void UpdateProductBy(string productName, Product newProduct)
        {
            Product tempProduct = _EShopContext.Products
                .Where(p => p.ProductName == productName)
                .FirstOrDefault();
            tempProduct = newProduct;
            _EShopContext.SaveChanges();
        }
        public IQueryable<Product> GetAllProducts()
        {
            IQueryable<Product> tempProducts = _EShopContext.Products
                .Include(p => p.Images)
                .Include(p => p.Reviews)
                .Include(c => c.Catagories)
                .ThenInclude(cp => cp.Catagory);

            return tempProducts;
        }
        public IQueryable<Product> GetAllProductsPaged(int currentPage, int pageSize)
        {
            IQueryable<Product> tempProducts = _EShopContext.Products
                .Include(p => p.Images)
                .Include(p => p.Reviews)
                .Include(c => c.Catagories)
                .ThenInclude(cp => cp.Catagory);

            return tempProducts.OrderBy(p => p.ProductID).Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Product> GetAllFullProducts()
        {
            IQueryable<Product> tempProducts = _EShopContext.Products
                .Include(p => p.Reviews)
                .Include(p => p.Images)
                .Include(p => p.Catagories)
                .Include(p => p.Manufacturer)
                    .ThenInclude(m => m.Info);

            return tempProducts;
        }
        public IQueryable<Product> GetAllFullProductsPaged(int currentPage, int pageSize)
        {
            IQueryable<Product> tempProducts = _EShopContext.Products
                .Include(p => p.Reviews)
                .Include(p => p.Images)
                .Include(p => p.Catagories)
                .Include(p => p.Manufacturer)
                    .ThenInclude(m => m.Info);

            return tempProducts.OrderBy(p => p.ProductID).Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Product> FilterProductsPaged(int currentPage, int pageSize, string? SearchTerm, int? CatagoryId, string? Title, string? Price)
        {
            IQueryable<Product> tempProducts = _EShopContext.Products
                    .Include(p => p.Images)
                    .Include(p => p.Reviews)
                    .Include(c => c.Catagories)
                    .ThenInclude(cp => cp.Catagory);

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                tempProducts = tempProducts.Where(p => p.ProductName.Contains(SearchTerm));
            }

            if (CatagoryId != null && CatagoryId != 0)
            {
                IQueryable<ProductCatagory> tempProducts2 = _EShopContext.productCatagories.Where(p => p.CatagoryID == CatagoryId);
                List<Product> tempProducts3 = new List<Product>();

                foreach (ProductCatagory productCatagory in tempProducts2.ToList())
                {
                    tempProducts3.Add(tempProducts.Where(p => p.ProductID == productCatagory.ProductID).FirstOrDefault());
                }
                tempProducts = tempProducts3.AsQueryable();
            }

            if (!string.IsNullOrWhiteSpace(Title))
            {
                if (Title == "+")
                {
                    tempProducts = tempProducts.OrderBy(p => p.ProductName);
                }
                else
                {
                    tempProducts = tempProducts.OrderByDescending(p => p.ProductName);
                }
            }

            if (!string.IsNullOrWhiteSpace(Price))
            {
                if (Title == "+")
                {
                    tempProducts = tempProducts.OrderBy(p => p.Price);
                }
                else
                {
                    tempProducts = tempProducts.OrderBy(p => p.Price).Reverse();
                }
            }

            List<Product> products = tempProducts.ToList();
            products.RemoveAll(item => item == null);
            tempProducts = products.AsQueryable();

            return tempProducts.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Product> FilterProducts(string? SearchTerm, int? CatagoryId, string? Title, string? Price)
        {
            IQueryable<Product> tempProducts = _EShopContext.Products
                    .Include(p => p.Images)
                    .Include(p => p.Reviews)
                    .Include(c => c.Catagories)
                    .ThenInclude(cp => cp.Catagory);

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                tempProducts = tempProducts.Where(p => p.ProductName.Contains(SearchTerm));
            }
            if (CatagoryId != null && CatagoryId != 0)
            {
                IQueryable<ProductCatagory> tempProducts2 = _EShopContext.productCatagories.Where(p => p.CatagoryID == CatagoryId);
                List<Product> tempProducts3 = new List<Product>();

                foreach (ProductCatagory productCatagory in tempProducts2.ToList())
                {
                    tempProducts3.Add(tempProducts.Where(p => p.ProductID == productCatagory.ProductID).FirstOrDefault());
                }
                tempProducts = tempProducts3.AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(Title))
            {
                if (Title == "+")
                {
                    tempProducts = tempProducts.OrderBy(p => p.ProductName);
                }
                else
                {
                    tempProducts = tempProducts.OrderByDescending(p => p.ProductName);
                }
            }
            if (!string.IsNullOrWhiteSpace(Price))
            {
                if (Title == "+")
                {
                    tempProducts = tempProducts.OrderBy(p => p.Price);
                }
                else
                {
                    tempProducts = tempProducts.OrderByDescending(p => p.Price);
                }
            }

            return tempProducts;
        }
        public IQueryable<ProductDTO> FilterProductsSimpel(string? SearchTerm, string? Title, string? Price)
        {
            List<ProductDTO> tempProducts = new List<ProductDTO>();
            foreach (Product product in _EShopContext.Products)
            {
                tempProducts.Add(
                    new ProductDTO 
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        Price = product.Price,
                        ManufacturerID = product.ManufacturerID
                    });
            }
            IQueryable<ProductDTO> query = tempProducts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(p => p.ProductName.Contains(SearchTerm));
            }
            if (!string.IsNullOrWhiteSpace(Title))
            {
                if (Title == "+")
                {
                    query = query.OrderBy(p => p.ProductName);
                }
                else
                {
                    query = query.OrderByDescending(p => p.ProductName);
                }
            }
            if (!string.IsNullOrWhiteSpace(Price))
            {
                if (Title == "+")
                {
                    query = query.OrderBy(p => p.Price);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Price);
                }
            }

            return query;
        }
        #endregion

        #region Orders
        public void CreateOrder(Order order)
        {
            _EShopContext.Orders.Add(order);

            _EShopContext.SaveChanges();
        }
        public void CreateOrderProductDetails(List<OrderProductsDetails> orderProductsDetails)
        {
            foreach (OrderProductsDetails opd in orderProductsDetails)
            {
                _EShopContext.OrderProductsDetails.Add(opd);
            }
            _EShopContext.SaveChanges();
        }
        public void DeleteOrder(Order order)
        {
            _EShopContext.Orders.Remove(order);
            _EShopContext.SaveChanges();
        }
        public Order GetSingleOrderBy(int id)
        {
            Order tempOrder = _EShopContext.Orders
                .Where(o => o.OrderID == id)
                .FirstOrDefault();

            return tempOrder;
        }
        public Order GetSingleFullOrderBy(int id)
        {
            Order tempOrder = _EShopContext.Orders
                .Where(o => o.OrderID == id)
                .Include(o => o.OrderProductsDetails)
                .FirstOrDefault();

            return tempOrder;
        }
        public Order GetSingleOrderBy(string email)
        {
            Order tempOrder = _EShopContext.Orders
                .Where(o => o.Email == email)
                .FirstOrDefault();

            return tempOrder;
        }
        public Order GetSingleFullOrderBy(string email)
        {
            Order tempOrder = _EShopContext.Orders
                .Where(o => o.Email == email)
                .Include(o => o.OrderProductsDetails)
                .FirstOrDefault();

            return tempOrder;
        }
        public void UpdateProductBy(int orderId, Order newOrder)
        {
            Order tempOrder = _EShopContext.Orders
                .Where(o => o.OrderID == orderId)
                .FirstOrDefault();
            tempOrder = newOrder;
            _EShopContext.SaveChanges();
        }
        public void UpdateOrderBy(string orderEmail, Order newOrder)
        {
            Order tempOrder = _EShopContext.Orders
                .Where(o => o.Email == orderEmail)
                .FirstOrDefault();
            tempOrder = newOrder;
            _EShopContext.SaveChanges();
        }
        public IQueryable<Order> GetAllOrders()
        {
            IQueryable<Order> tempOrders = _EShopContext.Orders;

            return tempOrders;
        }
        public IQueryable<Order> GetAllFullOrders()
        {
            IQueryable<Order> tempOrders = _EShopContext.Orders
                .Include(o => o.OrderProductsDetails);

            return tempOrders;
        }

        #endregion

        #region Manufacturer
        public IQueryable<Manufacturer> GetManufacturerById(int manufacturerId)
        {
            IQueryable<Manufacturer> tempManufacturer = _EShopContext.Manufacturers
                .Include(i => i.Info)
                .Where(mId => mId.ManufacturerID == manufacturerId);


            return tempManufacturer;
        }
        public Manufacturer GetManufacturerByIdSimple(int manufacturerId)
        {
            Manufacturer tempManufacturer = _EShopContext.Manufacturers
                .Where(mId => mId.ManufacturerID == manufacturerId)
                .FirstOrDefault();


            return tempManufacturer;
        }
        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            return _EShopContext.Manufacturers;
        }
        public void CreateManufacture(Manufacturer manufacturer)
        {
            _EShopContext.Manufacturers.Add(manufacturer);
            _EShopContext.SaveChanges();
        }
        public void DeleteManufacture(Manufacturer manufacturer)
        {
            _EShopContext.Manufacturers.Remove(manufacturer);
            _EShopContext.SaveChanges();
        }


        #endregion

        #region Admin
        public bool LogIn(Admin admin)
        {
            Admin TempAadmin = _EShopContext.Admins
                .Where(a => a.Username == admin.Username)
                .Where(a => a.Password == admin.Password)
                .FirstOrDefault();
            if (TempAadmin != null)
            {
                TempAadmin.IsSignedIn = true;
                _EShopContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool LogOut(Admin admin)
        {
            Admin tempAadmin = _EShopContext.Admins
                .Where(a => a.Username == admin.Username)
                .FirstOrDefault();

            if (tempAadmin != null)
            {
                tempAadmin.IsSignedIn = false;
                _EShopContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsSignedIn(string username)
        {
            if (_EShopContext.Admins.Where(a => a.Username == username).Where(a => a.IsSignedIn == true).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        public bool IsAnySignedIn()
        {
            Admin admin = _EShopContext.Admins.Where(a => a.IsSignedIn == true).FirstOrDefault();
            if (admin != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Review
        public IQueryable<Review> getReviewsByProductID(int productId)
        {
            IQueryable<Review> tempReviews = _EShopContext.Reviews
                .Where(p => p.ProductId == productId);
            return tempReviews;
        }
        public void CreateReview(Review review)
        {
            _EShopContext.Reviews.Add(review);

            _EShopContext.SaveChanges();
        }
        #endregion
    }
}
