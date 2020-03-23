using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRMDataManager.Library.Internal;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        private readonly IConfiguration config;

        public ProductData(IConfiguration config)
        {
            this.config = config;
        }

        public List<ProductModel> GetProducts()
        {
            SQLDataAccess sql = new SQLDataAccess(config);

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spGetAllProduct", new { }, "TRMData");

            return output;
        }
        
        public ProductModel GetProductById(int productId)
        {
            SQLDataAccess sql = new SQLDataAccess(config);

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "TRMData").FirstOrDefault();

            return output;
        }
    }
}
