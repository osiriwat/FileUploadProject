using FileUploadData;
using FileUploadData.Model;
using System;
using System.Collections.Generic;

namespace FileUploadBusiness
{
    public interface IFileUploadService
    {
        bool insert(string filePath);

        IEnumerable<FileUploadModel> getByCurrency(string currencyCode);

        IEnumerable<FileUploadModel> getByDateRange(DateTime startTranDate, DateTime endTranDate);

        IEnumerable<FileUploadModel> getByStatus(string status);

        IEnumerable<FileUploadModel> getAll();

        String validateFile(string filePath);
    }
}