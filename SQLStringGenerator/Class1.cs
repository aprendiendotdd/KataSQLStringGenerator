using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLStringGenerator
{
  public class Class1
  {
    public string GetSentence(string table, string[] columns)
    {
      if (columns.Count() == 1)
      {
        return "SELECT " + columns[0] + " FROM " + table;
      }
      else {
        return "SELECT " + columns[0] + "," + columns[1] + " FROM " + table;
      }
      
    }
  }
}
