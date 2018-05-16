using System;
using System.Collections.Generic;

public class QueryManager : IQueryManager
{
    private List<IQuery> queries;
    public QueryManager() 
    {
        this.queries = new List<IQuery>();
    }

    public bool Commit()
    {
        bool changed = false;
        for (int i = 0;i < queries.Count;i++) 
        {
            IQuery query = queries[i];
            changed |= query.Execute();

        }
        return changed;
    }

    public IQuery Delete(string tableName, IList<IPredicate> predicates)
    {
        IQuery query = new Query("delete", tableName, null, predicates);
        queries.Add(query);
        return query;
    }

    public IQuery Insert(string tableName, IDictionary<string, object> columnValues)
    {
        IQuery query = new Query("insert", tableName, columnValues, null);
        queries.Add(query);
        return query;
    }

    public bool Rollback()
    {
        if(queries.Count > 0)
        {
            queries.Clear();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IQuery Update(string tableName, IDictionary<string, object> columnValues, IList<IPredicate> predicates)
    {
        IQuery query = new Query("update", tableName, columnValues, predicates);
        queries.Add(query);
        return query;
    }
}

