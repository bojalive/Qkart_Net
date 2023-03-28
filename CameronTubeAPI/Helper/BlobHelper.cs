using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CameronTubeAPI.Helper
{
    public class BlobHelper
    {
        private readonly IConfiguration _configuration;

        private readonly string? _connectionString;
        private readonly string? _container;
        private readonly string? _blobServiceEndpoint;
        public BlobHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
            _connectionString = _configuration["BlobConnectionStrong"];
            _container = _configuration["BlobContainer"];
            _blobServiceEndpoint = _configuration["BlobUrl"];
        }

        public async Task<String> GetSASTokenForBlobs(string name)
        {



            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(_container);
            CloudBlockBlob blob = container.GetBlockBlobReference(name);
            bool blobExist = await blob.ExistsAsync();
            if (!blobExist)
            {

                return null;
            }
            else
            {
                SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1)
                };

                string sasToken = blob.GetSharedAccessSignature(sasPolicy);
                return $"{_blobServiceEndpoint}{_container}/{name}{sasToken}";

            }

        }
    }
}
