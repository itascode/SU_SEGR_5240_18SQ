using System;
using System.Collections.Generic;

public interface IQueryManager
{
    // issues a SQL INSERT operation for tableName setting the provided column values
    IQuery Insert(string tableName, IDictionary<string, object> columnValues);

    // issues a SQL UPDATE operation for tableName setting the provided
    // column values and creating a WHERE clause from the predicates
    IQuery Update(string tableName, IDictionary<string, object> columnValues, IList<IPredicate> predicates);

    // issues a SQL DELETE operation for tableName with a WHERE clause from the predicates
    IQuery Delete(string tableName, IList<IPredicate> predicates);

    // causes the requested database operations to execute (returns
    // true if at least one row is effected),
    // check the individual IQuery returns from the above methods to determine
    // the actual impact of each
    bool Commit();

    // abandons the requested database operations (returns false if there are no operations)
    bool Rollback(); 
}

