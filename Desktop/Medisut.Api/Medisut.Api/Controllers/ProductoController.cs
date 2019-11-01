using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Medisut.Repository;
using Newtonsoft.Json;
using System.Text;
using Medisut.DomainClass;

namespace Medisut.Api.Controllers
{
    public class ProductoController : ApiController
    {
        ERepository repo = new ERepository(System.Configuration.ConfigurationManager.ConnectionStrings["MedisutDB"].ConnectionString);
        HttpRequestMessage response = new HttpRequestMessage();

        public string Get()
        {
            return JsonConvert.SerializeObject(repo.Get());
        }

        public string Get(int id)
        {
            return JsonConvert.SerializeObject(repo.Get(id));
        }

        public string Get(string date)
        {
            return "value date";
        }

        public string Post([FromBody]Producto item)
        {
            return JsonConvert.SerializeObject(repo.Post(item));
        }

        public string Put([FromBody]Producto item)
        {
            return JsonConvert.SerializeObject(repo.Put(item));
        }

        public string Delete(int id)
        {
            return JsonConvert.SerializeObject(repo.Delete(id));
        }
    }
}
