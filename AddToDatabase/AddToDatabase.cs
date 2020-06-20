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

namespace AddToDatabase
{
    public static class AddToDatabase
    {
        [FunctionName("AddToDatabase")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string name = req.Query["name"];
            string country = req.Query["country"];
            string score = req.Query["score"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            country = country ?? data?.country;
            score = score ?? data?.score;

            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                var text = $"INSERT INTO Scores (Nick,Country,Score) VALUES ('"+name+"','"+country+"',"+score+");";
                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    // Execute the command
                    var rows = await cmd.ExecuteNonQueryAsync();
                }
            }


            string responseMessage = "success";

            return new OkObjectResult(responseMessage);
        }
    }
}
