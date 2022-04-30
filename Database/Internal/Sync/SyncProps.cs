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

    public partial class DBTable<TDBEntity>
    {
        
        private void CheckForAnotherCollection()
        {
            Type type = typeof(TDBEntity);
            foreach (var prop in type.GetRuntimeProperties())
            {
                if (typeof(DBCollection<>).Name == prop.PropertyType.Name)
                {
                    Console.WriteLine("Found Collection prop " + prop.GetHashCode());

                    CollectionExtensions.Collections[prop.GetHashCode()] = prop;


                    CollectionExtensions.CollectionsInstances[prop.GetHashCode()] =  Activator.CreateInstance(prop.PropertyType, _Engine, true);



                    // prop.SetValue(this, inst);

                    // prop.SetValue(prop, new DBTable<>);
                }
            }

        }
        private void CheckForSyncedProperties()
        {
            if (SyncedProperties.Count == 0)
            {
                CheckForAnotherCollection();

                Type type = typeof(TDBEntity);

                List<PropertyInfo> properties = new List<PropertyInfo>();


                foreach (var prop in type.GetProperties())
                {

                

                    Console.WriteLine(prop.PropertyType.Name);
                    object[] attrs = prop.GetCustomAttributes(true);


                    if (attrs.Length == 0)
                    {

                        SyncedProperties.Add(prop);
                    }
                    else
                    {
                        foreach (object attr in attrs)
                        {
                            IgnoreDBAttribute? dbIgnoreAttr = attr as IgnoreDBAttribute;
                            if (dbIgnoreAttr == null)
                                SyncedProperties.Append(prop);
                        }
                    }

                }
            }
        }
    }
}