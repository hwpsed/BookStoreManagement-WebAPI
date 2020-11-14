using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUI.Controllers
{
    public class BlobStorageService
    {
        public static CloudBlobContainer GetCloudBlodContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse
                //cái này có 2 cái import ra nó mà nó support cho framework thôi à chị
                (Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("myimages");
            blobContainer.CreateIfNotExistsAsync().Wait();
            var isExisted = blobContainer.CreateIfNotExistsAsync().Result;
            if (isExisted)
            {
                blobContainer.SetPermissionsAsync(new BlobContainerPermissions
                    { PublicAccess = BlobContainerPublicAccessType.Blob});
            }
            return blobContainer;
        }
    }
}
