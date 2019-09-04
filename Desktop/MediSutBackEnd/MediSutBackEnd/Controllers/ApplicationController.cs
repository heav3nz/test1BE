using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediSutBackEnd.Controllers
{
    public class ApplicationController : ApiController
    {
        private readonly string ConnectionString;

        protected readonly SqlConnection Connection;

        public ApplicationController()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
        }
    }
}
