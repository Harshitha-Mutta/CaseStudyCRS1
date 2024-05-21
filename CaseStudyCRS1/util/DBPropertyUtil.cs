using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.util
{
    internal class DBPropertyUtil
    {
        static string connectionstring;
        public static string conString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var section = builder.GetSection("ConnectionStrings");
            connectionstring = section["SqlConnectionString"];
            //Console.WriteLine(connectionstring);
            return connectionstring;
        }
    }
}
