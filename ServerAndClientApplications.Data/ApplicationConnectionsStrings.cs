namespace ServerAndClientApplications.Data;

public class ApplicationConnectionsStrings
{
    private static DatabaseSettingsModel _databaseSettingsModel;

    public ApplicationConnectionsStrings(DatabaseSettingsModel databaseSettingsModel)
    {
        _databaseSettingsModel = databaseSettingsModel;
    }
    
    public void GetDatabase(string databaseName)
    {
        _databaseSettingsModel.DatabaseName = databaseName;
    }

    public void GetServerNameAndPort(string serverName, int port)
    {
        _databaseSettingsModel.ServerName = serverName;
        _databaseSettingsModel.Port = port;
    }
    
    public static string MongoAtlas()
    {
        return "mongodb+srv://karabolamola:Niceg%2388@karabodeveloperdb.ogw6w1y.mongodb.net/?retryWrites=true&w=majority";
    }

    public static string SqlLocal()
    {
        // Default string = "Server=localhost,1433;Database=developer_db;User=sa;Password=Niceg#88;TrustServerCertificate=true;";
        return $"Server={_databaseSettingsModel.ServerName},{_databaseSettingsModel.Port};Database={_databaseSettingsModel.DatabaseName};User=sa;Password=Niceg#88;TrustServerCertificate=true;";
    }
}

public class DatabaseSettingsModel
{
    public string ServerName { get; set; }
    public int Port { get; set; }
    public string DatabaseName { get; set; }
}