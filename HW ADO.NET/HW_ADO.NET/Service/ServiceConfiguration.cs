using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace HW_ADO.NET.Service
{
    public static class ServiceConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        public static void Init()
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            if (Configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();
                Configuration = configurationBuilder.AddJsonFile("Settings.json").Build();
            }
        }
    }
}