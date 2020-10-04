using FileUploadData;
using FileUploadData.Model;
using System;
using System.Collections.Generic;

namespace FileUploadBusiness
{
    public interface IFileUploadService
    {
        ResultModel<FileUploadModel> insert(string filePath);

        ResultModel<FileUploadModel> getByCurrency(string currencyCode);

        ResultModel<FileUploadModel> getByDateRange(DateTime startTranDate, DateTime endTranDate);

        ResultModel<FileUploadModel> getByStatus(string status);

        ResultModel<FileUploadModel> getAll();

        String validateFile(string filePath);
    }
}