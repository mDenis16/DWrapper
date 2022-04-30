using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Entities;
using Dapper;


namespace DWrapper.Database.Collections
{
    public partial class DBTable<TDBEntity>
    {
        public void Add(DBEntity? ent)
        {
            if (ent == null) throw new InvalidDataException("DBEntity is null");
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");
            if (InsertQuery == null) throw new InvalidOperationException("InsertQuery is null");

            SyncedProperties.ForEach(prop =>
            {
                ParametersForInsertion[prop.Name] = prop.GetValue(ent, null);
            });

            ent.Id = _Engine.Connection.ExecuteScalar<int>(InsertQuery, ParametersForInsertion);
        }
    }
}
