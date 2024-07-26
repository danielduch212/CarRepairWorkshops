﻿using Azure.Storage.Blobs;
using Azure.Storage.Sas;
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

    public string? GetBlobSasUrl(string? blobUrl)
    {
        if (blobUrl == null) return null;

        var sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName = _blobStorageSettings.LogosContainerName,
            Resource = "b",
            StartsOn = DateTime.UtcNow,
            ExpiresOn = DateTime.UtcNow.AddMinutes(30),
            BlobName = GetBlobNameFromUrl(blobUrl),

        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);

        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);


        var sasToken = sasBuilder
            .ToSasQueryParameters(new Azure.Storage.StorageSharedKeyCredential(blobServiceClient.AccountName, _blobStorageSettings.AccountKey))
            .ToString();

        return $"{blobUrl}?{sasToken}";

    }

    private string GetBlobNameFromUrl(string blobUrl)
    {
        var uri = new Uri(blobUrl);
        return uri.Segments.Last();
    }

}
