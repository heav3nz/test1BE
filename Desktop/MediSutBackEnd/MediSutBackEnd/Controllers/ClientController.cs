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
    [RoutePrefix("Client")]
    public class ClientController : ApplicationController
    {
        // GET: api/Client
        public HttpResponseMessage Get()
        {
            Connection.Open();
            using (SqlCommand cmd = new SqlCommand("SP_CLIENT_GET", Connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        List<Client> clients = new List<Client>();
                        while (reader.Read())
                        {
                            clients.Add(new Client()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Representative = reader.GetString(2)
                            });
                        }
                        Connection.Close();
                        return new HttpResponseMessage(OK) { Content = new StringContent(JsonConvert.SerializeObject(clients)) };
                    }
                    else
                    {
                        Connection.Close();
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }
                }
            }
        }

        // GET: api/Client/5
        public HttpResponseMessage Get(int id)
        {
            Connection.Open();
            using (SqlCommand cmd = new SqlCommand("SP_CLIENT_GET", Connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Client client = new Client();
                        while (reader.Read())
                        {
                            client.Id = reader.GetInt32(0);
                            client.Name = reader.GetString(1);
                            client.Representative = reader.GetString(2);
                        }
                        Connection.Close();
                        return new HttpResponseMessage(OK) { Content = new StringContent(JsonConvert.SerializeObject(client)) };
                    }
                    else
                    {
                        Connection.Close();
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }
                }
            }
        }

        // POST: api/Client
        public void Post([FromBody]Client client)
        {
            Connection.Open();
            using (SqlCommand cmd = new SqlCommand("SP_CLIENT_CREATE", Connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", client.Name);
                cmd.Parameters.AddWithValue("@Representative", client.Representative);
                cmd.ExecuteNonQuery();
            }
            Connection.Close();
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
