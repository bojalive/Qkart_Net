using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CameronTubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        //blob connection string
        private readonly string _connectionString = "DefaultEndpointsProtocol=https;AccountName=blobcam;AccountKey=U56Ae0nu8gaJHtnfFIS2Eb6/qmNVddZvR/1aelOSuHp5682pLn6nutbqdaWhGVoc1QXEGw84kVxu+AStP+ql6A==;EndpointSuffix=core.windows.net";

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadFile()
        {

            BlobClient blobClient = new BlobClient(_connectionString, "files", "Aadhaar.pdf");
            //using streams
            using (var stream = new MemoryStream())
            {
                await blobClient.DownloadToAsync(stream);
                stream.Position = 0;
                var contentType = (await blobClient.GetPropertiesAsync()).Value.ContentType;
                return File(stream.ToArray(), contentType, blobClient.Name);
            }


        }


        //post methiod
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFiles(IList<IFormFile> files)
        {

            //blob client
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
            //get container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("files");
            //create container if not exists
            await containerClient.CreateIfNotExistsAsync();
            //set access policy
            // await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
            //loop through files
            foreach (var file in files)
            {
                //get blob client
                BlobClient blobClient = containerClient.GetBlobClient(file.FileName);
                //upload file
                await blobClient.UploadAsync(file.OpenReadStream());
            }
            return Ok();

        }

        //code snippet in .NET that generates a Shared Access Signature (SAS)

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVideoLink()
        {
            string connectionString = _connectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to the container and blob.
            CloudBlobContainer container = blobClient.GetContainerReference("videos");
            CloudBlockBlob blob = container.GetBlockBlobReference("InventorAddin.mp4");

            // Define the SAS token permissions and expiration time.
            SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1)
            };

            // Generate the SAS token.
            string sasToken = blob.GetSharedAccessSignature(sasPolicy);


            return Ok(sasToken);
        }

    }
}
