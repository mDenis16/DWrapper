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
        public async Task<IEnumerable<TDBEntity>> SelectAsync(object _params, string? limit = null)
        {
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");

            using (MySqlConnection db = new MySqlConnection(_Engine.ConnectionString))
                return await db.QueryAsync<TDBEntity>(SelectQueryGen(_params, limit).ToString(), _params);
        }
    }
}
