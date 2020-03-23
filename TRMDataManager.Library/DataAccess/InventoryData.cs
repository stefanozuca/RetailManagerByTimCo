using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TRMDataManager.Library.Internal;

namespace TRMDataManager.Library.DataAccess
{
    public class InventoryData
    {
        private readonly IConfiguration config;

        public InventoryData(IConfiguration config)
        {
            this.config = config;
        }

        //public List<InventoryModel> GetInventory()
        //{
        //    SqlDataAccess sql = new SqlDataAccess(_config);

        //    var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "TRMData");

        //    return output;
        //}

        //public void SaveInventoryRecord(InventoryModel item)
        //{
        //    SqlDataAccess sql = new SqlDataAccess(_config);

        //    sql.SaveData("dbo.spInventory_Insert", item, "TRMData");
        //}
    }
}
