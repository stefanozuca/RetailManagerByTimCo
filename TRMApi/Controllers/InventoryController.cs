using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IConfiguration config;

        public InventoryController(IConfiguration config)
        {
            this.config = config;
        }
        //[Authorize(Roles ="Manager,Admin")]
        //[HttpGet]
        //public List<InventoryModel> Get()
        //{
        //    InventoryData data = new InventoryData();
        //    return data.GetInventory();
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public void Post(InventoryModel item)
        //{
        //    InventoryData data = new InventoryData();
        //    data.SaveInventoryRecord();
        //}
    }
}