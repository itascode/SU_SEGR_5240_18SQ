using System;
using System.Collections.Generic;

public class Query : IQuery
{
    private string tableName;
    private IDictionary<string, object> columnValues;
    private IList<IPredicate> predicates;
    private string operation;
    
    public Query(string operation, string tableName, IDictionary<string, object> columnValues, IList<IPredicate> predicates)
    {
        this.tableName = tableName;
        this.columnValues = columnValues;
        this.predicates = predicates;
        this.operation = operation;
    }
    //This is a stub to be filled out with actual db implemention
    public bool Execute()
    {
        System.Console.WriteLine(operation + " " + tableName);
        return true;
    }
}

