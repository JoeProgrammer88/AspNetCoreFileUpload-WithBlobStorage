using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    // The interface is not required
    public class BlobStorageHelper : IStorageHelper
    {
        private IConfiguration _config;

        public BlobStorageHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> UploadBlob(IFormFile photo)
        {
            string con = _config.GetSection("BlobStorageString").Value;
            BlobServiceClient blobService = new BlobServiceClient(con);

            // Ensure create container to hold BLOBs
            BlobContainerClient containerClient = blobService.GetBlobContainerClient("photos");
            if (!containerClient.Exists())
            {
                await containerClient.CreateAsync();
                await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
            }

            // Add BLOB to container
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            BlobClient blobClient = containerClient.GetBlobClient(newFileName);

            await blobClient.UploadAsync(photo.OpenReadStream());
            return newFileName;
        }
    }
}
