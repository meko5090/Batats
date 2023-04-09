using System.Data;
using System.Data.OleDb;

namespace Batats.ExcelDb;

public static class DB
{

    static string path = "C:\\Users\\mqassem\\source\\repos\\Batats\\Batats\\";
    private static string connectionString =
        //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Db.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path}Db.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

    public static DataTable GetData(string query)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            connection.Open();
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }

    public static void ExecuteCommand(string commandText)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            connection.Open();

            var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            String[] excelSheets = new String[dt.Rows.Count];

            using (OleDbCommand command = new OleDbCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}