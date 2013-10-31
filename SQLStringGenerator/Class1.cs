using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLStringGenerator
{
  
  public class Class1
  {
    private const string SELECT = "SELECT ";
    private const string FROM = " FROM ";
    private const string DELETE = "DELETE";
    private const string WHERE = " WHERE ";
    private const string EQUAL = " = ";
    private const string AND = " AND ";

    public string GetSentenceSelect(string table, string[] columns)
    {
      StringBuilder stringBuilder = new StringBuilder().Append(SELECT);
      for (int i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i]);
        if (i != columns.Length - 1) stringBuilder.Append(",");
      }
      stringBuilder.Append(FROM + table);
      return stringBuilder.ToString();
    }

    public string GetSentenceDelete(string table) {
      return DELETE + FROM + table;
    }

    public string GetSentenceDelete(string table, string[] columns, string[] values)
    {
      StringBuilder stringBuilder = new StringBuilder().Append(DELETE + FROM + table + WHERE);
      for (int i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i] + EQUAL + values[i]);
        if (i != columns.Length - 1) stringBuilder.Append(AND);
      }
      return stringBuilder.ToString();
    }
  }
}
