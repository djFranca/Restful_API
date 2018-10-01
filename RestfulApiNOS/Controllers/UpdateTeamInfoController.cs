using MySql.Data.MySqlClient;
using RestfulApiNOS.Models;
using RestfulApiNOS.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulApiNOS.Controllers
{
    public class UpdateTeamInfoController : ApiController
    {
        private readonly string ConnString;

        public UpdateTeamInfoController() {
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/updateteaminfo/{team}")]
        public HttpResponseMessage Put(string team, [FromBody] UpdateTeamInfoModel newInfoModel) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "UpdateTeamInfo";
                            command.Parameters.AddWithValue("@equipa", team);
                            command.Parameters["@equipa"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@treinador", newInfoModel.TeamCoach);
                            command.Parameters["@treinador"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@jogos", newInfoModel.TeamGames);
                            command.Parameters["@jogos"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@pontuacao", newInfoModel.TeamScore);
                            command.Parameters["@pontuacao"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters.AddWithValue("@classificacao", newInfoModel.TeamRanking);
                            command.Parameters["@classificacao"].Direction = System.Data.ParameterDirection.Input;
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
