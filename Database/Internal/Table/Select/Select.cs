using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Entities;
using Dapper;
using System.Reflection;


namespace DWrapper.Database.Collections
{
    public partial class DBTable<TDBEntity> 
    {

        public IEnumerable<TDBEntity> Select(object _params, string? limit = null)
        {
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");

            var dynamicParameters = new DynamicParameters(_params);
            dynamicParameters.RemoveUnused = false;

            if (_OneToMany)
                dynamicParameters.Add("ParentId", 5);

            var str = SelectQueryGen(_params, limit).ToString();

           
            Console.WriteLine("Generated SQL Query " + str);
            return _Engine.Connection.Query<TDBEntity>(str, dynamicParameters);
        }
        public TDBEntity? SelectOne(object _params)
        {
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");

            var query = SelectQueryGen(_params, "1").ToString();

           
            return _Engine.Connection.Query<TDBEntity>(query, _params).FirstOrDefault();
        }
    }
}
