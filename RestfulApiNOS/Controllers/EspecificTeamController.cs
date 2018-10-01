using MySql.Data.MySqlClient;
using RestfulApiNOS.Models;
using RestfulApiNOS.Utils;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RestfulApiNOS.Controllers
{
    public class EspecificTeamController : ApiController
    {
        private List<EspecificTeamModel> Players;
        private readonly string ConnString;

        public EspecificTeamController() {
            Players = new List<EspecificTeamModel>();
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/especificteam/{nome}/{treinador}")]
        public List<EspecificTeamModel> Get(string nome, string treinador) {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)) {
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "GetTeam";

                            command.Parameters.AddWithValue("@nome", nome);
                            command.Parameters.AddWithValue("@treinador", treinador);
                            command.Parameters["@nome"].Direction = System.Data.ParameterDirection.Input;
                            command.Parameters["@treinador"].Direction = System.Data.ParameterDirection.Input;

                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read()) {
                                EspecificTeamModel Player = new EspecificTeamModel {
                                    Id = reader.GetInt16("id"),
                                    Player = reader.GetString("jogador"),
                                    Age = reader.GetInt16("idade"),
                                    Country = reader.GetString("nacionalidade"),
                                    Position = reader.GetString("posicao")

                                };
                                Players.Add(Player);
                                Console.WriteLine("Modelo obtido com sucesso");
                            }
                            Connection.Close(); //Close connection with the database;
                            return Players;
                        } catch (MySqlException e) { Console.WriteLine(e.ToString()); }
                    }
                } catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
            return Players;
        }
    }
}
