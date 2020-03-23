using System;
using System.Collections.Generic;
using System.Text;
using TRMDataManager.Library.Internal;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SQLDataAccess sql = new SQLDataAccess();

            var p = new { Id = id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookUp", p, "TRMData");
       
            return output;
        }
}
}
