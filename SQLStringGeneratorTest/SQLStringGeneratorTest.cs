using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SQLStringGeneratorTest
{
  [TestFixture]
  public class SQLStringGeneratorTest
  {
    [Test]
    public void Select_Sobre_Uno_O_Varios_Campos()
    {
      SQLStringGenerator.Class1 class1 = new SQLStringGenerator.Class1();
      Assert.AreEqual("SELECT a FROM x", class1.GetSentenceSelect("x", new string[] { "a" }));
      Assert.AreEqual("SELECT b FROM x", class1.GetSentenceSelect("x", new string[] { "b" }));
      Assert.AreEqual("SELECT c FROM y", class1.GetSentenceSelect("y", new string[] { "c" }));
      Assert.AreEqual("SELECT a,b FROM x", class1.GetSentenceSelect("x", new string[] { "a", "b" }));
      Assert.AreEqual("SELECT b,c FROM x", class1.GetSentenceSelect("x", new string[] { "b", "c" }));
      Assert.AreEqual("SELECT c,d FROM y", class1.GetSentenceSelect("y", new string[] { "c", "d" }));
      Assert.AreEqual("SELECT a,b,c FROM x", class1.GetSentenceSelect("x", new string[] { "a", "b", "c" }));
      Assert.AreEqual("SELECT b,c,d FROM x", class1.GetSentenceSelect("x", new string[] { "b", "c", "d" }));
      Assert.AreEqual("SELECT c,d,e FROM y", class1.GetSentenceSelect("y", new string[] { "c", "d", "e" }));
    }

    [Test]
    public void Delete_Tabla() {
      SQLStringGenerator.Class1 class1 = new SQLStringGenerator.Class1();
      Assert.AreEqual("DELETE FROM x", class1.GetSentenceDelete("x"));
      Assert.AreEqual("DELETE FROM y", class1.GetSentenceDelete("y"));
    }

    [Test]
    public void Delete_Tabla_Filtrando_Por_Uno_O_Varios_Campos()
    {
      SQLStringGenerator.Class1 class1 = new SQLStringGenerator.Class1();
      Assert.AreEqual("DELETE FROM x WHERE a = valorA", class1.GetSentenceDelete("x", new string[] { "a" }, new string[] { "valorA" }));
      Assert.AreEqual("DELETE FROM z WHERE c = valorC", class1.GetSentenceDelete("z", new string[] { "c" }, new string[] { "valorC" }));
      Assert.AreEqual("DELETE FROM x WHERE a = valorA AND b = valorB", class1.GetSentenceDelete("x", new string[] { "a", "b" }, new string[] { "valorA", "valorB" }));
      Assert.AreEqual("DELETE FROM z WHERE c = valorC AND d = valorD", class1.GetSentenceDelete("z", new string[] { "c", "d" }, new string[] { "valorC", "valorD" }));
      Assert.AreEqual("DELETE FROM x WHERE a = valorA AND b = valorB AND c = valorC", class1.GetSentenceDelete("x", new string[] { "a", "b", "c" }, new string[] { "valorA", "valorB", "valorC" }));
      Assert.AreEqual("DELETE FROM z WHERE c = valorC AND d = valorD AND e = valorE", class1.GetSentenceDelete("z", new string[] { "c", "d", "e" }, new string[] { "valorC", "valorD", "valorE" }));
    }

    [Test]
    public void Insert_Tabla_A_Una_O_Varias_Columnas() 
    {
      SQLStringGenerator.Class1 class1 = new SQLStringGenerator.Class1();
      Assert.AreEqual("INSERT INTO tablaX (a) VALUES (valorA)", class1.GetSentenceInsert("tablaX", new string[] { "a" }, new string[] { "valorA" }));
      Assert.AreEqual("INSERT INTO tablaY (b) VALUES (valorB)", class1.GetSentenceInsert("tablaY", new string[] { "b" }, new string[] { "valorB" }));
      Assert.AreEqual("INSERT INTO tablaX (a,b) VALUES (valorA,valorB)", class1.GetSentenceInsert("tablaX", new string[] { "a", "b" }, new string[] { "valorA", "valorB" }));
      Assert.AreEqual("INSERT INTO tablaY (b,c) VALUES (valorB,valorC)", class1.GetSentenceInsert("tablaY", new string[] { "b", "c" }, new string[] { "valorB", "valorC" }));
      Assert.AreEqual("INSERT INTO tablaX (a,b,c) VALUES (valorA,valorB,valorC)", class1.GetSentenceInsert("tablaX", new string[] { "a", "b", "c" }, new string[] { "valorA", "valorB", "valorC" }));
      Assert.AreEqual("INSERT INTO tablaY (b,c,d) VALUES (valorB,valorC,valorD)", class1.GetSentenceInsert("tablaY", new string[] { "b", "c", "d" }, new string[] { "valorB", "valorC", "valorD" }));
    }

    [Test]
    public void Update_Tabla_A_Una_O_Varias_Columnas()
    {
      SQLStringGenerator.Class1 class1 = new SQLStringGenerator.Class1();
      Assert.AreEqual("UPDATE tablaX SET a = valorA", class1.GetSentenceUpdate("tablaX", new string[] { "a" }, new string[] { "valorA" }));
      Assert.AreEqual("UPDATE tablaY SET b = valorB", class1.GetSentenceUpdate("tablaY", new string[] { "b" }, new string[] { "valorB" }));
      Assert.AreEqual("UPDATE tablaX SET a = valorA,b = valorB", class1.GetSentenceUpdate("tablaX", new string[] { "a", "b" }, new string[] { "valorA", "valorB" }));
      Assert.AreEqual("UPDATE tablaX SET f = valorF,g = valorG", class1.GetSentenceUpdate("tablaX", new string[] { "f", "g" }, new string[] { "valorF", "valorG" }));
      Assert.AreEqual("UPDATE tablaX SET a = valorA,b = valorB,c = valorC", class1.GetSentenceUpdate("tablaX", new string[] { "a", "b", "c" }, new string[] { "valorA", "valorB", "valorC" }));
      Assert.AreEqual("UPDATE tablaX SET f = valorF,g = valorG,z = valorZ", class1.GetSentenceUpdate("tablaX", new string[] { "f", "g", "z" }, new string[] { "valorF", "valorG", "valorZ" }));
    }
    
  }
}
