using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

using System.Reflection;
using DWrapper.Database.Collections;
using DWrapper.Database.Entities;

namespace DWrapper.Database.Engine
{
   
    public partial class DBEngine : IDisposable
    {
        private bool disposedValue;

        public String ConnectionString { get; set; }

        public MySqlConnection Connection { get; set; }

        private bool HasCalledInternalConfigure { get; set; }

        public Dictionary<int, object> Instances = new Dictionary<int, object>();

        public virtual void OnConfigure()
        {

            HasCalledInternalConfigure = true;

            
            Type type = this.GetType();

            var searched = typeof(DBTable<>);

            foreach (var prop in type.GetRuntimeProperties())
            {
                //Console.WriteLine(prop.PropertyType);
                if (prop.PropertyType.Name == searched.Name)
                   prop.SetValue(this, Activator.CreateInstance(prop.PropertyType, this, false)); 
            }


            Connection = new MySqlConnection(ConnectionString);

            Connection.Open();
        }
   
        public DBEngine()
        {
            OnConfigure();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DBEngine()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
