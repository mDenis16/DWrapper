using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWrapper.Database.Collections;
using DWrapper.Database.Engine;
using CollectionExtensions = DWrapper.Database.Collections.CollectionExtensions;
using DWrapper.Database.Attributes;

namespace DWrapper.Database.Entities
{
    public class DBEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DBEngine DBEngine { get; set; }

        [IgnoreDB]
        public int ParentId { get; set; }

        public DBEntity()
        {

            foreach (var prop in GetType().GetProperties())
            {
                if (CollectionExtensions.Collections.ContainsKey(prop.GetHashCode())) {

                    prop.SetValue(this, Collections.CollectionExtensions.CollectionsInstances[prop.GetHashCode()]);
                    

                }
            }
        }
    }
}
