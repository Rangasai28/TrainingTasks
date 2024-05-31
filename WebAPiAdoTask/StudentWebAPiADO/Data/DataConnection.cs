using System.Data.SqlClient;

namespace StudentWebAPiADO.Data;

public class DataConnection
{
    readonly SqlConnection? connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Pooling=False");
    public SqlCommand? command;
    public SqlDataReader? reader;

    public SqlConnection? Connection { get { return connection; } }
}
