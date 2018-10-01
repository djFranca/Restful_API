using MySql.Data.MySqlClient;
using RestfulApiNOS.Models;
using RestfulApiNOS.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulApiNOS.Controllers
{
    public class AddTeamPlayersController : ApiController
    {
        private readonly string ConnString;

        public AddTeamPlayersController() {
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/addteamplayers/")]
        public HttpResponseMessage Post([FromBody] List<EspecificTeamModel> players) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            int player = 0;
                            while (player < players.Count) {
                                command.CommandType = System.Data.CommandType.StoredProcedure;
                                command.CommandText = "AddTeamPlayers";
                                command.Parameters.AddWithValue("@id", players[player].Id);
                                command.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                                command.Parameters.AddWithValue("@jogador", players[player].Player);
                                command.Parameters["@jogador"].Direction = System.Data.ParameterDirection.Input;
                                command.Parameters.AddWithValue("@idade", players[player].Age);
                                command.Parameters["@idade"].Direction = System.Data.ParameterDirection.Input;
                                command.Parameters.AddWithValue("@nacionalidade", players[player].Country);
                                command.Parameters["@nacionalidade"].Direction = System.Data.ParameterDirection.Input;
                                command.Parameters.AddWithValue("@posicao", players[player].Position);
                                command.Parameters["@posicao"].Direction = System.Data.ParameterDirection.Input;
                                player++;
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                            }
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
