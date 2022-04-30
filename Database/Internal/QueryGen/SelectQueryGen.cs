using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWrapper.Database.Collections
{
    public partial class DBTable<TDBEntity>
    {
        public Dictionary<int, string?> ParamHashOld = new Dictionary<int, string?>();
        public StringBuilder SelectQueryGen(object param, string? limit = null)
        {
           

            StringBuilder stringBuilder = new StringBuilder();

            var props = param.GetType().GetProperties();

            stringBuilder.Append("SELECT *");
            
            stringBuilder.Append(" FROM ");
            stringBuilder.Append(_TableName);
           
            if (props.Count() > 0);
            stringBuilder.Append(" WHERE ");

            for (int i = 0; i < props.Count(); i++)
            {
                var key = props[i].Name;


                stringBuilder.Append(key);
                stringBuilder.Append(" = ");
                stringBuilder.Append("@");
                stringBuilder.Append(key);
            }

            if (limit != null)
            {
                stringBuilder.Append(" LIMIT ");
                stringBuilder.Append(limit);
            }

         
            return stringBuilder;
        }
        public static StringBuilder WhereQueryGen(object param)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var props = param.GetType().GetProperties();



            for (int i = 0; i < props.Count(); i++)
            {
                var key = props[i].Name;


                stringBuilder.Append(key);
                stringBuilder.Append(" = ");
                stringBuilder.Append("@");
                stringBuilder.Append(key);
            }

            return stringBuilder;
        }
    }
}