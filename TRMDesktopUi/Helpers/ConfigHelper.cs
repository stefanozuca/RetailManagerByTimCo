using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TRMDesktopUi.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            var canOutput = Decimal.TryParse(rateText, out decimal output);

            if (!canOutput)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up property");
            }

            return output;
        }
    }
}
