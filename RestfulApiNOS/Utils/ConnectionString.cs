namespace RestfulApiNOS.Utils
{
    public class ConnectionString
    {

        private readonly string Config;

        public ConnectionString()
        {
            this.Config = "Server=127.0.0.1;Database=footballportugueseteams;Uid=root;Pwd=******;SslMode = none;";
        }

        public string getConnectionString()
        {
            return this.Config;
        }
    }
}