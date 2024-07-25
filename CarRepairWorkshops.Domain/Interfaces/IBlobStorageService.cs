﻿namespace CarRepairWorkshops.Domain.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadToBlobAsync(Stream data, string filename);
}
