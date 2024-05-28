namespace ServerAndClientApplications.Data;

public class ApplicationConnectionsStrings
{
    private static DatabaseSettingsModel _dsm;

    public ApplicationConnectionsStrings()
    {
        _dsm = new DatabaseSettingsModel
        {
            ServerName = "localhost",
            Port = 1433,
            DatabaseName = "ServerAndClientDatabase",
            UserName = "sa",
            Password = "Niceg#88",
            IsTrustServerCertificate = true
        };
    }
    
    public static string MongoAtlas()
    {
        return "mongodb+srv://karabolamola:Niceg%2388@karabodeveloperdb.ogw6w1y.mongodb.net/?retryWrites=true&w=majority";
    }

    public static string SqlLocal()
    {
        // Default string = "Server=localhost,1433;Database=developer_db;User=sa;Password=Niceg#88;TrustServerCertificate=true;";
        return $"Server={_dsm.ServerName},{_dsm.Port.ToString()};Database={_dsm.DatabaseName};User={_dsm.UserName};Password={_dsm.Password};TrustServerCertificate={_dsm.IsTrustServerCertificate};";
    }
}

public class DatabaseSettingsModel
{
    public string ServerName { get; set; }
    public int Port { get; set; }
    public string DatabaseName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsTrustServerCertificate { get; set; }
}