using RestfulApiNOS.Models;
using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using RestfulApiNOS.Utils;
using System;

namespace RestfulApiNOS.Controllers
{
    public class AllTeamsController : ApiController
    {
        private readonly List<AllTeamsModel> teams;
        private readonly string ConnString;

        public AllTeamsController() {
            teams = new List<AllTeamsModel>();
            ConnString = new ConnectionString().getConnectionString();
        }

        [Route("api/allteams")]
        public List<AllTeamsModel> Get() {
            using (MySqlConnection Connection = new MySqlConnection(ConnString)){
                try {
                    Connection.Open();
                    using (MySqlCommand command = Connection.CreateCommand()) {
                        try {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.CommandText = "GetTeamsNameIds";
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read()) {
                                AllTeamsModel team = new AllTeamsModel {
                                    Id = reader.GetInt16("Id"),
                                    TeamName = reader.GetString("Nome")
                                };
                                teams.Add(team);
                            }
                            Connection.Close();
                            Console.WriteLine("Modelo Obtido com sucesso");
                            return teams;
                        }catch (MySqlException e){ Console.WriteLine(e.ToString()); }
                    }
                }catch (Exception e){ Console.WriteLine(e.ToString()); }
                return null;
            }
        }
    }
}
