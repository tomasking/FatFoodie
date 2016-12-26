using System;
using System.Data.SqlClient;
using Dapper;
using Microsoft.SqlServer.Dac;

namespace FatFoodie.EndToEndTests.LocalDb
{
    public class DatabaseExtensions
    {
        public static void DeployLocalDb()
        {
            string DatabaseName = "FatFoodie";
            string dacConnectionString =$"Server=(localdb)\\mssqllocaldb; Integrated Security=true; database={DatabaseName}";
            var dacServices = new DacServices(dacConnectionString);
            dacServices.Message += (sender, args) => Console.WriteLine($"{args.Message.Prefix}: {args.Message.Message}");
            var package = DacPackage.Load(@"C:\git\FatFoodie\tests\FatFoodie.EndToEnd\bin\Debug\EndToEnd\LocalDb\FatFoodie.Database.dacpac");
            dacServices.Deploy(package, DatabaseName, true, new DacDeployOptions()
            {
                BlockOnPossibleDataLoss = false
            });
        }

        public static void ClearAllTables()
        {
            string dacConnectionString = $"Server=(localdb)\\mssqllocaldb; Integrated Security=true; database=FatFoodie";

            using (var conn = new SqlConnection(dacConnectionString))
            {
                conn.Open();
                conn.Execute("DELETE FROM Recipe");
            }
        }
    }
}
