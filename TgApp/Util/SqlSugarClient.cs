using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgApp.Util
{
    public class SqlSugarClient
    {
        public SqlSugarClient(ConnectionConfig config) { }

        internal T Queryable<T>()
        {
            throw new NotImplementedException();
        }
    }
    public class ConnectionConfig
        {}
}
