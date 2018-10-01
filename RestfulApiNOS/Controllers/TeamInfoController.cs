using MySql.Data.MySqlClient;
using RestfulApiNOS.Models;
using RestfulApiNOS.Utils;
using System;
using System.Web.Http;

namespace RestfulApiNOS.Controllers
{
    public class TeamInfoController : ApiController
    {
        private TeamInfoModel InfoModel;
        private readonly string ConnString;

        public TeamInfoController() {
            InfoModel = null;
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/teaminfo/{team}")]
        public TeamInfoModel Get(string team) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "GetTeamInfo";

                            command.Parameters.AddWithValue("@nome", team);
                            command.Parameters["@nome"].Direction = System.Data.ParameterDirection.Input;
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read()) {
                                InfoModel = new TeamInfoModel {
                                    TeamId = reader.GetInt16("Id"),
                                    TeamName = reader.GetString("Nome"),
                                    TeamCoach = reader.GetString("Treinador"),
                                    TeamStadium = reader.GetString("Estadio"),
                                    TeamGames = reader.GetInt16("Jogos"),
                                    TeamWons = reader.GetInt16("V"),
                                    TeamDraws = reader.GetInt16("E"),
                                    TeamLosts = reader.GetInt16("D"),
                                    TeamRanking = reader.GetInt16("Posicao"),
                                    TeamScore = reader.GetInt16("Pontos")
                                };
                            }
                            Connection.Close(); //Close connection with the database;
                            Console.WriteLine("Modelo obtido com sucesso");
                            return InfoModel;
                        } catch (MySqlException e) { Console.WriteLine(e.ToString()); }
                    }
                } catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
            return null;
        }
    }
}
