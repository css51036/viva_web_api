using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VivaWebAPI.Models
{
    public abstract class BaseModel
    {
        public int _id { get; set; }
        public string _thai_name { get; set; }
        public string _eng_name { get; set; }
    }
}