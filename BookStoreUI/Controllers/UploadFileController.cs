using BookStoreUI.ViewModels;
using BusinessLogic.Define;
using BusinessLogic.Implement;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace BookStoreUI.Controllers
{
    //[Route("api/cloud")]
    //[ApiController]
    public class UploadFileController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Upload");
        }

        public ActionResult Upload()
        {
            CloudBlobContainer blobContainer = BlobStorageService.GetCloudBlodContainer();
            List<string> blobs = new List<string>();
            //Lay duong dan (URL) tu hinh tu blob vao List<String>

            // Create the container if it doesn't already exist.
            CloudBlobDirectory sampleDirectory = blobContainer.GetDirectoryReference("images");
            //BlobContinuationToken continuationToken = null;
            //do
            //{


            //} while (continuationToken != null);
            //var segment = blobContainer.ListBlobsSegmentedAsync(null).Result;
            var list = sampleDirectory.ListBlobsSegmentedAsync(false, BlobListingDetails.Metadata, 100, null, null, null).Result;
            foreach (var blob in list.Results)
            {
                blobs.Add(blob.Uri.ToString());
            }


            return View(blobs);
        }

        [HttpPost]
        //[Route("upload")]
        public ActionResult UploadFiles(IFormFile imageUpload)
        {
            if (imageUpload != null)
            {
                if (imageUpload.Length > 0)
                {
                    CloudBlobContainer blobContainer = BlobStorageService.GetCloudBlodContainer();
                    //Khai bao ten hinh dc upload
                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(imageUpload.FileName);
                    //Luu hinh vao blob 
                    using (var data = imageUpload.OpenReadStream())
                    {
                        blob.UploadFromStreamAsync(data);
                    }
                    //return here
                    return RedirectToAction("Upload");
                    //return View("Create");

                }
            }
            else
            {
                TempData["Msg"] = "No file is selected";
            }
            return RedirectToAction("Upload");
        }

        //Xoa hinh tren blob
        public ActionResult DeleteImage(string imageName)
        {
            Uri uri = new Uri(imageName);
            string fileName = Path.GetFileName(uri.LocalPath);
            CloudBlobContainer blobContainer = BlobStorageService.GetCloudBlodContainer();
            //lay blob chua hinh dc xoa
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);
            //xoa blob luu hinh
            blob.DeleteAsync();
            TempData["Msg"] = "File: " + fileName + " deleted.";
            //Chuyen den action upload voi tham so
            return RedirectToAction("Upload");
        }
    }
}
