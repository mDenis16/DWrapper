using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DWrapper.Database.Attributes;
using DWrapper.Database.Engine;
using Dapper;
using MySqlConnector;
using DWrapper.Database.Entities;

namespace DWrapper.Database.Collections
{
    public partial class DBCollection<TDBEntity>
    {

        public String? _TableName = null;

        private IDictionary<string, object> ParametersForInsertion = new Dictionary<string, object>();

        private DBEngine? _Engine = null;
        private List<PropertyInfo> SyncedProperties = new List<PropertyInfo>();

        private String? InsertQuery { get; set; }
        private String? DeleteQuery { get; set; }

        private String? SelectQuery { get; set; }

      
        public void SetDbEngine(DBEngine? Engine)
        {
            _Engine = Engine;

            Console.WriteLine("DB engine has been set");
        }
        public DBCollection(DBEngine eng)
        {

            _Engine = eng;

            CheckForSyncedProperties();
            RetrieveTableName();
            GenerateInsertQuery();
            GenerateDeleteQuery();
            GenerateSelectQuery();
            ConstructQueryParameters();

            

        }

        private void ConstructQueryParameters()
        {
            SyncedProperties.ForEach(prop =>
            {
                ParametersForInsertion.Add(prop.Name, 0);
            });  
        }
        private void RetrieveTableName()
        {
            if (_TableName != null) return;

            Type type = typeof(TDBEntity);
        

            TableAttribute? TableAttr =  type.GetCustomAttribute<TableAttribute>();

            if (TableAttr == null)
                throw new ArgumentException("MissingExpectedAttribute for class " + type.Name , type.Name);

            _TableName = TableAttr.TableName;
        }



        
       
    }
}
