using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Entities;
using Dapper;


namespace DWrapper.Database.Collections
{
    public partial class DBCollection<TDBEntity>
    {
        public IEnumerable<TDBEntity> Select(object _params, string? limit = null)
        {
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");
            return _Engine.Connection.Query<TDBEntity>(SelectQueryGen(_params, limit).ToString(), _params);
        }
        public TDBEntity? SelectOne(object _params)
        {
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");

            var query = SelectQueryGen(_params, "1").ToString();

           
            return _Engine.Connection.Query<TDBEntity>(query, _params).FirstOrDefault();
        }
    }
}
