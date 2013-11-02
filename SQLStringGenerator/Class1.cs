using System.Text;

namespace SQLStringGenerator
{
  
  public class Class1
  {
    private const string Select = "SELECT ";
    private const string From = " FROM ";
    private const string Delete = "DELETE";
    private const string Where = " WHERE ";
    private const string Equal = " = ";
    private const string And = " AND ";
    private const string Comma = ",";
    private const string InsertInto = "INSERT INTO ";
    public const string Values=" VALUES";
    public const string AbrirParentesis = " (";
    public const string CerrarParentesis = ")";
    private const string Update = "UPDATE ";
    private const string Set = " SET ";
    
    public string GetSentenceSelect(string table, string[] columns)
    {
      var stringBuilder = new StringBuilder().Append(Select);
      for (var i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i]);
        if (i != columns.Length - 1) stringBuilder.Append(Comma);
      }
      stringBuilder.Append(From + table);
      return stringBuilder.ToString();
    }

    public string GetSentenceDelete(string table) {
      return Delete + From + table;
    }

    public string GetSentenceDelete(string table, string[] columns, string[] values)
    {
      var stringBuilder = new StringBuilder().Append(Delete + From + table + Where);
      for (var i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i] + Equal + values[i]);
        if (i != columns.Length - 1) stringBuilder.Append(And);
      }
      return stringBuilder.ToString(); 
    }

    public string GetSentenceInsert(string table, string[] columns, string[] values)
    {
      var stringBuilder = new StringBuilder().Append(InsertInto + table + AbrirParentesis);
      for (var i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i]);
        if (i == columns.Length - 1) stringBuilder.Append(CerrarParentesis + Values + AbrirParentesis);
        else stringBuilder.Append(Comma);
      }
      for (var i = 0; i < values.Length; i++)
      {
        stringBuilder.Append(values[i]);
        stringBuilder.Append(i == columns.Length - 1 ? CerrarParentesis : Comma);
      }
      return stringBuilder.ToString();
    }

    public object GetSentenceUpdate(string table, string[] columns, string[] values)
    {
      var stringBuilder = new StringBuilder().Append(Update + table + Set);
      for (var i = 0; i < columns.Length; i++) 
      {
        stringBuilder.Append(columns[i] + Equal + values[i]);
        if (i != columns.Length - 1) stringBuilder.Append(Comma);
      }
      return stringBuilder.ToString();
    }
  }
}
