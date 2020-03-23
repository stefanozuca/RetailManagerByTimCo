using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration config;

        public SaleController(IConfiguration config)
        {
            this.config = config;
        }

        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel item)
        {
            SaleData data = new SaleData(config);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            data.SaveSale(item, userId);
        }

        //[Authorize(Roles = "Admin,Manager")]
        //[Route("GetSalesReport")]
        //public List<SaleReportModel> GetSaleReport()
        //{
        //    SaleData data = new SaleData();
        //    return data.GetSaleReport();
        //}
    }
}