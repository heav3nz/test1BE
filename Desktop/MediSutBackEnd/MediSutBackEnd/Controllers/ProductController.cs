using MediSutBackEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Net.HttpStatusCode;

namespace MediSutBackEnd.Controllers
{
    //[RoutePrefix("Product")]
    public class ProductController : ApplicationController
    {
        //GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        [HttpGet]
        [Route("api/Product/PerMonth")]
        public HttpResponseMessage PerMonth(string month)
        {
            Connection.Open();
            using (SqlCommand cmd = new SqlCommand("SP_DISCOUNT_PERMOUNTH", Connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MONTH", month);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        List<Discount> discounts = new List<Discount>();
                        while (reader.Read())
                        {
                            discounts.Add(new Discount()
                            {
                                Id = reader.GetInt32(0),
                                IdClient = reader.GetInt32(1),
                                IdProduct = reader.GetInt32(2),
                                DiscountRate = reader.GetDecimal(3),
                                DiscountDate = reader.GetDateTime(4)
                            });
                        }
                        Connection.Close();
                        return new HttpResponseMessage(OK) { Content = new StringContent(JsonConvert.SerializeObject(discounts)) };
                    }
                    else
                    {
                        Connection.Close();
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }
                }
            }
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
