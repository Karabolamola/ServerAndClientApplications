namespace ServerAndClientApplications.Data;

public class DatabaseSettingsModel
{
    public string ServerName { get; set; }
    public int Port { get; set; }
    public string DatabaseName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsTrustServerCertificate { get; set; }
}