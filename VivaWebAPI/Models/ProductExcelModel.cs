using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VivaWebAPI.Models
{
    public class ProductExcelModel
    {
        public string _productName { get; set; }
        public string _value { get; set; }
        public string _package { get; set; }
        public string _origin { get; set; }
        public string _category_Id { get; set; }
        public string _subCategory_Id { get; set; }
        public string _product_Id { get; set; }
    }
}