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
    public partial class DBTable<TDBEntity>
    {
        public async Task DeleteAsync(DBEntity? ent, object param = null)
        {
            if (ent == null) throw new InvalidDataException("DBEntity is null");
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");
            if (DeleteQuery == null) throw new InvalidOperationException("DeleteQuery is null");

            StringBuilder stringBuilder = new StringBuilder(DeleteQuery);
            stringBuilder.Append(WhereQueryGen(param));

            using (MySqlConnection db = new MySqlConnection(_Engine.ConnectionString))
                await db.ExecuteAsync(DeleteQuery, param);

        }
    }
}
