using DataLayer.Models;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFunitureShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EShopWebAPI_Products : ControllerBase
    {
        public EShopWebAPI_Products(IEShopServiceLayer eShopServiceLayer)
        {
            _eShopServiceLayer = eShopServiceLayer;
        }
        private readonly IEShopServiceLayer _eShopServiceLayer;

        #region Products
        [HttpGet]
        [Route("GetProductByID")]
        public Product Get(int id)
        {
            return _eShopServiceLayer.GetSingleProductBy(id);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public void PostCreateProduct(Product product)
        {
            _eShopServiceLayer.CreateProduct(product);
        }

        [HttpPost]
        [Route("UpdateProductByID")]
        public void UpdateProductBy(int idOfOldProduct, Product product)
        {
            _eShopServiceLayer.UpdateProductBy(idOfOldProduct, product);
        }

        [HttpDelete]
        [Route("DeleteProductById")]
        public void DeleteProductById(int id)
        {
            _eShopServiceLayer.DeleteProductById(id);
        }

        [HttpGet]
        [Route("FilterProductsSimpel")]
        public IActionResult FilterProductsSimpel(string? SearchTerm, string? Title, string? Price)
        {
            return Ok( _eShopServiceLayer.FilterProductsSimpel(SearchTerm, Title, Price).ToArray());
        }
        #endregion
    }

    [ApiController]
    [Route("[controller]")]
    public class EShopWebAPI_Orders : ControllerBase
    {
        public EShopWebAPI_Orders(IEShopServiceLayer eShopServiceLayer)
        {
            _eShopServiceLayer = eShopServiceLayer;
        }
        private readonly IEShopServiceLayer _eShopServiceLayer;

        #region Orders
        [HttpPost]
        [Route("CreateOrder")]
        public void CreateOrder(Order order)
        {
            _eShopServiceLayer.CreateOrder(order);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public void DeleteOrder(Order order)
        {
            _eShopServiceLayer.DeleteOrder(order);
        }

        [HttpGet]
        [Route("GetSingleOrderByID")]
        public Order GetSingleOrderByID(int id)
        {
            return _eShopServiceLayer.GetSingleOrderBy(id);
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public List<Order> GetAllOrders()
        {
            return _eShopServiceLayer.GetAllOrders().ToList();
        }
        #endregion
    }

    [ApiController]
    [Route("[controller]")]
    public class EShopWebAPI_Manufactures : ControllerBase
    {
        public EShopWebAPI_Manufactures(IEShopServiceLayer eShopServiceLayer)
        {
            _eShopServiceLayer = eShopServiceLayer;
        }
        private readonly IEShopServiceLayer _eShopServiceLayer;

        [HttpPost]
        [Route("CreateManufacture")]
        public void CreateManufacture(Manufacturer manufacturer)
        {
            _eShopServiceLayer.CreateManufacture(manufacturer);
        }

        [HttpDelete]
        [Route("DeleteManufacture")]
        public void DeleteManufacture(Manufacturer manufacturer)
        {
            _eShopServiceLayer.DeleteManufacture(manufacturer);
        }

        [HttpGet]
        [Route("GetManufacturerById")]
        public Manufacturer GetManufacturerById(int id)
        {
            return _eShopServiceLayer.GetManufacturerByIdSimple(id);
        }

        [HttpGet]
        [Route("GetAllManufacturers")]
        public List<Manufacturer> GetAllManufacturers()
        {
            return _eShopServiceLayer.GetAllManufacturers().ToList();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class EShopWebAPI_Catagorys : ControllerBase
    {
        public EShopWebAPI_Catagorys(IEShopServiceLayer eShopServiceLayer)
        {
            _eShopServiceLayer = eShopServiceLayer;
        }
        private readonly IEShopServiceLayer _eShopServiceLayer;

        [HttpGet]
        [Route("GetAllCatagotys")]
        public IQueryable<Catagory> GetAllCatagotys()
        {
            IQueryable<Catagory> tempCatagories = _eShopServiceLayer.GetAllCatagotys();

            return tempCatagories;

        }

        [HttpGet]
        [Route("GetCatagotyById")]
        public Catagory GetCatagotyById(int catagoryId)
        {
            Catagory tempCatagory = _eShopServiceLayer.GetAllCatagotys().Where(c => c.CatagoryID == catagoryId).FirstOrDefault();

            return tempCatagory;
        }

        [HttpGet]
        [Route("GetAllProductCatagorys")]
        public IQueryable<ProductCatagory> GetAllProductCatagorys()
        {
            IQueryable<ProductCatagory> tempCatagories = _eShopServiceLayer.GetAllProductCatagorys();

            return tempCatagories;
        }

        [HttpPost]
        [Route("CreateProductCatagorys")]
        public void CreateProductCatagorys(int ProductID, int CatagoryID)
        {
            _eShopServiceLayer.CreateProductCatagorys(ProductID, CatagoryID);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class EShopWebAPI_AdminLogin : ControllerBase
    {
        public EShopWebAPI_AdminLogin(IEShopServiceLayer eShopServiceLayer)
        {
            _eShopServiceLayer = eShopServiceLayer;
        }
        private readonly IEShopServiceLayer _eShopServiceLayer;

        [HttpPost]
        [Route("LogIn")]
        public bool LogIn(Admin admin)
        {
             return _eShopServiceLayer.LogIn(admin);
        }

        [HttpDelete]
        [Route("LogOut")]
        public bool LogOut(Admin admin)
        {
            return _eShopServiceLayer.LogOut(admin);
        }

        [HttpGet]
        [Route("IsSignedIn")]
        public bool IsSignedIn(string username)
        {
            return _eShopServiceLayer.IsSignedIn(username);
        }

        [HttpGet]
        [Route("IsAnySignedIn")]
        public bool IsAnySignedIn()
        {
            return _eShopServiceLayer.IsAnySignedIn();
        }
    }
}
