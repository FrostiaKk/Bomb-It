using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DatabaseLog
{
    public static class DatabaseLog
    {
        [FunctionName("DatabaseLog")]
        public static void Run([TimerTrigger("0 * */24 * * *")]TimerInfo myTimer, ILogger log)
        {

            string accessKey;
            string accountName;
            string connectionString;
            CloudStorageAccount storageAccount;

            accessKey = "atXZNPursJHgO7/hXA3bzmxZkmcobceM+QBeXGtUcl6tmaYRuJJod/i3wCQOrn8uH8LqtwiBDDHaqj9tQ3sBbg==";
            accountName = "azurefunctionstoragecdv";
            connectionString = "DefaultEndpointsProtocol=https;AccountName=" + accountName + ";AccountKey=" + accessKey + ";EndpointSuffix=core.windows.net";
            storageAccount = CloudStorageAccount.Parse(connectionString);

            CloudBlobClient client;
            CloudBlobContainer container;

            client = storageAccount.CreateCloudBlobClient();

            container = client.GetContainerReference("Logs");
            container.CreateIfNotExistsAsync();

            CloudBlockBlob blob;
            string name;

            name = "databaselog_" + DateTime.Now.ToString();

            blob = container.GetBlockBlobReference(name);
            blob.Properties.ContentType = "application/json";

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
            string text="";
            foreach(string item in items)
            {
                text = text + item + "\n";
            }
            blob.UploadTextAsync(text);

        }
    }
}
