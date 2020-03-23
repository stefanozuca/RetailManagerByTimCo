using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TRMDesktopUI.Library.Models
{
    [DebuggerDisplay("{ProductName, nq}")]
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxable { get; set; }
    }
}
