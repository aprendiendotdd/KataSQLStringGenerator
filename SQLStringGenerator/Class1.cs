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
    private const string COMMA = ",";
    private const string INSERT_INTO = "INSERT INTO ";
    public const string VALUES=" VALUES";
    public const string ABRIR_PARENTESIS = " (";
    public const string CERRAR_PARENTESIS = ")";

    public string GetSentenceSelect(string table, string[] columns)
    {
      StringBuilder stringBuilder = new StringBuilder().Append(SELECT);
      for (int i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i]);
        if (i != columns.Length - 1) stringBuilder.Append(COMMA);
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

    public string GetSentenceInsert(string table, string[] columns, string[] values)
    {
      StringBuilder stringBuilder = new StringBuilder().Append(INSERT_INTO + table + ABRIR_PARENTESIS);
      for (int i = 0; i < columns.Length; i++)
      {
        stringBuilder.Append(columns[i]);
        if (i == columns.Length - 1) stringBuilder.Append(CERRAR_PARENTESIS + VALUES + ABRIR_PARENTESIS);
        else stringBuilder.Append(COMMA);
      }
      for (int i = 0; i < values.Length; i++) 
      {
        stringBuilder.Append(values[i]);
        if (i == columns.Length - 1) stringBuilder.Append(CERRAR_PARENTESIS);
        else  stringBuilder.Append(COMMA); 
      }
      return stringBuilder.ToString();
    }
  }
}
