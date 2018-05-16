using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IQueryManager querymanager = new QueryManager();
        bool rollback1 = querymanager.Rollback();
        System.Console.WriteLine("The return value of Rollback is " + rollback1);
        AddTestCommands(querymanager);
        bool rollback2 = querymanager.Rollback();
        System.Console.WriteLine("The return value of Rollback is " + rollback2);
        AddTestCommands(querymanager);
        bool commit = querymanager.Commit();
        System.Console.WriteLine("The return value of Commit is " + commit);
    }
    static void AddTestCommands(IQueryManager querymanager)
    {
        IDictionary<string, object> insertColumns = new Dictionary<string, object>();
        insertColumns.Add("make", "honda");
        insertColumns.Add("model", "civic");
        insertColumns.Add("year", "1994");
        insertColumns.Add("color", "teal");
        querymanager.Insert("Cars", insertColumns);
        System.Console.WriteLine("Inserted a car");

        IDictionary<string, object> updateColumns = new Dictionary<string, object>();
        updateColumns.Add("color", "red");
        querymanager.Update("Cars", updateColumns, null);
        System.Console.WriteLine("Updated a car");

        querymanager.Delete("Cars", null);
        System.Console.WriteLine("Deleted a car");

    }
}


