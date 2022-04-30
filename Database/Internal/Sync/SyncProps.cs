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
        private void CheckForSyncedProperties()
        {
            if (SyncedProperties.Count == 0)
            {
                Type type = typeof(TDBEntity);

                List<PropertyInfo> properties = new List<PropertyInfo>();

                foreach (var prop in type.GetProperties())
                {

                   // Action<prop.PropertyType> setter = (Action<prop.PropertyType>)Delegate.CreateDelegate(typeof(Action<prop.PropertyType>), null, prop.GetSetMethod());

                    //Console.WriteLine(setter);

                    object[] attrs = prop.GetCustomAttributes(true);

                    if (attrs.Length == 0)
                    {
                        Console.WriteLine("Found syncable prop " + prop.Name);
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