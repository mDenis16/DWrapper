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
        public void Delete(object param = null)
        {
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");
            if (DeleteQuery == null) throw new InvalidOperationException("DeleteQuery is null");

            StringBuilder stringBuilder = new StringBuilder(DeleteQuery);
            stringBuilder.Append(WhereQueryGen(param));

            _Engine.Connection.Execute(DeleteQuery, param);
        }
        public void Delete(DBEntity? ent)
        {
            if (ent == null) throw new InvalidDataException("DBEntity is null");
            if (_Engine == null) throw new InvalidOperationException("DBEngine is null");
            if (DeleteQuery == null) throw new InvalidOperationException("DeleteQuery is null");

            object param = new { Id = ent.Id };

            StringBuilder stringBuilder = new StringBuilder(DeleteQuery);
            stringBuilder.Append(WhereQueryGen(param));

            _Engine.Connection.Execute(DeleteQuery, param);
        }
    }
}
