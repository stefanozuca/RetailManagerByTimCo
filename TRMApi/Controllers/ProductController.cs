using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration config;

        public ProductController(IConfiguration config)
        {
            this.config = config;
        }

        [Authorize(Roles = "Cashier")]
        [HttpGet]
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData(config);

            return data.GetProducts();
        }
    }
}