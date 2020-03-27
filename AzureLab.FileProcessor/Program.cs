using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AzureLab.FileProcessor
{
    class Program
    {
        private static string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        private static string containerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_BLOB_CONTAINER_NAME");
        private static string blobName = Environment.GetEnvironmentVariable("AZURE_STORAGE_BLOB_NAME");
        private static ServiceCollection serviceCollection; 
        private static ServiceProvider serviceProvider;
        private static ILogger<Program> logger;
        static void Main(string[] args)
        {
            serviceCollection = new ServiceCollection();
            
            ConfigureServices(serviceCollection);

            serviceProvider = serviceCollection.BuildServiceProvider();
            logger = serviceProvider.GetService<ILogger<Program>>();
            EventId eventId = new EventId(4022, "Startup");
            // logger.Log(LogLevel.Trace, eventId,  )

            Console.WriteLine( "FileProcessor" );
            Console.WriteLine( "-------------" );
            Console.WriteLine( "" );
            Console.WriteLine( "Connection String: " + connectionString );
            Console.WriteLine( "Container Name   : " + containerName);
            Console.WriteLine( "Blob Name        : " + blobName);

            RetrieveFile();

        }

        static void RetrieveFile()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            BlobDownloadInfo download = blobClient.DownloadAsync().Result;

            MemoryStream mem = new MemoryStream();
            download.Content.CopyToAsync(mem).Wait();
            var fileString = Encoding.ASCII.GetString(mem.ToArray());
            
            using (StringReader reader = new StringReader(fileString))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine( line );
                    }

                } while (line != null);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole()).AddTransient<Program>();
        }
    }
}
