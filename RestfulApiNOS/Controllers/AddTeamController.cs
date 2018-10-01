using MySql.Data.MySqlClient;
using RestfulApiNOS.Models;
using RestfulApiNOS.Utils;
using System.Web.Http;
using System;
using System.Net.Http;
using System.Net;

namespace RestfulApiNOS.Controllers
{
    public class AddTeamController : ApiController
    {

        private readonly string ConnString;

        public AddTeamController() {
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/addteam/")]
        public HttpResponseMessage Post([FromBody] TeamInfoModel info) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "AddTeamInfo"; 

                            command.Parameters.AddWithValue("@id", info.TeamId);
                            command.Parameters.AddWithValue("@nome", info.TeamName);
                            command.Parameters.AddWithValue("@treinador", info.TeamCoach);
                            command.Parameters.AddWithValue("@estadio", info.TeamStadium);
                            command.Parameters.AddWithValue("@posicao", info.TeamRanking);
                            command.Parameters.AddWithValue("@jogos", info.TeamGames);
                            command.Parameters.AddWithValue("@V", info.TeamWons);
                            command.Parameters.AddWithValue("@E", info.TeamDraws);
                            command.Parameters.AddWithValue("@D", info.TeamLosts);
                            command.Parameters.AddWithValue("@pontos", info.TeamScore);
                            command.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@nome"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@treinador"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@estadio"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@posicao"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@jogos"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@V"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@E"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@D"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@pontos"].Direction = System.Data.ParameterDirection.Input;
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
