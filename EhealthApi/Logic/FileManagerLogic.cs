using Azure.Storage.Blobs;
using EhealthApi.Models;
using System.IO;
using System.Threading.Tasks;

namespace EhealthApi.Logic
{
    public class FileManagerLogic : IFileManagerLogic
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManagerLogic(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> Upload(FileModel model)
        {
            string imgUrl = string.Empty;
            var blobContainer = _blobServiceClient.GetBlobContainerClient("uploaded-images");
            var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);
            await blobClient.UploadAsync(model.ImageFile.OpenReadStream(),overwrite: true);
            imgUrl = blobClient.Uri.ToString();

            return imgUrl;
        }

        public async Task<byte[]> Get(string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("uploaded-images");
            var blobClient = blobContainer.GetBlobClient(imageName);
            var donwloadContent = await blobClient.DownloadAsync();

            using (MemoryStream ms = new MemoryStream())
            {
                await donwloadContent.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

    }
}
