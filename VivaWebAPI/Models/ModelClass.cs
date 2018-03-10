using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VivaWebAPI.Models
{
    [JsonObject(Title = "category")]
    public  class Category : BaseModel
    {
      
        public IList<SubCategory> _subCategory { get; set; }
        public IList<Product> _product { get; set; }
    }

    public class SubCategory : BaseModel
    {

    }

    public class Product : BaseModel
    {
        public string _package { get; set; }
        public string _volume { get; set; }
        public string _origin { get; set; }
        public string _category_id { get; set; }
        public string _sub_Category_id { get; set; }
    }
}