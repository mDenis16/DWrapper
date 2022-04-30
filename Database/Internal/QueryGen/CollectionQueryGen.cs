using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWrapper.Database.Collections
{

    public partial class DBTable<TDBEntity>
    {
        private void GenerateInsertQuery()
        {
            if (_TableName == null) throw new ArgumentNullException("_TableName is null");
            if (_Engine == null) throw new ArgumentNullException("DBEngine is null");
            if (InsertQuery != null) return;

            StringBuilder frontBuilder = new StringBuilder();
            StringBuilder backBuilder = new StringBuilder();
            frontBuilder.Append("INSERT INTO ");
            frontBuilder.Append(_TableName);
            frontBuilder.Append("(");

            backBuilder.Append("VALUES(");

            for (int i = 0; i < SyncedProperties.Count; i++)
            {
                var prop = SyncedProperties[i];
                if (prop.Name == "Id")
                    continue;


                frontBuilder.Append(prop.Name);
                backBuilder.Append("@");
                backBuilder.Append(prop.Name);

                if (i != SyncedProperties.Count - 1)
                {
                    frontBuilder.Append(",");
                    backBuilder.Append(",");
                }
                else
                {
                    frontBuilder.Append(")");
                    backBuilder.Append(")");
                }

            }
            frontBuilder.Append(backBuilder);
            frontBuilder.Append(";SELECT last_insert_id();");

            InsertQuery = frontBuilder.ToString();
        }
        private void GenerateDeleteQuery()
        {
            if (_TableName == null) throw new ArgumentNullException("_TableName is null");
            if (_Engine == null) throw new ArgumentNullException("DBEngine is null");
            if (DeleteQuery != null) return;

            StringBuilder QueryBuilder = new StringBuilder();


            QueryBuilder.Append("DELETE FROM ");
            QueryBuilder.Append(_TableName);
            QueryBuilder.Append(" WHERE ");

            DeleteQuery = QueryBuilder.ToString();
        }

        private void GenerateSelectQuery()
        {
            if (_TableName == null) throw new ArgumentNullException("_TableName is null");
            if (_Engine == null) throw new ArgumentNullException("DBEngine is null");
            if (SelectQuery != null) return;

            StringBuilder QueryBuilder = new StringBuilder();


            QueryBuilder.Append("SELECT * FROM ");
            QueryBuilder.Append(_TableName);
            QueryBuilder.Append(" WHERE ");

            SelectQuery = QueryBuilder.ToString();  
        }
    }
}