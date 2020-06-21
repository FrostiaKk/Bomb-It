using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace RetrieveDatabase
{
    public static class RetrieveDatabase
    {
        [FunctionName("RetrieveDatabase")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {


            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            var items = new List<string>();
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "Select TOP(10) * from Scores order by score desc;";
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(reader.GetString(1));
                        items.Add(reader.GetString(3));
                        items.Add(reader.GetInt32(2).ToString());
                    }
                }
            }

            return new OkObjectResult(items);
        }
    }
}
