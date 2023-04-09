using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using Adapter.Model;
using Adapter.Tests.Test;

namespace Adapter.Tests;

[TestClass]
public class Adapter_DataRendererShould
{
  [TestMethod]
  public void RenderOneRowGivenStubDataAdapter()
  {
    var myRenderer = new DataRenderer(new StubDbAdapter());

    var writer = new StringWriter();
    myRenderer.Render(writer);

    string result = writer.ToString();
    Console.Write(result);

    int lineCount = result.Count(c => c == '\n');
    Assert.AreEqual(3, lineCount);
  }

  [TestMethod]
  public void RenderTwoRowsGivenOleDbDataAdapter()
  {
    var adapter = new OleDbDataAdapter();
    adapter.SelectCommand = new OleDbCommand("SELECT * FROM Pattern");
    adapter.SelectCommand.Connection =
        new OleDbConnection(
            @"Provider=Microsoft.SQLSERVER.CE.OLEDB.4.0;Data Source=C:\Users\Usuario\OneDrive\Documentos\GitHub Projects\DesignPatterns\Structural\Adapter\Data\Sample.sdf");
    var myRenderer = new DataRenderer(adapter);

    var writer = new StringWriter();
    myRenderer.Render(writer);

    string result = writer.ToString();
    Console.Write(result);

    int lineCount = result.Count(c => c == '\n');
    Assert.AreEqual(4, lineCount);
  }
}