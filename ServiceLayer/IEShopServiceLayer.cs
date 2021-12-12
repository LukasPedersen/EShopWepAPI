using DataLayer.Models;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IEShopServiceLayer
    {
        #region Catagory
        /// <summary>
        /// Gets all <see cref="Catagory"/>'s from <see langword="Database"/>
        /// </summary>
        /// <returns>A <see cref="IQueryable{Catagory}"/> of <see cref="Catagory"/>'s</returns>
        public IQueryable<Catagory> GetAllCatagotys();
        public IQueryable<Catagory> GetCatagotyById(int catagoryId);

        public IQueryable<ProductCatagory> GetAllProductCatagorys();
        public void CreateProductCatagorys(int ProductID, int CatagoryID);
        #endregion

        #region Products
        /// <summary>
        /// Will use the given <paramref name="product"/> to save it to the <see langword="Database"/>
        /// </summary>
        /// <param name="product"></param>
        /// <returns><see langword="true"/> if product was created, else return <see langword="false"/></returns>
        public void CreateProduct(Product product);

        /// <summary>
        /// Will use the given <paramref name="product"/>' delete it from the <see langword="Database"/>
        /// </summary>
        /// <param name="product"></param>
        /// <returns><see langword="true"/> if Product was deleted, else return <see langword="false"/></returns>
        public void DeleteProductById(int productId);

        /// <summary>
        /// Get a <see cref="Product"/> by <c>ID</c>, from <see langword="Database"/> that matches <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FirstOrDefault <seealso cref="Product"/> that matches <paramref name="id"/></returns>
        public Product GetSingleProductBy(int id);

        /// <summary>
        /// Get a <see cref="Product"/> with <see cref="Review"/>, <see cref="Image"/>, <see cref="Catagory"/>, <see cref="Manufacturer"/>, <see cref="Manufacturer.Info"/> by <c>ID</c>, from <see langword="Database"/> that matches <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FirstOrDefault <seealso cref="Product"/> that matches <paramref name="id"/></returns>
        public Product GetSingleFullProductBy(int id);

        /// <summary>
        /// Get a <see cref="Product"/> by <c>NAME</c>, from <see langword="Database"/> that matches <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>FirstOrDefault <seealso cref="Product"/> that matches <paramref name="name"/></returns>
        public Product GetSingleProductBy(string name);

        /// /// <summary>
        /// Get a <see cref="Product"/> with <see cref="Review"/>, <see cref="Image"/>, <see cref="Catagory"/>, <see cref="Manufacturer"/>, <see cref="Manufacturer.Info"/> by <c>NAME</c>, from <see langword="Database"/> that matches <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>FirstOrDefault <seealso cref="Product"/> that matches <paramref name="name"/></returns>
        public Product GetSingleFullProductBy(string name);

        /// <summary>
        /// Find <see cref="Product"/> by <paramref name="productId"/> in <see langword="Database"/> and apply new infomation from <paramref name="newProduct"/>
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="newProduct"></param>
        /// <returns><see langword="true"/> if <see cref="Product"/> was updated, else return <see langword="false"/></returns>
        public void UpdateProductBy(int productId, Product newProduct);

        /// <summary>
        /// Find <see cref="Product"/> by <paramref name="productName"/> in <see langword="Database"/> and apply new infomation from <paramref name="newProduct"/>
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="newProduct"></param>
        /// <returns><see langword="true"/> if <see cref="Product"/> was updated, else return <see langword="false"/></returns>
        public void UpdateProductBy(string productName, Product newProduct);

        /// <summary>
        /// Gets all <see cref="Product"/>'s from <see langword="Database"/>
        /// </summary>
        /// <returns>A <see cref="IQueryable{Product}"/> of <see cref="Product"/>'s</returns>
        public IQueryable<Product> GetAllProducts();

        /// <summary>
        /// Gets all <see cref="Product"/>'s with <see cref="Review"/>, <see cref="Image"/>, <see cref="Catagory"/>, <see cref="Manufacturer"/>, <see cref="Manufacturer"/>.<see cref="Info"/> from <see langword="Database"/>
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>A <see cref="IQueryable{Product}"/> of <see cref="Product"/>'s</returns>
        public IQueryable<Product> GetAllProductsPaged(int currentPage, int pageSize);

        /// <summary>
        /// Gets all <see cref="Product"/>'s with <see cref="Review"/>, <see cref="Image"/>, <see cref="Catagory"/>, <see cref="Manufacturer"/>, <see cref="Manufacturer"/>.<see cref="Info"/> from <see langword="Database"/>
        /// </summary>
        /// <returns>A <see cref="IQueryable{Product}"/> of <see cref="Product"/>'s</returns>
        public IQueryable<Product> GetAllFullProducts();

        /// <summary>
        /// Gets all <see cref="Product"/>'s with <see cref="Review"/>, <see cref="Image"/>, <see cref="Catagory"/>, <see cref="Manufacturer"/>, <see cref="Manufacturer.Info"/> from <see langword="Database"/>
        /// And return a collection <see cref="IQueryable{Product}"/> in a paged format
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns>A collection of <see cref="IQueryable{Product}"/> in a paged format</returns>
        public IQueryable<Product> GetAllFullProductsPaged(int currentPage, int pageSize);

        /// <summary>
        /// Will filter from all <see cref="Product"/>'s in the <see langword="DataBase"/> where <see cref="Product"/>'s matches <paramref name="SearchTerm"/>, <paramref name="CatagoryName"/>, <paramref name="Title"/>, <paramref name="Price"/>
        /// And return a collection <see cref="IQueryable{Product}"/> in a paged format
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="SearchTerm"></param>
        /// <param name="CatagoryName"></param>
        /// <param name="Title"></param>
        /// <param name="Price"></param>
        /// <returns>A collection of <see cref="IQueryable{Product}"/> in a paged format</returns>
        public IQueryable<Product> FilterProductsPaged(int currentPage, int pageSize, string? SearchTerm, int? CatagoryId, string? Title, string? Price);

        /// <summary>
        /// Will filter from all <see cref="Product"/>'s in the <see langword="DataBase"/> where <see cref="Product"/>'s matches <paramref name="SearchTerm"/>, <paramref name="CatagoryName"/>, <paramref name="Title"/>, <paramref name="Price"/>
        /// And return a collection <see cref="IQueryable{Product}"/>
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <param name="CatagoryName"></param>
        /// <param name="Title"></param>
        /// <param name="Price"></param>
        /// <returns>A collection of <see cref="IQueryable{Product}"/></returns>
        public IQueryable<Product> FilterProducts(string? SearchTerm, int? CatagoryId, string? Title, string? Price);

        /// <summary>
        /// Will filter from all <see cref="Product"/>'s in the <see langword="DataBase"/> where <see cref="Product"/>'s matches <paramref name="SearchTerm"/>, <paramref name="CatagoryName"/>, <paramref name="Title"/>, <paramref name="Price"/>
        /// And return a collection <see cref="IQueryable{Product}"/>
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <param name="CatagoryName"></param>
        /// <param name="Title"></param>
        /// <param name="Price"></param>
        /// <returns>A collection of <see cref="IQueryable{Product}"/></returns>
        public IQueryable<ProductDTO> FilterProductsSimpel(string? SearchTerm, string? Title, string? Price);
        #endregion

        #region Orders
        /// <summary>
        /// Will use the given <paramref name="order"/> to save it to the <see langword="Database"/>
        /// </summary>
        /// <param name="order"></param>
        /// <returns><see langword="true"/> if <see cref="Order"/> was created, else return <see langword="false"/></returns>
        public void CreateOrder(Order order);
        public void CreateOrderProductDetails(List<OrderProductsDetails> orderProductsDetails);

        /// <summary>
        /// Will use the given <paramref name="order"/>' delete it from the <see langword="Database"/>
        /// </summary>
        /// <param name="order"></param>
        /// <returns><see langword="true"/> if <see cref="Order"/> was deleted, else return <see langword="false"/></returns>
        public void DeleteOrder(Order order);

        /// <summary>
        /// Get a <see cref="Order"/> by <c>ID</c>, from <see langword="Database"/> that matches <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FirstOrDefault <seealso cref="Order"/> that matches <paramref name="id"/></returns>
        public Order GetSingleOrderBy(int id);

        /// <summary>
        /// Get a <see cref="Order"/> with <see cref="OrderProductsDetails"/> by <c>ID</c>, from <see langword="Database"/> that matches <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FirstOrDefault <seealso cref="Order"/> that matches <paramref name="id"/></returns>
        public Order GetSingleFullOrderBy(int id);

        /// <summary>
        /// Get a <see cref="Order"/> by <c>Email</c>, from <see langword="Database"/> that matches <paramref name="email"/>
        /// </summary>
        /// <param name="email"></param>
        /// <returns>FirstOrDefault <seealso cref="Order"/> that matches <paramref name="email"/></returns>
        public Order GetSingleOrderBy(string email);

        /// <summary>
        /// Get a <see cref="Order"/> with <see cref="OrderProductsDetails"/> by <c>Email</c>, from <see langword="Database"/> that matches <paramref name="email"/>
        /// </summary>
        /// <param name="email"></param>
        /// <returns>FirstOrDefault <seealso cref="Order"/> that matches <paramref name="email"/></returns>
        public Order GetSingleFullOrderBy(string email);

        /// <summary>
        /// Find <see cref="Order"/> by <paramref name="orderId"/> in <see langword="Database"/> and apply new infomation from <paramref name="newOrder"/>
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newOrder"></param>
        /// <returns><see langword="true"/> if <see cref="Order"/> was updated, else return <see langword="false"/></returns>
        public void UpdateProductBy(int orderId, Order newOrder);

        /// <summary>
        /// Find <see cref="Order"/> by <paramref name="orderEmail"/> in <see langword="Database"/> and apply new infomation from <paramref name="newOrder"/>
        /// </summary>
        /// <param name="orderEmail"></param>
        /// <param name="newOrder"></param>
        /// <returns><see langword="true"/> if <see cref="Order"/> was updated, else return <see langword="false"/></returns>
        public void UpdateOrderBy(string orderEmail, Order newOrder);

        /// <summary>
        /// Gets all <see cref="Order"/>'s from <see langword="Database"/>
        /// </summary>
        /// <returns>A <see cref="List{Order}"/> of <see cref="Order"/>'s</returns>
        public IQueryable<Order> GetAllOrders();

        /// <summary>
        /// Gets all <see cref="Order"/>'s with <see cref="OrderProductsDetails"/> from <see langword="Database"/>
        /// </summary>
        /// <returns>A <see cref="List{Order}"/> of <see cref="Order"/>'s</returns>
        public IQueryable<Order> GetAllFullOrders();
        #endregion

        #region Manufacturer
        /// <summary>
        /// Gets a single <see cref="Manufacturer"/> from <see langword="Database"/>
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns>A <see cref="IQueryable{Manufacturer}"/> of <see cref="Manufacturer"/></returns>
        public IQueryable<Manufacturer> GetManufacturerById(int manufacturerId);
        public Manufacturer GetManufacturerByIdSimple(int manufacturerId);
        public IQueryable<Manufacturer> GetAllManufacturers();
        public void CreateManufacture(Manufacturer manufacturer);
        public void DeleteManufacture(Manufacturer manufacturer);
        #endregion

        #region Admin
        public bool LogIn(Admin admin);
        public bool LogOut(Admin admin);
        public bool IsSignedIn(string username);
        public bool IsAnySignedIn();
        #endregion

        #region Review
        /// <summary>
        /// Gets all <see cref="Review"/>'s from <see langword="Database"/>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>A <see cref="IQueryable{Review}"/> of <see cref="Review"/>'s</returns>
        public IQueryable<Review> getReviewsByProductID(int productId);
        /// <summary>
        /// Saves a <see cref="Review"/> to the <see langword="Database"/>
        /// </summary>
        /// <param name="review"></param>
        public void CreateReview(Review review);
        #endregion
    }
}
