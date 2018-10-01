using MySql.Data.MySqlClient;
using RestfulApiNOS.Models;
using RestfulApiNOS.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulApiNOS.Controllers
{
    public class UpdateTeamMatchesController : ApiController
    {
        private readonly string ConnString;

        public UpdateTeamMatchesController() {
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/updateteammatches/{team}")]
        public HttpResponseMessage Put(string team, [FromBody]UpdateTeamMatchesModel matches) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "UpdateTeamMatches";
                            command.Parameters.AddWithValue("@equipa", team);
                            command.Parameters["@equipa"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@V", matches.TeamWons);
                            command.Parameters["@V"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@E", matches.TeamDraws);
                            command.Parameters["@E"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@D", matches.TeamLosts);
                            command.Parameters["@D"].Direction = System.Data.ParameterDirection.Input;
                            command.ExecuteNonQuery();
                        } catch (MySqlException e) { Console.WriteLine(e.ToString()); }
                    }
                    Connection.Close();
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                } catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
