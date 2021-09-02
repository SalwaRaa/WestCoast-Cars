using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/media")]
    public class MediaController : ControllerBase
    {
        public MediaController()
        {
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=clarastorage;AccountKey=FGtbKOnvqyMIfvp/C1kHbeI3t4O5Ebc4g16LrTFXfEv7qbbzmRTbxbMjOuUUwTIJluM1MGJw4SV/U246dw3YuQ==;EndpointSuffix=core.windows.net";
                var containerName = "vehicleimages";
                var fileName = Guid.NewGuid().ToString() + ".jpg";

                var blobClient = new BlobClient(connectionString, containerName, fileName);

                if (file.Length > 0)
                {
                    var stream = file.OpenReadStream();
                    var result = await blobClient.UploadAsync(stream);
                }
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}