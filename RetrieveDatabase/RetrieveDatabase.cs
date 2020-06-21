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

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

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
            var obj = new {
                ele1 = items[0], ele2 = items[1], ele3 = items[2],
                ele4 = items[3], ele5 = items[4], ele6 = items[5],
                ele7 = items[6], ele8 = items[7], ele9 = items[8],
                ele10 = items[9], ele11 = items[10], ele12 = items[11],
                ele13 = items[12], ele14 = items[13], ele15 = items[14],
                ele16 = items[15], ele17 = items[16], ele18 = items[17],
                ele19 = items[18], ele20 = items[19], ele21 = items[20],
                ele22 = items[21], ele23 = items[22], ele24 = items[23],
                ele25 = items[24], ele26 = items[25], ele27 = items[26],
                ele28 = items[27], ele29 = items[28], ele30 = items[29],
            };
            var jsonToReturn = JsonConvert.SerializeObject(obj);

            return new OkObjectResult(items);
        }
    }
}
