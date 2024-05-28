namespace ServerAndClientApplications.Data;

public static class ApplicationConnectionsStrings
{
    public static string MongoAtlas()
    {
        return "mongodb+srv://karabolamola:Niceg%2388@karabodeveloperdb.ogw6w1y.mongodb.net/?retryWrites=true&w=majority";
    }

    public static string SqlLocal()
    {
        return "Server=localhost,1433;Database=developer_db;User=sa;Password=Niceg#88;TrustServerCertificate=true;";
    }
}