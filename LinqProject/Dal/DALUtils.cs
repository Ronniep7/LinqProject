using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqProject.Dal
{
    public class DALUtils
    {
        public static string Connection()
        {
            string str = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = MoviesDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            return str;
        }
    }
}