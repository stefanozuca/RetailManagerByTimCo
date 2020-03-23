using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRMDataManager.Library.Internal;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class SaleData
    {
        private readonly IConfiguration config;

        public SaleData(IConfiguration config)
        {
            this.config = config;
        }

        public List<ProductModel> GetProducts()
        {
            SQLDataAccess sql = new SQLDataAccess(config);

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spGetAllProduct", new { }, "TRMData");

            return output;
        }

        public void SaveSale(SaleModel saleInfo, string userId)
        {
            // TODO: Make this SOLID/DRY/Btter
            // Start filling in the sale detail models we will save to the database
            List<SaleDetailDbModel> details = new List<SaleDetailDbModel>();
            ProductData product = new ProductData(config);
            var taxRate = ConfigHelper.GetTaxRate()/100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDbModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                // Get the information about this product
                var productInfo = product.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"El producto con Id { detail.ProductId } no se encuentra en la base de datos.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            // Create the sale model
            SaleDbModel sale = new SaleDbModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = userId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            // Save the sale model
            SQLDataAccess sql = new SQLDataAccess(config);
            sql.SaveData("dbo.spSale_Insert", sale, "TRMData");

            // Get the Id from the sale model
            sale.Id = sql.LoadData<int, dynamic>("dbo.spSale_Lookup", new 
            { 
                CashierId = sale.CashierId,
                SaleDate = sale.SaleDate 
            },
            "TRMData")
            .FirstOrDefault();

            // Finish filling in the sale details model
            foreach ( var item in details)
            {
                item.SaleId = sale.Id;
                // Save the sale detail model
                sql.SaveData("dbo.spSaleDetail_Insert", item, "TRMData");
            }

        }

        
    }
}
