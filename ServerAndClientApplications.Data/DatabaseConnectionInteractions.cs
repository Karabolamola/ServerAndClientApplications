using System.Data;
using System.Data.SqlClient;

namespace ServerAndClientApplications.Data;

public class DatabaseConnectionInteractions
{
    private SqlConnection _connection;
    private SqlCommand _command;
    
    public async Task OpenConnection()
    {
        _connection = new SqlConnection(ApplicationConnectionsStrings.SqlLocal());
        await _connection.OpenAsync();
    }

    public async Task CloseConnection()
    {
        await _connection.CloseAsync();
    }

    public void ExecuteQueries(string query)
    {
        _command = new SqlCommand(query, _connection);
        _command.ExecuteNonQuery();
    }

    public SqlDataReader Datareader(string query)
    {
        _command = new SqlCommand(query, _connection);
        SqlDataReader dataReader = _command.ExecuteReader();
        return dataReader;
    }

    public object ShowDataInGridView(string query)
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, _connection);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        object dataResult = dataSet.Tables[0];
        return dataResult;
    }
}