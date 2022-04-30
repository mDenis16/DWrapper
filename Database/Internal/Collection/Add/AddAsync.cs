using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Entities;
using Dapper;
using MySqlConnector;


namespace DWrapper.Database.Collections
{
    public partial class DBCollection<TDBEntity>
    {
        public async Task AddAsync(DBEntity? ent)
        {
            if (ent == null) throw new InvalidDataException("DBEntity is null");
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");
            if (InsertQuery == null) throw new InvalidOperationException("InsertQuery is null");

            SyncedProperties.ForEach(prop =>
            {
                ParametersForInsertion[prop.Name] = prop.GetValue(ent, null);
            });

            using (MySqlConnection db = new MySqlConnection(_Engine.ConnectionString))
               ent.Id = await _Engine.Connection.ExecuteScalarAsync<int>(InsertQuery, ParametersForInsertion);

        }

    }
}
