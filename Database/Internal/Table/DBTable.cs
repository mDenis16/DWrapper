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
    public static class CollectionExtensions
    {
        public static IDictionary<int, PropertyInfo> Collections = new Dictionary<int, PropertyInfo>();
        public static IDictionary<int, object> CollectionsInstances = new Dictionary<int, object>();
    }
    public partial class DBTable<TDBEntity>
    {

        public String? _TableName = null;

        private IDictionary<string, object> ParametersForInsertion = new Dictionary<string, object>();

        private DBEngine? _Engine = null;
        private bool _OneToMany = false;
        private List<PropertyInfo> SyncedProperties = new List<PropertyInfo>();

        

        private String? InsertQuery { get; set; }
        private String? DeleteQuery { get; set; }

        private String? SelectQuery { get; set; }

      
        public void SetDbEngine(DBEngine? Engine)
        {
            _Engine = Engine;

            //Console.WriteLine("DB engine has been set");
        }
        public DBTable(DBEngine eng, bool OneToMany =false)
        {

            _Engine = eng;
            _OneToMany = OneToMany;

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
