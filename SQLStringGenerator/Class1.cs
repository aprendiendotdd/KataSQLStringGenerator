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

    public string GetSentenceSelect(string table, string[] columns)
    {
      StringBuilder stringBuilder = new StringBuilder().Append(SELECT);
      for (int i = 0; i < columns.Length; i++)
      {
        if (i == columns.Length - 1)
          stringBuilder.Append(columns[i]);
        else
          stringBuilder.Append(columns[i] + ",");
      }
      stringBuilder.Append(FROM + table);
      return stringBuilder.ToString();
    }

    public string GetSentenceDelete(string table)
    {
      return "DELETE FROM x";
    }
  }
}
