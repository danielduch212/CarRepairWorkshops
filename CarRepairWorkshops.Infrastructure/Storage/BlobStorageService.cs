using Azure.Storage.Blobs;
using CarRepairWorkshops.Domain.Interfaces;
using CarRepairWorkshops.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace CarRepairWorkshops.Infrastructure.Storage;

public class BlobStorageService(IOptions<BlobStorageSettings> blobStorageSettingOptions) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings = blobStorageSettingOptions.Value;
    public async Task<string> UploadToBlobAsync(Stream data, string filename)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.LogosContainerName);

        var blobClient = containerClient.GetBlobClient(filename);

        await blobClient.UploadAsync(data);

        var blobUrl = blobClient.Uri.ToString();
        return blobUrl;
    }

}
