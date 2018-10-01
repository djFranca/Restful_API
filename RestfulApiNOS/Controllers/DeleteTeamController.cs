using MySql.Data.MySqlClient;
using RestfulApiNOS.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulApiNOS.Controllers
{
    public class DeleteTeamController : ApiController
    {
        private readonly string ConnString;

        public DeleteTeamController() {
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/deleteteam/{value}")]
        public HttpResponseMessage Delete(string value) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "DeleteTeam";

                            command.Parameters.AddWithValue("@nome", value);
                            command.Parameters["@nome"].Direction = System.Data.ParameterDirection.Input;
                            command.ExecuteNonQuery();
                        } catch (Exception e) { Console.WriteLine(e.ToString()); }
                    }
                    Connection.Close();
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                } catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
