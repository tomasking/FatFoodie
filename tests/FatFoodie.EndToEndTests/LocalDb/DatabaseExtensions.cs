using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Microsoft.SqlServer.Dac;

namespace FatFoodie.EndToEndTests.LocalDb
{
    public class DatabaseExtensions
    {
        private static readonly string ConnectionString;

        static DatabaseExtensions()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Recipe"].ConnectionString;
        }

        public static void DeployLocalDb()
        {
            string DatabaseName = "FatFoodie";
            var dacServices = new DacServices(ConnectionString);
            dacServices.Message += (sender, args) => Console.WriteLine($"{args.Message.Prefix}: {args.Message.Message}");
            var package = DacPackage.Load(@"C:\git\FatFoodie\tests\FatFoodie.EndToEndTests\bin\Debug\LocalDb\FatFoodie.Database.dacpac");
            dacServices.Deploy(package, DatabaseName, true, new DacDeployOptions()
            {
                BlockOnPossibleDataLoss = false
            });
        }

        public static void ClearAllTables()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                conn.Execute("DELETE FROM Recipe");
            }
        }
    }
}
