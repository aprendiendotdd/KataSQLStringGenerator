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
    }

    [Test]
    public void Delete_Tabla_Filtrando_Por_Un_Campo()
    {
      SQLStringGenerator.Class1 class1 = new SQLStringGenerator.Class1();
      Assert.AreEqual("DELETE FROM x WHERE a = valorA", class1.GetSentenceDelete("x", new string[] { "a" }, new string[] { "valorA" }));
      Assert.AreEqual("DELETE FROM z WHERE c = valorC", class1.GetSentenceDelete("z", new string[] { "c" }, new string[] { "valorC" }));
    }
  }
}
