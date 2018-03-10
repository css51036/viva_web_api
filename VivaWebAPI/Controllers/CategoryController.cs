using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VivaWebAPI.Services;
using Newtonsoft.Json;
using System.Text;

namespace VivaWebAPI.Controllers
{

    public class CategoryController : ApiController
    {
        // GET: api/Category
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       

        //public HttpResponseMessage Get(int id)
        //{
        //    ProductService _service = new ProductService();
        //    var Result = _service.GetCategoryAsync(id);

        //    string Json = JsonConvert.SerializeObject(new
        //    {
        //        data = Result
        //    }, Formatting.None
        //                                            );

        //    if (!string.IsNullOrEmpty(Json))
        //    {
        //        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //        response.Content = new StringContent(Json, Encoding.UTF8, "application/json");
        //        return response;
        //    }
        //    throw new HttpResponseException(HttpStatusCode.NotFound);
        //}
        public HttpResponseMessage Get(int id)
        {
            ProductService _service = new ProductService();
            var Result = _service.GetListCategory(id);

            

            //string Json = JsonConvert.SerializeObject(new
            //{
            //    data = Result
            //}, Formatting.None
            //                                        );

            string Json = JsonConvert.SerializeObject(Result, Formatting.None);
            


            if (!string.IsNullOrEmpty(Json))
            {
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(Json, Encoding.UTF8, "application/json");
                return response;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }


    }
}
