using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using ToolLeechTruyenFull;

public class DataProvider
{
    public static DataTable ExecuteQuery(string query, object[] parameter = null)
    {
        //IL_0005: Unknown result type (might be due to invalid IL or missing references)
        //IL_000b: Expected O, but got Unknown
        //IL_0013: Unknown result type (might be due to invalid IL or missing references)
        //IL_0019: Expected O, but got Unknown
        //IL_0072: Unknown result type (might be due to invalid IL or missing references)
        //IL_007d: Expected O, but got Unknown
        MySqlConnection val = new MySqlConnection(SystemFiles._CONECTION_STRING);
        ((DbConnection)(object)val).Open();
        MySqlCommand val2 = new MySqlCommand(query, val);
        if (parameter != null)
        {
            string[] array = query.Split(' ');
            int num = 0;
            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text.Contains('@'))
                {
                    val2.Parameters.AddWithValue(text, parameter[num]);
                    num++;
                }
            }
        }
        DataTable dataTable = new DataTable();
        ((DbDataAdapter)new MySqlDataAdapter(val2)).Fill(dataTable);
        ((DbConnection)(object)val).Close();
        return dataTable;
    }

    public static bool ExecuteNonQuery(string query, object[] parameter = null)
    {
        //IL_0005: Unknown result type (might be due to invalid IL or missing references)
        //IL_000b: Expected O, but got Unknown
        //IL_0013: Unknown result type (might be due to invalid IL or missing references)
        //IL_0019: Expected O, but got Unknown
        MySqlConnection val = new MySqlConnection(SystemFiles._CONECTION_STRING);
        ((DbConnection)(object)val).Open();
        MySqlCommand val2 = new MySqlCommand(query, val);
        if (parameter != null)
        {
            string[] array = query.Split(' ');
            int num = 0;
            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text.Contains('@'))
                {
                    val2.Parameters.AddWithValue(text, parameter[num]);
                    num++;
                }
            }
        }
        int num2 = ((DbCommand)(object)val2).ExecuteNonQuery();
        ((DbConnection)(object)val).Close();
        return num2 > 0;
    }
}
